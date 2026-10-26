using Facturas.Logica;

namespace Facturas.Pruebas;

public class ImportadorFacturasPruebas
{
    // Las pruebas pasan TestContext.Current.CancellationToken a los métodos asíncronos:
    // así xUnit puede detenerlas si se cancela la ejecución de las pruebas.

    // Progreso que guarda los avisos en una lista, sin pasar por otro hilo
    private sealed class ProgresoEnLista : IProgress<int>
    {
        public List<int> Avisos { get; } = [];

        public void Report(int value)
        {
            Avisos.Add(value);
        }
    }

    [Fact]
    public async Task ImportarAsync_DevuelveTodasLasFacturasEnOrdenYSuTotal()
    {
        var importador = new ImportadorFacturas(new OrigenSimulado(4, TimeSpan.Zero));

        var resultado = await importador.ImportarAsync(cancelacion: TestContext.Current.CancellationToken);

        Assert.Equal([1, 2, 3, 4], resultado.Facturas.Select(f => f.Numero));
        Assert.Equal(125m, resultado.ImporteTotal);
    }

    [Fact]
    public async Task ImportarAsync_InformaDelProgresoDespuesDeCadaFactura()
    {
        var progreso = new ProgresoEnLista();

        await new ImportadorFacturas(new OrigenSimulado(4, TimeSpan.Zero)).ImportarAsync(progreso, TestContext.Current.CancellationToken);

        Assert.Equal([25, 50, 75, 100], progreso.Avisos);
    }

    [Fact]
    public async Task ImportarAsync_YaCancelado_LanzaOperationCanceled()
    {
        using var cancelacion = new CancellationTokenSource();
        cancelacion.Cancel();
        var importador = new ImportadorFacturas(new OrigenSimulado(4, TimeSpan.Zero));

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => importador.ImportarAsync(cancelacion: cancelacion.Token));
    }

    [Fact]
    public async Task ImportarAsync_CanceladoAMitad_NoLeeMasFacturas()
    {
        using var cancelacion = new CancellationTokenSource();
        var progreso = new CancelarAl50(cancelacion);
        var importador = new ImportadorFacturas(new OrigenSimulado(4, TimeSpan.Zero));

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => importador.ImportarAsync(progreso, cancelacion.Token));

        Assert.Equal([25, 50], progreso.Avisos);
    }

    [Fact]
    public async Task ImportarAsync_ConUnaFacturaDanada_PropagaLaExcepcion()
    {
        var importador = new ImportadorFacturas(new OrigenSimulado(4, TimeSpan.Zero, facturaDanada: 2));

        var ex = await Assert.ThrowsAsync<InvalidDataException>(() => importador.ImportarAsync(cancelacion: TestContext.Current.CancellationToken));

        Assert.Equal("La factura 2 está dañada", ex.Message);
    }

    [Fact]
    public async Task ImportarEnParaleloAsync_DevuelveLasFacturasEnOrden()
    {
        var importador = new ImportadorFacturas(new OrigenSimulado(10, TimeSpan.FromMilliseconds(10)));

        var resultado = await importador.ImportarEnParaleloAsync(TestContext.Current.CancellationToken);

        Assert.Equal(Enumerable.Range(1, 10), resultado.Facturas.Select(f => f.Numero));
        Assert.Equal(687.5m, resultado.ImporteTotal);
    }

    [Fact]
    public async Task OrigenSimulado_FueraDeRango_LanzaExcepcion()
    {
        var origen = new OrigenSimulado(3, TimeSpan.Zero);

        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => origen.LeerAsync(4, TestContext.Current.CancellationToken));
    }

    private sealed class CancelarAl50(CancellationTokenSource cancelacion) : IProgress<int>
    {
        public List<int> Avisos { get; } = [];

        public void Report(int value)
        {
            Avisos.Add(value);
            if (value >= 50)
            {
                cancelacion.Cancel();
            }
        }
    }
}
