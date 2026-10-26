namespace Contactos.Logica;

/// <summary>
/// Guarda objetos identificados por su clave, sin duplicados y con una capacidad máxima.
/// </summary>
/// <typeparam name="T">Tipo de los objetos. Debe ser una clase con clave (<see cref="IConClave"/>).</typeparam>
public class Repositorio<T>
    where T : class, IConClave
{
    /// <summary>
    /// Crea un repositorio vacío.
    /// </summary>
    /// <param name="capacidad">Número máximo de elementos, mayor que cero.</param>
    /// <exception cref="ArgumentOutOfRangeException">Si la capacidad no es mayor que cero.</exception>
    public Repositorio(int capacidad)
    {
        throw new NotImplementedException();
    }

    /// <summary>Número máximo de elementos.</summary>
    public int Capacidad { get; }

    /// <summary>Número de elementos guardados.</summary>
    public int Cantidad => throw new NotImplementedException();

    /// <summary>Indica si no caben más elementos.</summary>
    public bool EstaLleno => throw new NotImplementedException();

    /// <summary>Elementos que todavía caben.</summary>
    public int HuecosLibres => throw new NotImplementedException();

    /// <summary>Todos los elementos, sin un orden concreto.</summary>
    public IReadOnlyCollection<T> Todos => throw new NotImplementedException();

    /// <summary>
    /// Añade un elemento si su clave no existe y queda sitio.
    /// </summary>
    /// <param name="elemento">Elemento que se añade.</param>
    /// <returns><see langword="true"/> si se ha añadido; <see langword="false"/> si la clave ya existía o no cabe.</returns>
    public bool Anadir(T elemento)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Indica si existe un elemento con esa clave.
    /// </summary>
    /// <param name="clave">Clave que se busca.</param>
    /// <returns><see langword="true"/> si existe.</returns>
    public bool Existe(string clave)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Busca un elemento por su clave.
    /// </summary>
    /// <param name="clave">Clave que se busca.</param>
    /// <returns>El elemento, o <see langword="null"/> si no existe.</returns>
    public T? Buscar(string clave)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Elimina el elemento con esa clave.
    /// </summary>
    /// <param name="clave">Clave del elemento.</param>
    /// <returns><see langword="true"/> si existía y se ha eliminado.</returns>
    public bool Eliminar(string clave)
    {
        throw new NotImplementedException();
    }
}
