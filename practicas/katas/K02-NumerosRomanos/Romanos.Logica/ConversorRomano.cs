namespace Romanos.Logica;

/// <summary>
/// Convierte números enteros a números romanos y al revés.
/// </summary>
/// <example>
/// <code>
/// Console.WriteLine(ConversorRomano.ARomano(1994)); // MCMXCIV
/// Console.WriteLine(ConversorRomano.ADecimal("XIV")); // 14
/// </code>
/// </example>
public static class ConversorRomano
{
    /// <summary>Mayor número que se puede escribir con los símbolos habituales (MMMCMXCIX).</summary>
    public const int Maximo = 3999;

    /// <summary>
    /// Convierte un número entero en romano.
    /// </summary>
    /// <param name="numero">Número entre 1 y <see cref="Maximo"/>.</param>
    /// <returns>El número romano, en mayúsculas.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Si el número no está entre 1 y <see cref="Maximo"/>.</exception>
    public static string ARomano(int numero)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Convierte un número romano en entero.
    /// </summary>
    /// <param name="romano">Número romano escrito en mayúsculas y de forma correcta (<c>IV</c>, no <c>IIII</c>).</param>
    /// <returns>El número entero.</returns>
    /// <exception cref="ArgumentException">Si el texto está vacío.</exception>
    /// <exception cref="FormatException">Si el texto no es un número romano bien escrito.</exception>
    public static int ADecimal(string romano)
    {
        throw new NotImplementedException();
    }
}
