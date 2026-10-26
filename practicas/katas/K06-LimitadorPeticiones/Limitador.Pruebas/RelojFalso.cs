namespace Limitador.Pruebas;

/// <summary>
/// Reloj que solo avanza cuando se le dice, para probar el paso del tiempo sin esperar.
/// </summary>
internal sealed class RelojFalso : TimeProvider
{
    private DateTimeOffset _ahora = new(2026, 1, 1, 12, 0, 0, TimeSpan.Zero);

    public override DateTimeOffset GetUtcNow()
    {
        return _ahora;
    }

    public void Avanzar(TimeSpan tiempo)
    {
        _ahora += tiempo;
    }
}
