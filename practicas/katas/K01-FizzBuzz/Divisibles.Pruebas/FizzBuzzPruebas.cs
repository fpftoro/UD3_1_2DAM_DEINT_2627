using Divisibles.Logica;

namespace Divisibles.Pruebas;

public class FizzBuzzPruebas
{
    // --- Paso 1: un número normal se queda como está ---

    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(7, "7")]
    [InlineData(11, "11")]
    public void Convertir_ConUnNumeroNormal_DevuelveElNumero(int numero, string esperado)
    {
        Assert.Equal(esperado, FizzBuzz.Convertir(numero));
    }

    // --- Paso 2: los múltiplos de 3 ---

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData(3)]
    [InlineData(6)]
    [InlineData(9)]
    [InlineData(12)]
    public void Convertir_ConUnMultiploDeTres_DevuelveFizz(int numero)
    {
        Assert.Equal("Fizz", FizzBuzz.Convertir(numero));
    }

    // --- Paso 3: los múltiplos de 5 ---

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(25)]
    public void Convertir_ConUnMultiploDeCinco_DevuelveBuzz(int numero)
    {
        Assert.Equal("Buzz", FizzBuzz.Convertir(numero));
    }

    // --- Paso 4: los múltiplos de los dos ---

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData(15)]
    [InlineData(30)]
    [InlineData(45)]
    [InlineData(90)]
    public void Convertir_ConUnMultiploDeTresYDeCinco_DevuelveFizzBuzz(int numero)
    {
        Assert.Equal("FizzBuzz", FizzBuzz.Convertir(numero));
    }

    // --- Paso 5: números no válidos ---

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData(0)]
    [InlineData(-3)]
    public void Convertir_ConCeroOUnNegativo_LanzaArgumentOutOfRangeException(int numero)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => FizzBuzz.Convertir(numero));
    }

    // --- Paso 6: la secuencia completa ---

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Generar_HastaQuince_DevuelveLaSecuenciaDelJuego()
    {
        string[] esperada =
        [
            "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz",
            "11", "Fizz", "13", "14", "FizzBuzz",
        ];

        Assert.Equal(esperada, FizzBuzz.Generar(15));
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Generar_HastaUno_DevuelveSoloElUno()
    {
        Assert.Equal(["1"], FizzBuzz.Generar(1));
    }

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData(0)]
    [InlineData(-1)]
    public void Generar_ConUnLimiteNoValido_LanzaArgumentOutOfRangeException(int hasta)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => FizzBuzz.Generar(hasta));
    }
}
