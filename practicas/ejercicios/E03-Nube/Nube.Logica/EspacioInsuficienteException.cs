namespace Nube.Logica;

/// <summary>
/// Se lanza al subir un archivo que no cabe en el espacio libre de la nube.
/// </summary>
/// <param name="archivo">Archivo que no cabe.</param>
/// <param name="libreMb">Espacio libre en ese momento.</param>
public class EspacioInsuficienteException(Archivo archivo, double libreMb)
    : Exception($"No cabe {archivo.Nombre} ({archivo.TamanoMb:N1} MB): quedan {libreMb:N1} MB libres")
{
    /// <summary>Archivo que no se ha podido subir.</summary>
    public Archivo Archivo { get; } = archivo;

    /// <summary>Espacio libre, en megabytes, cuando se intentó subir.</summary>
    public double LibreMb { get; } = libreMb;
}
