namespace Cine.Logica;

/// <summary>
/// Datos de los eventos de la sala: los asientos afectados.
/// </summary>
/// <param name="asientos">Asientos reservados o liberados.</param>
public class AsientosEventArgs(IReadOnlyList<Asiento> asientos) : EventArgs
{
    /// <summary>Asientos afectados.</summary>
    public IReadOnlyList<Asiento> Asientos { get; } = asientos;
}
