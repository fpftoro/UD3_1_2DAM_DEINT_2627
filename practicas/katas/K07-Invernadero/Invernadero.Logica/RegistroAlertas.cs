namespace Invernadero.Logica;

/// <summary>
/// Suscriptor que apunta en un registro las alertas de uno o varios sensores.
/// </summary>
public class RegistroAlertas
{
    /// <summary>Las entradas del registro, en orden.</summary>
    public IReadOnlyList<string> Entradas => throw new NotImplementedException();

    /// <summary>
    /// Empieza a escuchar los dos eventos de un sensor.
    /// </summary>
    /// <param name="sensor">El sensor.</param>
    public void Vigilar(SensorTemperatura sensor)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deja de escuchar un sensor.
    /// </summary>
    /// <param name="sensor">El sensor.</param>
    public void DejarDeVigilar(SensorTemperatura sensor)
    {
        throw new NotImplementedException();
    }
}
