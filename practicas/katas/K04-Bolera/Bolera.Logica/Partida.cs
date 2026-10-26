namespace Bolera.Logica;

/// <summary>
/// Una partida de bolos de diez cuadros. Se anotan las tiradas una a una y la partida calcula la puntuación.
/// </summary>
/// <example>
/// <code>
/// var partida = new Partida();
/// partida.Tirar(10); // pleno
/// partida.Tirar(3);
/// partida.Tirar(4);
/// Console.WriteLine(partida.Puntuacion); // 24 (17 del pleno y 7 del segundo cuadro)
/// </code>
/// </example>
public class Partida
{
    /// <summary>Número de bolos de cada cuadro.</summary>
    public const int Bolos = 10;

    /// <summary>Número de cuadros de una partida.</summary>
    public const int Cuadros = 10;

    /// <summary>
    /// Puntuación con las tiradas hechas hasta ahora. Los bonos que todavía no se pueden calcular valen 0.
    /// </summary>
    public int Puntuacion => throw new NotImplementedException();

    /// <summary>Indica si ya se han hecho todas las tiradas de la partida.</summary>
    public bool Terminada => throw new NotImplementedException();

    /// <summary>
    /// Anota una tirada.
    /// </summary>
    /// <param name="bolos">Bolos derribados, entre 0 y 10.</param>
    /// <exception cref="ArgumentOutOfRangeException">Si los bolos no están entre 0 y 10.</exception>
    /// <exception cref="InvalidOperationException">Si la partida ya ha terminado.</exception>
    public void Tirar(int bolos)
    {
        throw new NotImplementedException();
    }
}
