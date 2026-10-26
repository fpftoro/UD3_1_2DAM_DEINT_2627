namespace Tareas.Logica;

/// <summary>
/// Datos de los eventos de la agenda: la tarea afectada.
/// </summary>
/// <param name="tarea">Tarea que se ha añadido, eliminado o completado.</param>
public class TareaEventArgs(Tarea tarea) : EventArgs
{
    /// <summary>Tarea afectada.</summary>
    public Tarea Tarea { get; } = tarea;
}
