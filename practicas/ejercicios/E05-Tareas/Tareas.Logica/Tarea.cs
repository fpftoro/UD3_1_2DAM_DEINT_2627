namespace Tareas.Logica;

/// <summary>
/// Tarea pendiente o completada. Avisa con un evento cada vez que cambia su estado.
/// </summary>
/// <param name="titulo">Título de la tarea. No puede estar vacío.</param>
public class Tarea(string titulo)
{
    /// <summary>
    /// Se lanza cuando cambia <see cref="Completada"/>. No se lanza si se asigna el mismo valor.
    /// </summary>
    public event EventHandler? CompletadaCambiada;

    /// <summary>Título de la tarea.</summary>
    public string Titulo { get; }

    /// <summary>
    /// Indica si la tarea está completada. Al cambiar, lanza <see cref="CompletadaCambiada"/>.
    /// </summary>
    public bool Completada
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    /// <summary>
    /// Devuelve la tarea con una casilla que indica su estado.
    /// </summary>
    /// <returns>Por ejemplo, <c>[x] Comprar pan</c> o <c>[ ] Estudiar LINQ</c>.</returns>
    public override string ToString()
    {
        throw new NotImplementedException();
    }
}
