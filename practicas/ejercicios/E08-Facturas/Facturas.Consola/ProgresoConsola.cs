namespace Facturas.Consola;

/// <summary>
/// Muestra el progreso con una barra de texto y, opcionalmente, cancela al llegar a un porcentaje.
/// </summary>
/// <remarks>
/// Implementa <see cref="IProgress{T}"/> directamente para escribir en el momento.
/// <see cref="Progress{T}"/> avisaría en otro hilo y las líneas podrían salir desordenadas.
/// </remarks>
/// <param name="cancelarAl">Origen de la cancelación, o <see langword="null"/> para no cancelar.</param>
/// <param name="porcentajeCancelacion">Porcentaje a partir del cual se cancela.</param>
internal sealed class ProgresoConsola(CancellationTokenSource? cancelarAl = null, int porcentajeCancelacion = 100) : IProgress<int>
{
    /// <summary>
    /// Dibuja la barra de progreso.
    /// </summary>
    /// <param name="value">Porcentaje completado.</param>
    public void Report(int value)
    {
        var llenos = value / 10;
        Console.WriteLine($"   {new string('▓', llenos)}{new string('░', 10 - llenos)} {value,3} %");
        if (value >= porcentajeCancelacion)
        {
            cancelarAl?.Cancel();
        }
    }
}
