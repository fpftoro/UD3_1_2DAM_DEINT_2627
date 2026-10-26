namespace Banco.Logica;

/// <summary>
/// Un apunte del extracto de una cuenta.
/// </summary>
/// <param name="Concepto">Descripción del movimiento (apertura, ingreso, retirada…).</param>
/// <param name="Importe">Importe con signo: positivo si entra dinero y negativo si sale.</param>
/// <param name="SaldoResultante">Saldo de la cuenta después del movimiento.</param>
public record Movimiento(string Concepto, decimal Importe, decimal SaldoResultante);
