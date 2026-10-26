using Limitador.Logica;

namespace Limitador.Pruebas;

public class LimitadorPeticionesPruebas
{
    private static readonly TimeSpan _diezSegundos = TimeSpan.FromSeconds(10);

    private readonly RelojFalso _reloj = new();

    // --- Paso 1: crear el limitador ---

    [Theory]
    [InlineData(0, 10)]
    [InlineData(-1, 10)]
    [InlineData(3, 0)]
    [InlineData(3, -5)]
    public void Constructor_ConUnMaximoOUnaVentanaNoValidos_LanzaArgumentOutOfRangeException(int maximo, int segundos)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new LimitadorPeticiones(maximo, TimeSpan.FromSeconds(segundos)));
    }

    // --- Paso 2: aceptar hasta el máximo ---

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Intentar_HastaElMaximo_AceptaLasPeticiones()
    {
        var limitador = new LimitadorPeticiones(3, _diezSegundos, _reloj);

        Assert.True(limitador.Intentar());
        Assert.True(limitador.Intentar());
        Assert.True(limitador.Intentar());
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Intentar_SuperadoElMaximo_RechazaLaPeticion()
    {
        var limitador = new LimitadorPeticiones(2, _diezSegundos, _reloj);
        limitador.Intentar();
        limitador.Intentar();

        Assert.False(limitador.Intentar());
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Disponibles_VaBajandoConCadaPeticionAceptada()
    {
        var limitador = new LimitadorPeticiones(3, _diezSegundos, _reloj);
        Assert.Equal(3, limitador.Disponibles);

        limitador.Intentar();
        limitador.Intentar();

        Assert.Equal(1, limitador.Disponibles);
    }

    // --- Paso 3: el tiempo libera peticiones ---

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Intentar_TrasPasarLaVentana_VuelveAAceptar()
    {
        var limitador = new LimitadorPeticiones(2, _diezSegundos, _reloj);
        limitador.Intentar();
        limitador.Intentar();

        _reloj.Avanzar(_diezSegundos);

        Assert.True(limitador.Intentar());
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Intentar_AntesDeQuePaseLaVentana_SigueRechazando()
    {
        var limitador = new LimitadorPeticiones(1, _diezSegundos, _reloj);
        limitador.Intentar();

        _reloj.Avanzar(TimeSpan.FromSeconds(9.9));

        Assert.False(limitador.Intentar());
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Intentar_ConUnaVentanaDeslizante_LiberaLasPeticionesUnaAUna()
    {
        var limitador = new LimitadorPeticiones(2, _diezSegundos, _reloj);
        limitador.Intentar();                         // t = 0
        _reloj.Avanzar(TimeSpan.FromSeconds(6));
        limitador.Intentar();                         // t = 6

        _reloj.Avanzar(TimeSpan.FromSeconds(2));      // t = 8: las dos siguen contando
        Assert.False(limitador.Intentar());

        _reloj.Avanzar(TimeSpan.FromSeconds(2));      // t = 10: la de t = 0 ya no cuenta
        Assert.True(limitador.Intentar());
        Assert.False(limitador.Intentar());           // la de t = 6 y la de t = 10 sí
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Disponibles_TrasPasarLaVentana_SeRecuperan()
    {
        var limitador = new LimitadorPeticiones(3, _diezSegundos, _reloj);
        limitador.Intentar();
        limitador.Intentar();

        _reloj.Avanzar(_diezSegundos);

        Assert.Equal(3, limitador.Disponibles);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Intentar_UnaPeticionRechazada_NoCuentaParaElLimite()
    {
        var limitador = new LimitadorPeticiones(1, _diezSegundos, _reloj);
        limitador.Intentar();                         // t = 0
        _reloj.Avanzar(TimeSpan.FromSeconds(5));
        limitador.Intentar();                         // t = 5, rechazada

        _reloj.Avanzar(TimeSpan.FromSeconds(5));      // t = 10

        Assert.True(limitador.Intentar());
    }

    // --- Paso 4: el aviso de rechazo ---

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void PeticionRechazada_AlRechazar_AvisaConLaEsperaQueFalta()
    {
        var limitador = new LimitadorPeticiones(1, _diezSegundos, _reloj);
        RechazoEventArgs? aviso = null;
        limitador.PeticionRechazada += (sender, e) => aviso = e;
        limitador.Intentar();
        _reloj.Avanzar(TimeSpan.FromSeconds(4));

        limitador.Intentar();

        Assert.NotNull(aviso);
        Assert.Equal(TimeSpan.FromSeconds(6), aviso.Espera);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void PeticionRechazada_AlAceptar_NoAvisa()
    {
        var limitador = new LimitadorPeticiones(2, _diezSegundos, _reloj);
        var avisos = 0;
        limitador.PeticionRechazada += (sender, e) => avisos++;

        limitador.Intentar();
        limitador.Intentar();

        Assert.Equal(0, avisos);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void PeticionRechazada_AvisaUnaVezPorCadaRechazo()
    {
        var limitador = new LimitadorPeticiones(1, _diezSegundos, _reloj);
        var avisos = 0;
        limitador.PeticionRechazada += (sender, e) => avisos++;
        limitador.Intentar();

        limitador.Intentar();
        limitador.Intentar();
        limitador.Intentar();

        Assert.Equal(3, avisos);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void PeticionRechazada_PasaElLimitadorComoEmisor()
    {
        var limitador = new LimitadorPeticiones(1, _diezSegundos, _reloj);
        object? emisor = null;
        limitador.PeticionRechazada += (sender, e) => emisor = sender;
        limitador.Intentar();

        limitador.Intentar();

        Assert.Same(limitador, emisor);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void PeticionRechazada_TrasDarseDeBaja_YaNoAvisa()
    {
        var limitador = new LimitadorPeticiones(1, _diezSegundos, _reloj);
        var avisos = 0;
        EventHandler<RechazoEventArgs> oyente = (sender, e) => avisos++;
        limitador.PeticionRechazada += oyente;
        limitador.Intentar();
        limitador.Intentar();

        limitador.PeticionRechazada -= oyente;
        limitador.Intentar();

        Assert.Equal(1, avisos);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Intentar_SinOyentes_NoFalla()
    {
        var limitador = new LimitadorPeticiones(1, _diezSegundos, _reloj);
        limitador.Intentar();

        Assert.False(limitador.Intentar());
    }
}
