using Romanos.Logica;

namespace Romanos.Pruebas;

public class ConversorRomanoPruebas
{
    // --- Paso 1: los símbolos sencillos ---

    [Theory]
    [InlineData(1, "I")]
    [InlineData(5, "V")]
    [InlineData(10, "X")]
    [InlineData(50, "L")]
    [InlineData(100, "C")]
    [InlineData(500, "D")]
    [InlineData(1000, "M")]
    public void ARomano_ConUnSimbolo_DevuelveEseSimbolo(int numero, string esperado)
    {
        Assert.Equal(esperado, ConversorRomano.ARomano(numero));
    }

    // --- Paso 2: repetir símbolos y sumar ---

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData(2, "II")]
    [InlineData(3, "III")]
    [InlineData(6, "VI")]
    [InlineData(8, "VIII")]
    [InlineData(30, "XXX")]
    [InlineData(2024, "MMXXIV")]
    public void ARomano_ConSumas_RepiteYSumaSimbolos(int numero, string esperado)
    {
        Assert.Equal(esperado, ConversorRomano.ARomano(numero));
    }

    // --- Paso 3: la resta (IV, IX, XL, XC, CD, CM) ---

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData(4, "IV")]
    [InlineData(9, "IX")]
    [InlineData(14, "XIV")]
    [InlineData(40, "XL")]
    [InlineData(90, "XC")]
    [InlineData(400, "CD")]
    [InlineData(900, "CM")]
    [InlineData(1994, "MCMXCIV")]
    [InlineData(3999, "MMMCMXCIX")]
    public void ARomano_ConRestas_UsaLaNotacionSustractiva(int numero, string esperado)
    {
        Assert.Equal(esperado, ConversorRomano.ARomano(numero));
    }

    // --- Paso 4: números que no se pueden escribir ---

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData(0)]
    [InlineData(-5)]
    [InlineData(4000)]
    public void ARomano_FueraDeRango_LanzaArgumentOutOfRangeException(int numero)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => ConversorRomano.ARomano(numero));
    }

    // --- Paso 5: del romano al número ---

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData("I", 1)]
    [InlineData("III", 3)]
    [InlineData("IV", 4)]
    [InlineData("IX", 9)]
    [InlineData("XIV", 14)]
    [InlineData("XLII", 42)]
    [InlineData("MCMXCIV", 1994)]
    [InlineData("MMMCMXCIX", 3999)]
    public void ADecimal_ConUnRomanoCorrecto_DevuelveElNumero(string romano, int esperado)
    {
        Assert.Equal(esperado, ConversorRomano.ADecimal(romano));
    }

    // --- Paso 6: textos que no son romanos ---

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData("IIII")]
    [InlineData("VX")]
    [InlineData("IC")]
    [InlineData("ABC")]
    [InlineData("xiv")]
    public void ADecimal_ConUnRomanoMalEscrito_LanzaFormatException(string romano)
    {
        Assert.Throws<FormatException>(() => ConversorRomano.ADecimal(romano));
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void ADecimal_ConUnTextoVacio_LanzaArgumentException()
    {
        Assert.Throws<ArgumentException>(() => ConversorRomano.ADecimal(""));
    }

    // --- Paso 7: ida y vuelta ---

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void ARomano_SeguidoDeADecimal_DevuelveElNumeroOriginal()
    {
        for (var numero = 1; numero <= ConversorRomano.Maximo; numero++)
        {
            Assert.Equal(numero, ConversorRomano.ADecimal(ConversorRomano.ARomano(numero)));
        }
    }
}
