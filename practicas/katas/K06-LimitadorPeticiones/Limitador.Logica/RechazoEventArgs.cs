namespace Limitador.Logica;

/// <summary>
/// Datos del aviso que lanza <see cref="LimitadorPeticiones"/> cuando rechaza una petición.
/// </summary>
/// <param name="espera">Tiempo que falta para que se pueda volver a intentar.</param>
public class RechazoEventArgs(TimeSpan espera) : EventArgs
{
    /// <summary>Tiempo que falta para que se acepte una nueva petición.</summary>
    public TimeSpan Espera { get; } = espera;
}
