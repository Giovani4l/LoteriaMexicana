namespace LoteriaWeb.Models;

public class Tabla
{
    public int Id { get; set; }
    public List<Carta> Casillas { get; set; } = new();

    public static Tabla GenerarTablaAleatoria(int id, List<Carta> todasLasCartas)
    {
        var rng = new Random();
        var cartasSeleccionadas = todasLasCartas.OrderBy(c => rng.Next()).Take(25).ToList();

        return new Tabla
        {
            Id = id,
            Casillas = cartasSeleccionadas
        };
    }
}
