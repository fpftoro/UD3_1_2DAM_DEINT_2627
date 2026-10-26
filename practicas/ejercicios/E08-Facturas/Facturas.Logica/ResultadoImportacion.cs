namespace Facturas.Logica;

/// <summary>
/// Resultado de una importación completa.
/// </summary>
/// <param name="Facturas">Facturas importadas, en orden de número.</param>
/// <param name="ImporteTotal">Suma de los importes.</param>
public record ResultadoImportacion(IReadOnlyList<Factura> Facturas, decimal ImporteTotal);
