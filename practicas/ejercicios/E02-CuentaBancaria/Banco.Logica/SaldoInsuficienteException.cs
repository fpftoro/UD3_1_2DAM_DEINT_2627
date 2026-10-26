namespace Banco.Logica;

/// <summary>
/// Se lanza al intentar sacar de una cuenta más dinero del que tiene.
/// </summary>
public class SaldoInsuficienteException : Exception
{
    /// <summary>
    /// Crea la excepción indicando el saldo disponible.
    /// </summary>
    /// <param name="disponible">Saldo que tenía la cuenta.</param>
    public SaldoInsuficienteException(decimal disponible)
        : base($"Saldo insuficiente: {disponible:N2} € disponibles")
    {
        throw new NotImplementedException();
    }

    /// <summary>Saldo que tenía la cuenta cuando se intentó la operación.</summary>
    public decimal Disponible { get; }
}
