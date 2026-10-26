namespace Nube.Logica;

/// <summary>
/// Imagen con sus dimensiones en píxeles.
/// </summary>
/// <param name="nombre">Nombre con extensión.</param>
/// <param name="tamanoMb">Tamaño en megabytes.</param>
/// <param name="ancho">Ancho en píxeles.</param>
/// <param name="alto">Alto en píxeles.</param>
public class Imagen(string nombre, double tamanoMb, int ancho, int alto) : Archivo(nombre, tamanoMb), IPrevisualizable
{
    /// <summary>Ancho en píxeles.</summary>
    public int Ancho { get; } = ancho;

    /// <summary>Alto en píxeles.</summary>
    public int Alto { get; } = alto;

    /// <inheritdoc/>
    public override string Tipo => throw new NotImplementedException();

    /// <inheritdoc/>
    public override string Icono => throw new NotImplementedException();

    /// <inheritdoc/>
    public string Previsualizar()
    {
        throw new NotImplementedException();
    }
}
