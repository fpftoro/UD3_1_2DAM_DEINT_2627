namespace Invernadero.Logica;

/// <summary>
/// Datos de los eventos del <see cref="SensorTemperatura"/>: la temperatura medida y el umbral.
/// </summary>
/// <param name="temperatura">Temperatura medida, en grados.</param>
/// <param name="umbral">Umbral del sensor, en grados.</param>
public class TemperaturaEventArgs(double temperatura, double umbral) : EventArgs
{
    /// <summary>Temperatura medida, en grados.</summary>
    public double Temperatura { get; } = temperatura;

    /// <summary>Umbral del sensor, en grados.</summary>
    public double Umbral { get; } = umbral;
}
