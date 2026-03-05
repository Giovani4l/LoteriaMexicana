namespace LoteriaWeb.Models;

public class Baraja
{
    public List<Carta> Cartas { get; private set; } = new();
    public List<Carta> CartasPasadas { get; private set; } = new();

    public Baraja()
    {
        InicializarCartas();
    }

    private void InicializarCartas()
    {
        Cartas = new List<Carta>
        {
            new Carta { Numero = 1, Nombre = "El Gallo", Frase = "El que le cantó a San Pedro no le volverá a cantar." },
            new Carta { Numero = 2, Nombre = "El Diablito", Frase = "Pórtate bien cuatito, si no te lleva el coloradito." },
            new Carta { Numero = 3, Nombre = "La Dama", Frase = "Puliendo el paso, por toda la calle real." },
            new Carta { Numero = 4, Nombre = "El Catrín", Frase = "Don Ferruco en la alameda, su bastón quería tirar." },
            new Carta { Numero = 5, Nombre = "El Paraguas", Frase = "Para el sol y para el agua." },
            new Carta { Numero = 6, Nombre = "La Sirena", Frase = "Con los cantos de sirena, no te vayas a marear." },
            new Carta { Numero = 7, Nombre = "La Escalera", Frase = "Súbeme paso a pasito, no quieras pegar brincos." },
            new Carta { Numero = 8, Nombre = "La Botella", Frase = "La herramienta del borracho." },
            new Carta { Numero = 9, Nombre = "El Barril", Frase = "Tanto bebió el albañil, que quedó como barril." },
            new Carta { Numero = 10, Nombre = "El Árbol", Frase = "El que a buen árbol se arrima, buena sombra le cobija." },
            new Carta { Numero = 11, Nombre = "El Melón", Frase = "Me lo das o me lo quitas." },
            new Carta { Numero = 12, Nombre = "El Valiente", Frase = "Por qué le corres cobarde, trayendo tan buen puñal." },
            new Carta { Numero = 13, Nombre = "El Gorrito", Frase = "Ponle su gorrito al nene, no se nos vaya a resfriar." },
            new Carta { Numero = 14, Nombre = "La Muerte", Frase = "La muerte tilica y flaca." },
            new Carta { Numero = 15, Nombre = "La Pera", Frase = "El que espera desespera." },
            new Carta { Numero = 16, Nombre = "La Bandera", Frase = "Verde blanco y colorado, la bandera del soldado." },
            new Carta { Numero = 17, Nombre = "El Bandolón", Frase = "Tocando su bandolón, está el mariachi Simón." },
            new Carta { Numero = 18, Nombre = "El Violoncello", Frase = "Creciendo se fue hasta el cielo, y como no fue violín, tuvo que ser violoncello." },
            new Carta { Numero = 19, Nombre = "La Garza", Frase = "Al otro lado del río tengo mi banco de arena, donde se sienta mi chata pico de garza morena." },
            new Carta { Numero = 20, Nombre = "El Pájaro", Frase = "Tu me traes a puros brincos, como pájaro en la rama." },
            new Carta { Numero = 21, Nombre = "La Mano", Frase = "La mano de un criminal." },
            new Carta { Numero = 22, Nombre = "La Bota", Frase = "Una bota igual que la otra." },
            new Carta { Numero = 23, Nombre = "La Luna", Frase = "El farol de los enamorados." },
            new Carta { Numero = 24, Nombre = "El Cotorro", Frase = "Cotorro cotorro saca la pata, y empiézame a platicar." },
            new Carta { Numero = 25, Nombre = "El Borracho", Frase = "A qué borracho tan necio ya no lo puedo aguantar." },
            new Carta { Numero = 26, Nombre = "El Negrito", Frase = "El que se comió el azúcar." },
            new Carta { Numero = 27, Nombre = "El Corazón", Frase = "No me extrañes corazón, que regreso en el camión." },
            new Carta { Numero = 28, Nombre = "La Sandía", Frase = "La barriga que Juan tenía, era empacho de sandía." },
            new Carta { Numero = 29, Nombre = "El Tambor", Frase = "No te arrugues cuero viejo, que te quiero pa' tambor." },
            new Carta { Numero = 30, Nombre = "El Camarón", Frase = "Camarón que se duerme, se lo lleva la corriente." },
            new Carta { Numero = 31, Nombre = "Las Jaras", Frase = "Las jaras del indio Adán, donde pegan, dan." },
            new Carta { Numero = 32, Nombre = "El Músico", Frase = "El músico trompas de hule, ya no me quiere tocar." },
            new Carta { Numero = 33, Nombre = "La Araña", Frase = "Atarántamela a palos, no me la dejes llegar." },
            new Carta { Numero = 34, Nombre = "El Soldado", Frase = "Uno, dos y tres, el soldado p'al cuartel." },
            new Carta { Numero = 35, Nombre = "La Estrella", Frase = "La guía de los marineros." },
            new Carta { Numero = 36, Nombre = "El Cazo", Frase = "El caso que te hago es poco." },
            new Carta { Numero = 37, Nombre = "El Mundo", Frase = "Este mundo es una bola, y nosotros un bolón." },
            new Carta { Numero = 38, Nombre = "El Apache", Frase = "¡Ah, Chihuahua! Cuánto apache con pantalón y huarache." },
            new Carta { Numero = 39, Nombre = "El Nopal", Frase = "Al nopal lo van a ver, nomás cuando tiene tunas." },
            new Carta { Numero = 40, Nombre = "El Alacrán", Frase = "El que con la cola pica, le dan una paliza." },
            new Carta { Numero = 41, Nombre = "La Rosa", Frase = "Rosita, Rosaura, ven que te quiero ahora." },
            new Carta { Numero = 42, Nombre = "La Calavera", Frase = "Al pasar por el panteón, me encontré un calaverón." },
            new Carta { Numero = 43, Nombre = "La Campana", Frase = "Tú con la campana y yo con tu hermana." },
            new Carta { Numero = 44, Nombre = "El Cantarito", Frase = "Tanto va el cántaro al agua, que se quiebra y te moja la enagua." },
            new Carta { Numero = 45, Nombre = "El Venado", Frase = "Saltando va buscando, pero no ve nada." },
            new Carta { Numero = 46, Nombre = "El Sol", Frase = "La cobija de los pobres." },
            new Carta { Numero = 47, Nombre = "La Corona", Frase = "El sombrero de los reyes." },
            new Carta { Numero = 48, Nombre = "La Chalupa", Frase = "Rema rema va Lupita, sentada en su chalupita." },
            new Carta { Numero = 49, Nombre = "El Pino", Frase = "Fresco y oloroso, en todo tiempo hermoso." },
            new Carta { Numero = 50, Nombre = "El Pescado", Frase = "El que por la boca muere, aunque mudo fuere." },
            new Carta { Numero = 51, Nombre = "La Palma", Frase = "Palmero, sube a la palma y tírame un coco." },
            new Carta { Numero = 52, Nombre = "La Maceta", Frase = "El que nace pa' maceta, no pasa del corredor." },
            new Carta { Numero = 53, Nombre = "El Arpa", Frase = "Arpa vieja de mi suegra, ya no sirves pa' tocar." },
            new Carta { Numero = 54, Nombre = "La Rana", Frase = "Al ver a la verde rana, qué brinco pegó tu hermana." }
        };
    }

    public void Barajear()
    {
        var rng = new Random();
        Cartas = Cartas.OrderBy(c => rng.Next()).ToList();
        CartasPasadas.Clear();
    }

    public Carta? SacarCarta()
    {
        if (Cartas.Count == 0) return null;

        var carta = Cartas[0];
        Cartas.RemoveAt(0);
        CartasPasadas.Add(carta);
        return carta;
    }
}
