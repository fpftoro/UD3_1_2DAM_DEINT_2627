namespace Anagramas.Logica;

/// <summary>
/// Trabaja con anagramas: palabras o frases que tienen las mismas letras en otro orden («Roma» y «amor»).
/// Se ignoran las mayúsculas, los espacios y todo lo que no sea una letra.
/// </summary>
/// <example>
/// <code>
/// Console.WriteLine(BuscadorAnagramas.SonAnagramas("Roma", "amor")); // True
/// Console.WriteLine(string.Join(", ", BuscadorAnagramas.Buscar("listen", ["silent", "tinsel", "casa"]))); // silent, tinsel
/// </code>
/// </example>
public static class BuscadorAnagramas
{
    /// <summary>
    /// Comprueba si dos textos son anagramas. Un texto no es anagrama de sí mismo: «Roma» y «roma» no lo son.
    /// </summary>
    /// <param name="primero">Primer texto.</param>
    /// <param name="segundo">Segundo texto.</param>
    /// <returns><see langword="true"/> si tienen las mismas letras, en otro orden.</returns>
    /// <exception cref="ArgumentNullException">Si alguno de los textos es <see langword="null"/>.</exception>
    public static bool SonAnagramas(string primero, string segundo)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Busca, entre unas palabras candidatas, las que son anagramas de una palabra.
    /// </summary>
    /// <param name="palabra">Palabra de referencia.</param>
    /// <param name="candidatas">Palabras entre las que buscar.</param>
    /// <returns>Los anagramas, en el orden en que aparecen en <paramref name="candidatas"/>.</returns>
    /// <exception cref="ArgumentNullException">Si algún argumento es <see langword="null"/>.</exception>
    public static IReadOnlyList<string> Buscar(string palabra, IEnumerable<string> candidatas)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Agrupa las palabras que son anagramas entre sí.
    /// </summary>
    /// <param name="palabras">Palabras que se agrupan. Las repetidas (sin distinguir mayúsculas) cuentan una sola vez.</param>
    /// <returns>
    /// Un grupo por cada conjunto de dos o más palabras que son anagramas. Los grupos van en el orden en que aparece
    /// su primera palabra, y dentro de cada grupo las palabras van en el orden en que aparecen.
    /// </returns>
    /// <exception cref="ArgumentNullException">Si <paramref name="palabras"/> es <see langword="null"/>.</exception>
    public static IReadOnlyList<IReadOnlyList<string>> Agrupar(IEnumerable<string> palabras)
    {
        throw new NotImplementedException();
    }
}
