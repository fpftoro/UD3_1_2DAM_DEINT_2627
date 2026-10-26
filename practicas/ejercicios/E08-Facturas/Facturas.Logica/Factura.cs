namespace Facturas.Logica;

/// <summary>
/// Factura importada.
/// </summary>
/// <param name="Numero">Número de factura.</param>
/// <param name="Concepto">Concepto facturado.</param>
/// <param name="Importe">Importe en euros.</param>
public record Factura(int Numero, string Concepto, decimal Importe);
