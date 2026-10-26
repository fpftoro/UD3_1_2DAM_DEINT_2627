using Almacen.Logica;

namespace Almacen.Pruebas;

public class ControlStockPruebas
{
    // --- Paso 1: entradas ---

    [Fact]
    public void Entrada_SumaLasUnidadesDelProducto()
    {
        var almacen = new ControlStock(5);

        almacen.Entrada("Tornillos", 8);
        almacen.Entrada("Tornillos", 2);

        Assert.Equal(10, almacen.Unidades("Tornillos"));
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Unidades_DeUnProductoQueNoEsta_EsCero()
    {
        var almacen = new ControlStock(5);

        Assert.Equal(0, almacen.Unidades("Tuercas"));
    }

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData(0)]
    [InlineData(-3)]
    public void Entrada_SinUnidadesPositivas_LanzaArgumentOutOfRangeException(int unidades)
    {
        var almacen = new ControlStock(5);

        Assert.Throws<ArgumentOutOfRangeException>(() => almacen.Entrada("Tornillos", unidades));
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Constructor_ConStockMinimoNegativo_LanzaArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new ControlStock(-1));
    }

    // --- Paso 2: salidas ---

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Salida_RestaLasUnidades()
    {
        var almacen = new ControlStock(5);
        almacen.Entrada("Tornillos", 10);

        almacen.Salida("Tornillos", 3);

        Assert.Equal(7, almacen.Unidades("Tornillos"));
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Salida_DeMasUnidadesDeLasQueHay_LanzaInvalidOperationExceptionSinCambiarNada()
    {
        var almacen = new ControlStock(5);
        almacen.Entrada("Tornillos", 4);

        Assert.Throws<InvalidOperationException>(() => almacen.Salida("Tornillos", 5));
        Assert.Equal(4, almacen.Unidades("Tornillos"));
    }

    // --- Paso 3: stock bajo ---

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Salida_QueBajaDelMinimo_LanzaStockBajoConLosDatos()
    {
        var almacen = new ControlStock(5);
        almacen.Entrada("Tornillos", 8);
        var avisos = new List<StockEventArgs>();
        almacen.StockBajo += (_, e) => avisos.Add(e);

        almacen.Salida("Tornillos", 4);

        var aviso = Assert.Single(avisos);
        Assert.Equal("Tornillos", aviso.Producto);
        Assert.Equal(4, aviso.Unidades);
        Assert.Equal(5, aviso.Minimo);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Salida_QueSeQuedaEnElMinimo_NoAvisa()
    {
        var almacen = new ControlStock(5);
        almacen.Entrada("Tornillos", 8);
        var avisos = 0;
        almacen.StockBajo += (_, _) => avisos++;

        almacen.Salida("Tornillos", 3);

        Assert.Equal(0, avisos);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Salida_YaPorDebajoDelMinimo_NoVuelveAAvisar()
    {
        var almacen = new ControlStock(5);
        almacen.Entrada("Tornillos", 8);
        var avisos = 0;
        almacen.StockBajo += (_, _) => avisos++;

        almacen.Salida("Tornillos", 4);
        almacen.Salida("Tornillos", 1);

        Assert.Equal(1, avisos);
    }

    // --- Paso 4: producto agotado ---

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Salida_QueLoDejaACero_LanzaStockBajoYDespuesProductoAgotado()
    {
        var almacen = new ControlStock(5);
        almacen.Entrada("Tornillos", 6);
        var orden = new List<string>();
        almacen.StockBajo += (_, _) => orden.Add("bajo");
        almacen.ProductoAgotado += (_, _) => orden.Add("agotado");

        almacen.Salida("Tornillos", 6);

        Assert.Equal(["bajo", "agotado"], orden);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Salida_SinOyentes_NoFalla()
    {
        var almacen = new ControlStock(5);
        almacen.Entrada("Tornillos", 6);

        var excepcion = Record.Exception(() => almacen.Salida("Tornillos", 6));

        Assert.Null(excepcion);
    }

    // --- Paso 5: varios suscriptores ---

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void ServicioCompras_ApuntaCadaProductoUnaVez()
    {
        var almacen = new ControlStock(5);
        var compras = new ServicioCompras();
        compras.Vigilar(almacen);
        almacen.Entrada("Tornillos", 6);
        almacen.Entrada("Tuercas", 6);

        almacen.Salida("Tornillos", 2);
        almacen.Salida("Tuercas", 6);
        almacen.Entrada("Tornillos", 5);
        almacen.Salida("Tornillos", 6);

        Assert.Equal(["Tornillos", "Tuercas"], compras.Pedidos);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Recibir_QuitaElProductoDeLosPedidos()
    {
        var almacen = new ControlStock(5);
        var compras = new ServicioCompras();
        compras.Vigilar(almacen);
        almacen.Entrada("Tornillos", 6);
        almacen.Salida("Tornillos", 2);

        Assert.True(compras.Recibir("Tornillos"));
        Assert.Empty(compras.Pedidos);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void DosSuscriptores_RecibenLosDosElAviso()
    {
        var almacen = new ControlStock(5);
        var compras = new ServicioCompras();
        compras.Vigilar(almacen);
        var avisosAlEncargado = 0;
        almacen.StockBajo += (_, _) => avisosAlEncargado++;
        almacen.Entrada("Tornillos", 6);

        almacen.Salida("Tornillos", 2);

        Assert.Equal(["Tornillos"], compras.Pedidos);
        Assert.Equal(1, avisosAlEncargado);
    }
}
