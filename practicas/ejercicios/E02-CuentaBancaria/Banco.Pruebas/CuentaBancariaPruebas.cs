using Banco.Logica;

namespace Banco.Pruebas;

public class CuentaBancariaPruebas
{
    [Fact]
    public void Constructor_ConSaldoInicial_AnotaLaApertura()
    {
        var cuenta = new CuentaBancaria("Ana", 100);

        Assert.Equal(100, cuenta.Saldo);
        var apertura = Assert.Single(cuenta.Movimientos);
        Assert.Equal(new Movimiento("Apertura", 100, 100), apertura);
    }

    [Fact]
    public void Constructor_SinSaldoInicial_EmpiezaACeroSinMovimientos()
    {
        var cuenta = new CuentaBancaria("Ana");

        Assert.Equal(0, cuenta.Saldo);
        Assert.Empty(cuenta.Movimientos);
    }

    [Fact]
    public void Constructor_NumeraLasCuentasConCuatroCifras()
    {
        var cuenta = new CuentaBancaria("Ana");

        Assert.Matches(@"^ES-\d{4}$", cuenta.Numero);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_ConTitularVacio_LanzaArgumentException(string titular)
    {
        Assert.Throws<ArgumentException>(() => new CuentaBancaria(titular));
    }

    [Fact]
    public void Constructor_ConSaldoNegativo_LanzaArgumentOutOfRange()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new CuentaBancaria("Ana", -1));
    }

    [Fact]
    public void Titular_QuitaLosEspaciosDeLosExtremos()
    {
        var cuenta = new CuentaBancaria("  Ana López  ");

        Assert.Equal("Ana López", cuenta.Titular);
    }

    [Fact]
    public void Ingresar_SumaElImporteYDevuelveElSaldo()
    {
        var cuenta = new CuentaBancaria("Ana", 10);

        var saldo = cuenta.Ingresar(5.5m);

        Assert.Equal(15.5m, saldo);
        Assert.Equal(15.5m, cuenta.Saldo);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void Ingresar_ConImporteNoPositivo_LanzaArgumentOutOfRange(decimal importe)
    {
        var cuenta = new CuentaBancaria("Ana");

        Assert.Throws<ArgumentOutOfRangeException>(() => cuenta.Ingresar(importe));
    }

    [Fact]
    public void Retirar_SinSaldoSuficiente_LanzaSaldoInsuficienteYNoCambiaElSaldo()
    {
        var cuenta = new CuentaBancaria("Ana", 50);

        var ex = Assert.Throws<SaldoInsuficienteException>(() => cuenta.Retirar(80));

        Assert.Equal(50, ex.Disponible);
        Assert.Equal(50, cuenta.Saldo);
    }

    [Fact]
    public void Retirar_TodoElSaldo_DejaLaCuentaACero()
    {
        var cuenta = new CuentaBancaria("Ana", 50);

        cuenta.Retirar(50);

        Assert.Equal(0, cuenta.Saldo);
    }

    [Fact]
    public void Transferir_MueveElDineroYLoAnotaEnLasDosCuentas()
    {
        var origen = new CuentaBancaria("Ana", 100);
        var destino = new CuentaBancaria("Luis");

        origen.Transferir(destino, 30);

        Assert.Equal(70, origen.Saldo);
        Assert.Equal(30, destino.Saldo);
        Assert.Equal($"Transferencia a {destino.Numero}", origen.Movimientos[^1].Concepto);
        Assert.Equal($"Transferencia de {origen.Numero}", destino.Movimientos[^1].Concepto);
    }

    [Fact]
    public void Transferir_ALaMismaCuenta_LanzaArgumentException()
    {
        var cuenta = new CuentaBancaria("Ana", 100);

        Assert.Throws<ArgumentException>(() => cuenta.Transferir(cuenta, 10));
    }

    [Fact]
    public void FechaApertura_SeFijaAlCrearLaCuenta()
    {
        var cuenta = new CuentaBancaria("Ana") { FechaApertura = new DateOnly(2020, 1, 15) };

        Assert.Equal(new DateOnly(2020, 1, 15), cuenta.FechaApertura);
    }

    [Fact]
    public void ToString_MuestraNumeroTitularYSaldo()
    {
        var cuenta = new CuentaBancaria("Ana", 1234.5m);

        Assert.Equal($"{cuenta.Numero} · Ana · {1234.5m:N2} €", cuenta.ToString());
    }
}
