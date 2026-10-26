namespace Facturas.Logica;

/// <summary>
/// Importa todas las facturas de un origen sin bloquear a quien lo llama.
/// </summary>
/// <param name="origen">Origen de las facturas.</param>
public class ImportadorFacturas(IOrigenFacturas origen)
{
    /// <summary>
    /// Importa las facturas una a una, informando del progreso.
    /// </summary>
    /// <param name="progreso">Recibe el porcentaje completado (0–100) después de cada factura. Opcional.</param>
    /// <param name="cancelacion">Permite cancelar la importación.</param>
    /// <returns>Las facturas importadas y su importe total.</returns>
    /// <exception cref="OperationCanceledException">Si se cancela antes de terminar.</exception>
    public Task<ResultadoImportacion> ImportarAsync(IProgress<int>? progreso = null, CancellationToken cancelacion = default)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Importa todas las facturas a la vez: lanza todas las lecturas y espera a que terminen.
    /// </summary>
    /// <param name="cancelacion">Permite cancelar la importación.</param>
    /// <returns>Las facturas importadas, en orden de número, y su importe total.</returns>
    /// <exception cref="OperationCanceledException">Si se cancela antes de terminar.</exception>
    public Task<ResultadoImportacion> ImportarEnParaleloAsync(CancellationToken cancelacion = default)
    {
        throw new NotImplementedException();
    }
}
