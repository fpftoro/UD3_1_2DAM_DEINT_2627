namespace Nube.Logica;

/// <summary>
/// Vídeo con su duración. No admite vista previa en texto y no se puede heredar de él.
/// </summary>
/// <param name="nombre">Nombre con extensión.</param>
/// <param name="tamanoMb">Tamaño en megabytes.</param>
/// <param name="duracion">Duración del vídeo.</param>
public sealed class Video(string nombre, double tamanoMb, TimeSpan duracion) : Archivo(nombre, tamanoMb)
{
    /// <summary>Duración del vídeo.</summary>
    public TimeSpan Duracion { get; } = duracion;

    /// <inheritdoc/>
    public override string Tipo => throw new NotImplementedException();

    /// <inheritdoc/>
    public override string Icono => throw new NotImplementedException();

    /// <summary>
    /// Añade la duración al texto común de todos los archivos.
    /// </summary>
    /// <returns>Por ejemplo, <c>🎬 clase.mp4 · vídeo · 120,0 MB · 05:30</c>.</returns>
    public override string ToString()
    {
        throw new NotImplementedException();
    }
}
