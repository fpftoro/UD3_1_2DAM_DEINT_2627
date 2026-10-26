namespace Facturas.Logica;

/// <summary>
/// Lugar del que se leen las facturas (un servidor, una base de datos, un fichero…).
/// Leer cada factura tarda: por eso la lectura es asíncrona.
/// </summary>
public interface IOrigenFacturas
{
    /// <summary>Número de facturas disponibles, numeradas desde 1.</summary>
    int Total { get; }

    /// <summary>
    /// Lee una factura.
    /// </summary>
    /// <param name="numero">Número de factura, de 1 a <see cref="Total"/>.</param>
    /// <param name="cancelacion">Permite cancelar la lectura.</param>
    /// <returns>Una tarea que termina con la factura leída.</returns>
    Task<Factura> LeerAsync(int numero, CancellationToken cancelacion = default);
}
