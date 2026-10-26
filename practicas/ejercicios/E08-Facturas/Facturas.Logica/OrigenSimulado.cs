namespace Facturas.Logica;

/// <summary>
/// Origen de facturas que simula un servidor lento con <see cref="Task.Delay(TimeSpan, CancellationToken)"/>.
/// </summary>
/// <param name="total">Número de facturas.</param>
/// <param name="retardo">Lo que tarda cada lectura.</param>
/// <param name="facturaDanada">Número de una factura que falla al leerla, o <see langword="null"/> si ninguna.</param>
public class OrigenSimulado(int total, TimeSpan retardo, int? facturaDanada = null) : IOrigenFacturas
{
    /// <inheritdoc/>
    public int Total { get; } = total;

    /// <inheritdoc/>
    /// <exception cref="ArgumentOutOfRangeException">Si el número no está entre 1 y <see cref="Total"/>.</exception>
    /// <exception cref="InvalidDataException">Si se lee la factura dañada.</exception>
    /// <exception cref="OperationCanceledException">Si se cancela durante la espera.</exception>
    public Task<Factura> LeerAsync(int numero, CancellationToken cancelacion = default)
    {
        throw new NotImplementedException();
    }
}
