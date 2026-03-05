using Microsoft.AspNetCore.SignalR;
using LoteriaWeb.Models;

namespace LoteriaWeb.Hubs;

public class JugadorInfo
{
    public string Nombre { get; set; } = "";
    public bool Listo { get; set; } = false;
    public bool EsHost { get; set; } = false;
    public int Victorias { get; set; } = 0;
}

public class LoteriaHub : Hub
{
    private static Baraja _barajaGlobal = new();
    private static bool _juegoIniciado = false;
    private static FormatoGanador _formatoActual = FormatoGanador.Ninguno;
    private static Dictionary<string, JugadorInfo> _jugadores = new();
    private static string? _hostConnectionId = null;
    private static bool _conteoEnProgreso = false;

    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        if (_jugadores.ContainsKey(Context.ConnectionId))
        {
            _jugadores.Remove(Context.ConnectionId);

            if (_hostConnectionId == Context.ConnectionId)
            {
                _hostConnectionId = _jugadores.Keys.FirstOrDefault();
                if (_hostConnectionId != null && _jugadores.ContainsKey(_hostConnectionId))
                {
                    _jugadores[_hostConnectionId].EsHost = true;
                    await Clients.Client(_hostConnectionId).SendAsync("RolesActualizados", true);
                }
                else
                {
                    // Reiniciar juego si no quedan jugadores
                    _juegoIniciado = false;
                    _formatoActual = FormatoGanador.Ninguno;
                    _barajaGlobal = new Baraja();
                    _conteoEnProgreso = false;
                }
            }

            await EnviarEstadoJugadores();
            await ChecarTodosListos();
        }
        await base.OnDisconnectedAsync(exception);
    }

    public async Task UnirseAlJuego(string nombreJugador)
    {
        var nombre = string.IsNullOrWhiteSpace(nombreJugador) ? "Jugador Anónimo" : nombreJugador;
        _jugadores[Context.ConnectionId] = new JugadorInfo { Nombre = nombre, Listo = false, EsHost = false };

        await EnviarEstadoJugadores();
        await Clients.Caller.SendAsync("RolesActualizados", _hostConnectionId == Context.ConnectionId);
    }

    public async Task MarcarListo(bool listo)
    {
        if (_jugadores.TryGetValue(Context.ConnectionId, out var jugador))
        {
            jugador.Listo = listo;
            await EnviarEstadoJugadores();
            await ChecarTodosListos();
        }
    }

    private async Task EnviarEstadoJugadores()
    {
        await Clients.All.SendAsync("JugadoresActualizadosInfo", _jugadores.Values.ToList());
    }

    private async Task ChecarTodosListos()
    {
        if (!_conteoEnProgreso && string.IsNullOrEmpty(_hostConnectionId) && _jugadores.Count > 0 && _jugadores.Values.All(j => j.Listo))
        {
            _conteoEnProgreso = true;
            _ = IniciarConteoYAsignarRol();
        }
    }

    private async Task IniciarConteoYAsignarRol()
    {
        if (_jugadores.Count == 0 || !_jugadores.Values.All(j => j.Listo))
        {
            _conteoEnProgreso = false;
            await Clients.All.SendAsync("ConteoCancelado");
            return;
        }

        _conteoEnProgreso = false;

        // Asignar rol al azar
        var random = new Random();
        var keys = _jugadores.Keys.ToList();
        if (keys.Count > 0)
        {
            _hostConnectionId = keys[random.Next(keys.Count)];

            foreach (var key in keys)
            {
                var esHost = key == _hostConnectionId;
                _jugadores[key].EsHost = esHost;
                _jugadores[key].Listo = false; // Reset status para futuro si es necesario
                await Clients.Client(key).SendAsync("RolesActualizados", esHost);
            }

            // El juego ya no se inicia automáticamente, el Gritón debe elegir el formato
            await Clients.All.SendAsync("ConteoTerminado");
            await EnviarEstadoJugadores();
        }
    }

    public async Task IniciarJuego(FormatoGanador formato)
    {
        if (Context.ConnectionId != _hostConnectionId) return;

        _barajaGlobal = new Baraja();
        _barajaGlobal.Barajear();
        _juegoIniciado = true;
        _formatoActual = formato;
        await Clients.All.SendAsync("JuegoIniciado", formato);
    }

    public async Task SacarCarta()
    {
        if (Context.ConnectionId != _hostConnectionId) return;

        if (!_juegoIniciado) return;

        var carta = _barajaGlobal.SacarCarta();
        if (carta != null)
        {
            await Clients.All.SendAsync("CartaSacada", carta);
        }
    }

    public async Task ReclamarVictoria()
    {
        if (_juegoIniciado && _jugadores.TryGetValue(Context.ConnectionId, out var jugador))
        {
            _juegoIniciado = false; // Termina el juego
            jugador.Victorias++; // Incrementar sus victorias
            await Clients.All.SendAsync("AlguienGano", jugador.Nombre);
            await EnviarEstadoJugadores(); // Al mandar esto se refrescará para todos cuántas lleva
        }
    }

    public async Task ObtenerEstadoActual()
    {
        await Clients.Caller.SendAsync("JugadoresActualizadosInfo", _jugadores.Values.ToList());
        await Clients.Caller.SendAsync("RolesActualizados", _hostConnectionId == Context.ConnectionId);

        if (_juegoIniciado)
        {
            await Clients.Caller.SendAsync("EstadoActualizado", _barajaGlobal.CartasPasadas, _formatoActual);
        }
    }
}
