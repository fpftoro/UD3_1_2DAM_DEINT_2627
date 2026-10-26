using Bolera.Logica;

namespace Bolera.Pruebas;

public class PartidaPruebas
{
    private readonly Partida _partida = new();

    // --- Paso 1: sin derribar nada ---

    [Fact]
    public void Puntuacion_ConUnaPartidaNueva_EsCero()
    {
        Assert.Equal(0, _partida.Puntuacion);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Puntuacion_SinDerribarNingunBolo_EsCero()
    {
        TirarVarias(20, 0);

        Assert.Equal(0, _partida.Puntuacion);
    }

    // --- Paso 2: sumar los bolos ---

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Puntuacion_DerribandoUnBoloEnCadaTirada_EsVeinte()
    {
        TirarVarias(20, 1);

        Assert.Equal(20, _partida.Puntuacion);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Puntuacion_ConLaPartidaSinTerminar_SumaLoTirado()
    {
        Tirar(3, 4, 2);

        Assert.Equal(9, _partida.Puntuacion);
    }

    // --- Paso 3: el semipleno (derribar los diez bolos en dos tiradas) ---

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Puntuacion_ConUnSemipleno_SumaLaSiguienteTirada()
    {
        Tirar(5, 5, 3);
        TirarVarias(17, 0);

        Assert.Equal(16, _partida.Puntuacion);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Puntuacion_ConDosTiradasQueSumanDiezEnCuadrosDistintos_NoEsSemipleno()
    {
        Tirar(0, 5, 5, 3);
        TirarVarias(16, 0);

        Assert.Equal(13, _partida.Puntuacion);
    }

    // --- Paso 4: el pleno (derribar los diez bolos a la primera) ---

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Puntuacion_ConUnPleno_SumaLasDosTiradasSiguientes()
    {
        Tirar(10, 3, 4);
        TirarVarias(16, 0);

        Assert.Equal(24, _partida.Puntuacion);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Puntuacion_ConDosPlenosSeguidos_AcumulaLosBonos()
    {
        Tirar(10, 10, 3);
        TirarVarias(15, 0);

        Assert.Equal(39, _partida.Puntuacion);
    }

    // --- Paso 5: el último cuadro ---

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Puntuacion_ConUnSemiplenoEnElUltimoCuadro_AnotaUnaTiradaExtra()
    {
        TirarVarias(18, 0);
        Tirar(5, 5, 7);

        Assert.Equal(17, _partida.Puntuacion);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Puntuacion_ConUnPlenoEnElUltimoCuadro_AnotaDosTiradasExtra()
    {
        TirarVarias(18, 0);
        Tirar(10, 7, 1);

        Assert.Equal(18, _partida.Puntuacion);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Puntuacion_ConUnaPartidaPerfecta_Es300()
    {
        TirarVarias(12, 10);

        Assert.Equal(300, _partida.Puntuacion);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Puntuacion_ConTodosLosCuadrosEnSemipleno_Es150()
    {
        TirarVarias(21, 5);

        Assert.Equal(150, _partida.Puntuacion);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Puntuacion_ConUnaPartidaReal_Es167()
    {
        Tirar(10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8, 1);

        Assert.Equal(167, _partida.Puntuacion);
    }

    // --- Paso 6: cuándo termina la partida ---

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Terminada_ConUnaPartidaNueva_EsFalse()
    {
        Assert.False(_partida.Terminada);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Terminada_TrasLasVeinteTiradasSinBono_EsTrue()
    {
        TirarVarias(20, 1);

        Assert.True(_partida.Terminada);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Terminada_ConUnSemiplenoEnElUltimoCuadroSinLaTiradaExtra_EsFalse()
    {
        TirarVarias(18, 0);
        Tirar(5, 5);

        Assert.False(_partida.Terminada);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Terminada_ConUnaPartidaReal_EsTrueTrasLaUltimaTirada()
    {
        Tirar(10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8);
        Assert.False(_partida.Terminada);

        Tirar(1);

        Assert.True(_partida.Terminada);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Terminada_ConUnaPartidaPerfecta_EsTrueAlLasDoceTiradas()
    {
        TirarVarias(11, 10);
        Assert.False(_partida.Terminada);

        Tirar(10);

        Assert.True(_partida.Terminada);
    }

    // --- Paso 7: tiradas no válidas ---

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData(-1)]
    [InlineData(11)]
    public void Tirar_ConUnNumeroDeBolosNoValido_LanzaArgumentOutOfRangeException(int bolos)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _partida.Tirar(bolos));
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Tirar_ConLaPartidaTerminada_LanzaInvalidOperationException()
    {
        TirarVarias(20, 1);

        Assert.Throws<InvalidOperationException>(() => _partida.Tirar(1));
    }

    private void Tirar(params int[] tiradas)
    {
        foreach (var bolos in tiradas)
        {
            _partida.Tirar(bolos);
        }
    }

    private void TirarVarias(int veces, int bolos)
    {
        for (var i = 0; i < veces; i++)
        {
            _partida.Tirar(bolos);
        }
    }
}
