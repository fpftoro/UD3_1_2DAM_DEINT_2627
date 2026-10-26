namespace Cine.Logica;

/// <summary>
/// Butaca de la sala, identificada por su fila (letra) y su columna (número).
/// </summary>
/// <param name="fila">Fila, empezando en 1 (la A).</param>
/// <param name="columna">Columna, empezando en 1.</param>
public class Asiento(int fila, int columna)
{
    /// <summary>Fila, empezando en 1.</summary>
    public int Fila { get; } = fila;

    /// <summary>Columna, empezando en 1.</summary>
    public int Columna { get; } = columna;

    /// <summary>Indica si está reservado. Solo lo cambia la sala.</summary>
    public bool Reservado { get; internal set; }

    /// <summary>Código del asiento: letra de la fila y número de columna (A1, C5…).</summary>
    public string Codigo => throw new NotImplementedException();

    /// <inheritdoc/>
    public override string ToString()
    {
        throw new NotImplementedException();
    }
}
