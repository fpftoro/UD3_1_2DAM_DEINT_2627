namespace Banco.Logica;

/// <summary>
/// Cuenta bancaria que protege su saldo: solo cambia con ingresos, retiradas y transferencias.
/// </summary>
/// <example>
/// <code>
/// var cuenta = new CuentaBancaria("Ana López", 100);
/// cuenta.Ingresar(50);
/// Console.WriteLine(cuenta); // ES-0001 · Ana López · 150,00 €
/// </code>
/// </example>
public class CuentaBancaria
{
    /// <summary>Prefijo de todos los números de cuenta.</summary>
    public const string Prefijo = "ES-";

    /// <summary>
    /// Abre una cuenta con un titular y, opcionalmente, un saldo inicial.
    /// </summary>
    /// <param name="titular">Nombre del titular. No puede estar vacío.</param>
    /// <param name="saldoInicial">Dinero con que se abre la cuenta. No puede ser negativo.</param>
    /// <exception cref="ArgumentException">Si el titular está vacío.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Si el saldo inicial es negativo.</exception>
    public CuentaBancaria(string titular, decimal saldoInicial = 0)
    {
        throw new NotImplementedException();
    }

    /// <summary>Número de cuentas abiertas desde que empezó el programa.</summary>
    public static int CuentasAbiertas => throw new NotImplementedException();

    /// <summary>Número de la cuenta (ES-0001, ES-0002…). No cambia nunca.</summary>
    public string Numero { get; }

    /// <summary>
    /// Nombre del titular, sin espacios al principio ni al final.
    /// </summary>
    /// <exception cref="ArgumentException">Si se asigna un texto vacío.</exception>
    public string Titular
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    /// <summary>Saldo actual. Solo se puede leer desde fuera de la clase.</summary>
    public decimal Saldo { get; private set; }

    /// <summary>Fecha en que se abrió la cuenta. Se puede fijar al crearla y después no cambia.</summary>
    public DateOnly FechaApertura { get; init; }

    /// <summary>Movimientos de la cuenta, del más antiguo al más reciente. Solo lectura.</summary>
    public IReadOnlyList<Movimiento> Movimientos => throw new NotImplementedException();

    /// <summary>
    /// Ingresa dinero en la cuenta.
    /// </summary>
    /// <param name="importe">Importe mayor que cero.</param>
    /// <returns>El saldo después del ingreso.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Si el importe no es mayor que cero.</exception>
    public decimal Ingresar(decimal importe)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Saca dinero de la cuenta.
    /// </summary>
    /// <param name="importe">Importe mayor que cero.</param>
    /// <returns>El saldo después de la retirada.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Si el importe no es mayor que cero.</exception>
    /// <exception cref="SaldoInsuficienteException">Si el saldo no alcanza.</exception>
    public decimal Retirar(decimal importe)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Pasa dinero de esta cuenta a otra.
    /// </summary>
    /// <param name="destino">Cuenta que recibe el dinero. No puede ser esta misma.</param>
    /// <param name="importe">Importe mayor que cero.</param>
    /// <exception cref="ArgumentException">Si el destino es la misma cuenta.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Si el importe no es mayor que cero.</exception>
    /// <exception cref="SaldoInsuficienteException">Si el saldo no alcanza.</exception>
    public void Transferir(CuentaBancaria destino, decimal importe)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Devuelve la cuenta en una línea: número, titular y saldo.
    /// </summary>
    /// <returns>Por ejemplo, <c>ES-0001 · Ana López · 150,00 €</c>.</returns>
    public override string ToString()
    {
        throw new NotImplementedException();
    }
}
