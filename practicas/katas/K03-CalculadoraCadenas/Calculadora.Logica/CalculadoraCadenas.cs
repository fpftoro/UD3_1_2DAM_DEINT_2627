namespace Calculadora.Logica;

/// <summary>
/// Suma los números que vienen escritos dentro de un texto, separados por comas, saltos de línea o por los separadores que indique el propio texto.
/// </summary>
/// <example>
/// <code>
/// Console.WriteLine(CalculadoraCadenas.Sumar("1,2,3")); // 6
/// Console.WriteLine(CalculadoraCadenas.Sumar("//;\n4;5")); // 9
/// </code>
/// </example>
public static class CalculadoraCadenas
{
    /// <summary>Los números mayores que este valor se ignoran.</summary>
    public const int Maximo = 1000;

    /// <summary>
    /// Suma los números de un texto.
    /// </summary>
    /// <param name="numeros">
    /// Texto con números separados por comas o saltos de línea. Puede empezar por <c>//</c> y un separador
    /// (<c>//;\n1;2</c>) o por varios entre corchetes (<c>//[***][%]\n1***2%3</c>).
    /// </param>
    /// <returns>La suma, sin contar los números mayores que <see cref="Maximo"/>. Un texto vacío suma 0.</returns>
    /// <exception cref="ArgumentNullException">Si el texto es <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Si hay números negativos; el mensaje los lista todos.</exception>
    /// <exception cref="FormatException">Si algún trozo no es un número, o la cabecera de separadores está incompleta.</exception>
    public static int Sumar(string numeros)
    {
        throw new NotImplementedException();
    }
}
