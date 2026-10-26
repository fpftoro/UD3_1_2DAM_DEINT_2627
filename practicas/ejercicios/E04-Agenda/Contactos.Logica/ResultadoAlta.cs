namespace Contactos.Logica;

/// <summary>
/// Resultado de intentar añadir un contacto a la agenda.
/// </summary>
public enum ResultadoAlta
{
    /// <summary>El contacto se ha añadido.</summary>
    Anadido,

    /// <summary>Ya había un contacto con ese nombre.</summary>
    Duplicado,

    /// <summary>La agenda no tiene sitio.</summary>
    AgendaLlena,
}
