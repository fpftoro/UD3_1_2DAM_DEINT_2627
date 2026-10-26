namespace Nube.Logica;

/// <summary>
/// Almacenamiento en la nube con una capacidad máxima.
/// </summary>
public class NubeAlmacenamiento
{
    /// <summary>
    /// Crea una nube vacía.
    /// </summary>
    /// <param name="capacidadMb">Capacidad en megabytes (500 si no se indica).</param>
    /// <exception cref="ArgumentOutOfRangeException">Si la capacidad no es mayor que cero.</exception>
    public NubeAlmacenamiento(double capacidadMb = 500)
    {
        throw new NotImplementedException();
    }

    /// <summary>Capacidad total en megabytes.</summary>
    public double CapacidadMb { get; }

    /// <summary>Espacio ocupado por los archivos, en megabytes.</summary>
    public double OcupadoMb
    {
        get => throw new NotImplementedException();
    }

    /// <summary>Espacio libre en megabytes.</summary>
    public double LibreMb => throw new NotImplementedException();

    /// <summary>Archivos guardados, en el orden en que se subieron.</summary>
    public IReadOnlyList<Archivo> Archivos => throw new NotImplementedException();

    /// <summary>
    /// Sube un archivo si hay espacio y no existe otro con el mismo nombre.
    /// </summary>
    /// <param name="archivo">Archivo que se sube.</param>
    /// <exception cref="InvalidOperationException">Si ya hay un archivo con ese nombre.</exception>
    /// <exception cref="EspacioInsuficienteException">Si no cabe.</exception>
    public void Subir(Archivo archivo)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Busca un archivo por su nombre, sin distinguir mayúsculas de minúsculas.
    /// </summary>
    /// <param name="nombre">Nombre que se busca.</param>
    /// <returns>El archivo, o <see langword="null"/> si no existe.</returns>
    public Archivo? Buscar(string nombre)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Elimina un archivo por su nombre.
    /// </summary>
    /// <param name="nombre">Nombre del archivo.</param>
    /// <returns><see langword="true"/> si existía y se ha eliminado.</returns>
    public bool Eliminar(string nombre)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Devuelve la vista previa de los archivos que la admiten.
    /// </summary>
    /// <returns>Una línea por archivo previsualizable: nombre y vista previa.</returns>
    public List<string> Previsualizaciones()
    {
        throw new NotImplementedException();
    }
}
