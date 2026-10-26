namespace Nube.Logica;

/// <summary>
/// Documento de texto (PDF, procesador de textos…).
/// </summary>
/// <param name="nombre">Nombre con extensión.</param>
/// <param name="tamanoMb">Tamaño en megabytes.</param>
/// <param name="paginas">Número de páginas, mayor que cero.</param>
public class Documento(string nombre, double tamanoMb, int paginas) : Archivo(nombre, tamanoMb), IPrevisualizable
{
    /// <summary>Número de páginas.</summary>
    public int Paginas { get; }

    /// <inheritdoc/>
    public override string Tipo => throw new NotImplementedException();

    /// <inheritdoc/>
    public string Previsualizar()
    {
        throw new NotImplementedException();
    }
}
