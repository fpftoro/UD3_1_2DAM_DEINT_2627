namespace Nube.Logica;

/// <summary>
/// Archivo guardado en la nube. Es abstracta: solo se crean documentos, imágenes o vídeos.
/// </summary>
public abstract class Archivo
{
    /// <summary>
    /// Inicializa el nombre y el tamaño, comunes a todos los archivos.
    /// </summary>
    /// <param name="nombre">Nombre con extensión. No puede estar vacío.</param>
    /// <param name="tamanoMb">Tamaño en megabytes, mayor que cero.</param>
    /// <exception cref="ArgumentException">Si el nombre está vacío.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Si el tamaño no es mayor que cero.</exception>
    protected Archivo(string nombre, double tamanoMb)
    {
        throw new NotImplementedException();
    }

    /// <summary>Nombre del archivo.</summary>
    public string Nombre { get; }

    /// <summary>Tamaño en megabytes.</summary>
    public double TamanoMb { get; }

    /// <summary>Tipo de archivo («documento», «imagen», «vídeo»). Lo define cada clase hija.</summary>
    public abstract string Tipo { get; }

    /// <summary>Icono para mostrar el archivo. Las clases hijas pueden cambiarlo.</summary>
    public virtual string Icono => throw new NotImplementedException();

    /// <summary>
    /// Devuelve el archivo en una línea: icono, nombre, tipo y tamaño.
    /// </summary>
    /// <returns>Por ejemplo, <c>📄 memoria.pdf · documento · 2,5 MB</c>.</returns>
    public override string ToString()
    {
        throw new NotImplementedException();
    }
}
