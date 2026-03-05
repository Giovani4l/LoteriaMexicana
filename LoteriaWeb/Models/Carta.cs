namespace LoteriaWeb.Models;

public class Carta
{
    public int Numero { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Frase { get; set; } = string.Empty;
    // Usa imágenes locales si las tienes en wwwroot/images/cartas/
    public string ImagenUrl => $"/images/cartas/{Numero}.jpg";

    
    public string SonidoUrl => $"/sounds/cartas/{Numero}.mp3";
}
