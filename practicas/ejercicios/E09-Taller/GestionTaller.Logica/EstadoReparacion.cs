namespace GestionTaller.Logica;

/// <summary>
/// Estado de un coche en el taller.
/// </summary>
public enum EstadoReparacion
{
    /// <summary>Ha entrado en el taller y espera su turno.</summary>
    Pendiente,

    /// <summary>Un mecánico está trabajando en él.</summary>
    EnReparacion,

    /// <summary>Terminado: se puede facturar.</summary>
    Reparado,
}
