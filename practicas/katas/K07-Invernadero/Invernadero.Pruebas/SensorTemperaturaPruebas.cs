using Invernadero.Logica;

namespace Invernadero.Pruebas;

public class SensorTemperaturaPruebas
{
    // --- Paso 1: registrar lecturas ---

    [Fact]
    public void Registrar_GuardaLaUltimaTemperaturaYLaAlerta()
    {
        var sensor = new SensorTemperatura(30);

        sensor.Registrar(31);

        Assert.Equal(31, sensor.Ultima);
        Assert.True(sensor.Alerta);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void SensorNuevo_NoTieneLecturasNiAlerta()
    {
        var sensor = new SensorTemperatura(30);

        Assert.Null(sensor.Ultima);
        Assert.False(sensor.Alerta);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Registrar_JustoEnElUmbral_NoEsAlerta()
    {
        var sensor = new SensorTemperatura(30);

        sensor.Registrar(30);

        Assert.False(sensor.Alerta);
    }

    // --- Paso 2: avisar al superar el umbral ---

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Registrar_PorEncimaDelUmbral_LanzaUmbralSuperadoConLosDatos()
    {
        var sensor = new SensorTemperatura(30);
        var avisos = new List<TemperaturaEventArgs>();
        sensor.UmbralSuperado += (_, e) => avisos.Add(e);

        sensor.Registrar(31.5);

        var aviso = Assert.Single(avisos);
        Assert.Equal(31.5, aviso.Temperatura);
        Assert.Equal(30, aviso.Umbral);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void UmbralSuperado_ElEmisorEsElSensor()
    {
        var sensor = new SensorTemperatura(30);
        object? emisor = null;
        sensor.UmbralSuperado += (sender, _) => emisor = sender;

        sensor.Registrar(35);

        Assert.Same(sensor, emisor);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Registrar_SinOyentes_NoFalla()
    {
        var sensor = new SensorTemperatura(30);

        var excepcion = Record.Exception(() => sensor.Registrar(40));

        Assert.Null(excepcion);
    }

    // --- Paso 3: avisar solo al cruzar el umbral ---

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Registrar_VariasLecturasEnAlerta_AvisaUnaSolaVez()
    {
        var sensor = new SensorTemperatura(30);
        var avisos = 0;
        sensor.UmbralSuperado += (_, _) => avisos++;

        sensor.Registrar(31);
        sensor.Registrar(33);
        sensor.Registrar(32);

        Assert.Equal(1, avisos);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Registrar_SaleYVuelveAEntrarEnAlerta_AvisaOtraVez()
    {
        var sensor = new SensorTemperatura(30);
        var avisos = 0;
        sensor.UmbralSuperado += (_, _) => avisos++;

        sensor.Registrar(31);
        sensor.Registrar(29);
        sensor.Registrar(31);

        Assert.Equal(2, avisos);
    }

    // --- Paso 4: avisar al volver a la normalidad ---

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Registrar_DespuesDeUnaAlerta_LanzaTemperaturaNormalizada()
    {
        var sensor = new SensorTemperatura(30);
        var avisos = new List<TemperaturaEventArgs>();
        sensor.TemperaturaNormalizada += (_, e) => avisos.Add(e);

        sensor.Registrar(31);
        sensor.Registrar(30);

        var aviso = Assert.Single(avisos);
        Assert.Equal(30, aviso.Temperatura);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Registrar_SinAlertaPrevia_NoLanzaTemperaturaNormalizada()
    {
        var sensor = new SensorTemperatura(30);
        var avisos = 0;
        sensor.TemperaturaNormalizada += (_, _) => avisos++;

        sensor.Registrar(20);
        sensor.Registrar(25);

        Assert.Equal(0, avisos);
    }

    // --- Paso 5: varios suscriptores ---

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void RegistroAlertas_ApuntaLasAlertasYLaVueltaALaNormalidad()
    {
        var sensor = new SensorTemperatura(30);
        var registro = new RegistroAlertas();
        registro.Vigilar(sensor);

        sensor.Registrar(31.5);
        sensor.Registrar(28);

        Assert.Equal(["Alerta: 31,5 °C (umbral 30 °C)", "Normal: 28 °C"], registro.Entradas);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void DosSuscriptores_RecibenLosDosElAviso()
    {
        var sensor = new SensorTemperatura(30);
        var registro = new RegistroAlertas();
        registro.Vigilar(sensor);
        var ventiladorEncendido = false;
        sensor.UmbralSuperado += (_, _) => ventiladorEncendido = true;

        sensor.Registrar(35);

        Assert.Single(registro.Entradas);
        Assert.True(ventiladorEncendido);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void DejarDeVigilar_YaNoApuntaNada()
    {
        var sensor = new SensorTemperatura(30);
        var registro = new RegistroAlertas();
        registro.Vigilar(sensor);

        registro.DejarDeVigilar(sensor);
        sensor.Registrar(35);

        Assert.Empty(registro.Entradas);
    }
}
