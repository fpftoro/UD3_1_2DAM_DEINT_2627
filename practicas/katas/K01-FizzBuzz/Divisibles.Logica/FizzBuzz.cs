namespace Divisibles.Logica;

/// <summary>
/// El juego del FizzBuzz: los múltiplos de 3 se cambian por «Fizz», los de 5 por «Buzz» y los de ambos por «FizzBuzz».
/// </summary>
/// <example>
/// <code>
/// Console.WriteLine(FizzBuzz.Convertir(15)); // FizzBuzz
/// Console.WriteLine(string.Join(" ", FizzBuzz.Generar(5))); // 1 2 Fizz 4 Buzz
/// </code>
/// </example>
public static class FizzBuzz
{
    /// <summary>
    /// Convierte un número en su texto del juego.
    /// </summary>
    /// <param name="numero">Número mayor que cero.</param>
    /// <returns><c>Fizz</c>, <c>Buzz</c>, <c>FizzBuzz</c> o el propio número como texto.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Si el número no es mayor que cero.</exception>
    public static string Convertir(int numero)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Genera la secuencia del juego desde el 1 hasta un número.
    /// </summary>
    /// <param name="hasta">Último número de la secuencia. Mayor que cero.</param>
    /// <returns>Un texto por cada número, del 1 a <paramref name="hasta"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Si <paramref name="hasta"/> no es mayor que cero.</exception>
    public static IReadOnlyList<string> Generar(int hasta)
    {
        throw new NotImplementedException();
    }
}
