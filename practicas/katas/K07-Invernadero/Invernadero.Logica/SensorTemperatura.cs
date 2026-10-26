namespace Invernadero.Logica;

/// <summary>
/// Sensor de temperatura de un invernadero que avisa cuando la temperatura pasa de un umbral y cuando vuelve a la normalidad.
/// </summary>
/// <example>
/// <code>
/// var sensor = new SensorTemperatura(30);
/// sensor.UmbralSuperado += (sender, e) => Console.WriteLine($"¡{e.Temperatura} °C!");
/// sensor.Registrar(28);   // nada
/// sensor.Registrar(31.5); // ¡31,5 °C!
/// sensor.Registrar(33);   // nada: ya estaba en alerta
/// </code>
/// </example>
public class SensorTemperatura
{
    /// <summary>
    /// Crea un sensor sin lecturas.
    /// </summary>
    /// <param name="umbral">Temperatura máxima normal, en grados. Por encima de ella, el sensor está en alerta.</param>
    public SensorTemperatura(double umbral)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Se lanza al pasar de una temperatura normal (o de ninguna lectura) a una mayor que el umbral.
    /// No se repite mientras la temperatura siga por encima.
    /// </summary>
    public event EventHandler<TemperaturaEventArgs>? UmbralSuperado;

    /// <summary>Se lanza al volver a una temperatura igual o menor que el umbral después de una alerta.</summary>
    public event EventHandler<TemperaturaEventArgs>? TemperaturaNormalizada;

    /// <summary>Temperatura máxima normal, en grados.</summary>
    public double Umbral => throw new NotImplementedException();

    /// <summary>La última temperatura registrada, o <see langword="null"/> si no hay ninguna.</summary>
    public double? Ultima => throw new NotImplementedException();

    /// <summary>Si la última temperatura es mayor que el umbral.</summary>
    public bool Alerta => throw new NotImplementedException();

    /// <summary>
    /// Registra una lectura y lanza el evento que corresponda si el sensor entra en alerta o sale de ella.
    /// </summary>
    /// <param name="temperatura">Temperatura medida, en grados.</param>
    public void Registrar(double temperatura)
    {
        throw new NotImplementedException();
    }
}
