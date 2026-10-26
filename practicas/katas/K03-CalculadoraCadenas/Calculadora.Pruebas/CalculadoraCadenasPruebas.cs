using Calculadora.Logica;

namespace Calculadora.Pruebas;

public class CalculadoraCadenasPruebas
{
    // --- Paso 1: un texto vacío suma cero y un número se suma a sí mismo ---

    [Fact]
    public void Sumar_ConUnTextoVacio_DevuelveCero()
    {
        Assert.Equal(0, CalculadoraCadenas.Sumar(""));
    }

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData("1", 1)]
    [InlineData("42", 42)]
    public void Sumar_ConUnSoloNumero_DevuelveEseNumero(string numeros, int esperado)
    {
        Assert.Equal(esperado, CalculadoraCadenas.Sumar(numeros));
    }

    // --- Paso 2: varios números separados por comas ---

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData("1,2", 3)]
    [InlineData("1,2,3,4", 10)]
    [InlineData("10,20,30", 60)]
    public void Sumar_ConVariosNumeros_LosSuma(string numeros, int esperado)
    {
        Assert.Equal(esperado, CalculadoraCadenas.Sumar(numeros));
    }

    // --- Paso 3: los saltos de línea también separan ---

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData("1\n2", 3)]
    [InlineData("1\n2,3", 6)]
    public void Sumar_ConSaltosDeLinea_TambienLosSepara(string numeros, int esperado)
    {
        Assert.Equal(esperado, CalculadoraCadenas.Sumar(numeros));
    }

    // --- Paso 4: entradas mal formadas ---

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData("1,")]
    [InlineData("1,\n")]
    [InlineData("1,,2")]
    [InlineData("1,a")]
    public void Sumar_ConUnTrozoQueNoEsUnNumero_LanzaFormatException(string numeros)
    {
        Assert.Throws<FormatException>(() => CalculadoraCadenas.Sumar(numeros));
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Sumar_ConNull_LanzaArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => CalculadoraCadenas.Sumar(null!));
    }

    // --- Paso 5: un separador propio ---

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData("//;\n1;2", 3)]
    [InlineData("//|\n4|5|6", 15)]
    [InlineData("//.\n1.2", 3)]
    public void Sumar_ConUnSeparadorPropio_LoUsa(string numeros, int esperado)
    {
        Assert.Equal(esperado, CalculadoraCadenas.Sumar(numeros));
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Sumar_ConUnaCabeceraSinSaltoDeLinea_LanzaFormatException()
    {
        Assert.Throws<FormatException>(() => CalculadoraCadenas.Sumar("//;"));
    }

    // --- Paso 6: los negativos no se admiten ---

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Sumar_ConUnNegativo_LanzaArgumentException()
    {
        var error = Assert.Throws<ArgumentException>(() => CalculadoraCadenas.Sumar("1,-2,3"));

        Assert.Contains("-2", error.Message);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Sumar_ConVariosNegativos_LosListaTodosEnElMensaje()
    {
        var error = Assert.Throws<ArgumentException>(() => CalculadoraCadenas.Sumar("-1,2,-3"));

        Assert.Contains("-1", error.Message);
        Assert.Contains("-3", error.Message);
    }

    // --- Paso 7: los números grandes se ignoran ---

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData("2,1001", 2)]
    [InlineData("1000,1", 1001)]
    [InlineData("1001", 0)]
    public void Sumar_ConNumerosMayoresQueMil_LosIgnora(string numeros, int esperado)
    {
        Assert.Equal(esperado, CalculadoraCadenas.Sumar(numeros));
    }

    // --- Paso 8: separadores largos y varios separadores ---

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData("//[***]\n1***2***3", 6)]
    [InlineData("//[%%]\n4%%5", 9)]
    public void Sumar_ConUnSeparadorLargoEntreCorchetes_LoUsa(string numeros, int esperado)
    {
        Assert.Equal(esperado, CalculadoraCadenas.Sumar(numeros));
    }

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData("//[*][%]\n1*2%3", 6)]
    [InlineData("//[**][%%]\n1**2%%3", 6)]
    public void Sumar_ConVariosSeparadoresEntreCorchetes_UsaTodos(string numeros, int esperado)
    {
        Assert.Equal(esperado, CalculadoraCadenas.Sumar(numeros));
    }
}
