namespace Tareas.Logica;

/// <summary>
/// Lista de tareas sin títulos repetidos que avisa con eventos de cada cambio.
/// </summary>
public class AgendaTareas
{
    /// <summary>Se lanza después de añadir una tarea.</summary>
    public event EventHandler<TareaEventArgs>? TareaAnadida;

    /// <summary>Se lanza después de eliminar una tarea.</summary>
    public event EventHandler<TareaEventArgs>? TareaEliminada;

    /// <summary>Se lanza cuando una tarea de la agenda cambia de estado, se cambie desde la agenda o desde la propia tarea.</summary>
    public event EventHandler<TareaEventArgs>? EstadoCambiado;

    /// <summary>Tareas en el orden en que se añadieron.</summary>
    public IReadOnlyList<Tarea> Tareas => throw new NotImplementedException();

    /// <summary>Número de tareas sin completar.</summary>
    public int Pendientes
    {
        get => throw new NotImplementedException();
    }

    /// <summary>
    /// Añade una tarea y lanza <see cref="TareaAnadida"/>.
    /// </summary>
    /// <param name="tarea">Tarea que se añade.</param>
    /// <exception cref="InvalidOperationException">Si ya hay una tarea con ese título.</exception>
    public void Agregar(Tarea tarea)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Elimina una tarea por su título y lanza <see cref="TareaEliminada"/>.
    /// </summary>
    /// <param name="titulo">Título de la tarea, sin distinguir mayúsculas.</param>
    /// <returns><see langword="true"/> si existía y se ha eliminado.</returns>
    public bool Eliminar(string titulo)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Marca una tarea como completada.
    /// </summary>
    /// <param name="titulo">Título de la tarea, sin distinguir mayúsculas.</param>
    /// <returns><see langword="true"/> si la tarea existía.</returns>
    public bool Completar(string titulo)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Busca una tarea por su título, sin distinguir mayúsculas.
    /// </summary>
    /// <param name="titulo">Título que se busca.</param>
    /// <returns>La tarea, o <see langword="null"/> si no existe.</returns>
    public Tarea? Buscar(string titulo)
    {
        throw new NotImplementedException();
    }
}
