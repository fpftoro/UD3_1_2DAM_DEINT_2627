namespace Contactos.Logica;

/// <summary>
/// Agenda telefónica con una capacidad máxima y sin nombres repetidos.
/// </summary>
/// <param name="capacidad">Número máximo de contactos (10 si no se indica).</param>
public class Agenda(int capacidad = 10)
{
    /// <summary>Número máximo de contactos.</summary>
    public int Capacidad => throw new NotImplementedException();

    /// <summary>Número de contactos guardados.</summary>
    public int Cantidad => throw new NotImplementedException();

    /// <summary>Indica si no caben más contactos.</summary>
    public bool EstaLlena => throw new NotImplementedException();

    /// <summary>Contactos que todavía caben.</summary>
    public int HuecosLibres => throw new NotImplementedException();

    /// <summary>
    /// Añade un contacto si su nombre no existe y queda sitio.
    /// </summary>
    /// <param name="contacto">Contacto que se añade.</param>
    /// <returns>Si se ha añadido o por qué no.</returns>
    public ResultadoAlta Anadir(Contacto contacto)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Indica si hay un contacto con ese nombre.
    /// </summary>
    /// <param name="nombre">Nombre que se busca.</param>
    /// <returns><see langword="true"/> si existe.</returns>
    public bool Existe(string nombre)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Busca el teléfono de un contacto.
    /// </summary>
    /// <param name="nombre">Nombre del contacto.</param>
    /// <returns>El teléfono, o <see langword="null"/> si no existe.</returns>
    public string? BuscarTelefono(string nombre)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Elimina un contacto por su nombre.
    /// </summary>
    /// <param name="nombre">Nombre del contacto.</param>
    /// <returns><see langword="true"/> si existía y se ha eliminado.</returns>
    public bool Eliminar(string nombre)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Devuelve los contactos ordenados alfabéticamente.
    /// </summary>
    /// <returns>Una lista nueva: modificarla no cambia la agenda.</returns>
    public List<Contacto> Listar()
    {
        throw new NotImplementedException();
    }
}
