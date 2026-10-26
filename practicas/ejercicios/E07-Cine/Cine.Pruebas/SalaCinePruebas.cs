using Cine.Logica;

namespace Cine.Pruebas;

public class SalaCinePruebas
{
    [Fact]
    public void Constructor_PorDefecto_Tiene5FilasY8Columnas()
    {
        var sala = new SalaCine();

        Assert.Equal(5, sala.Filas);
        Assert.Equal(8, sala.Columnas);
        Assert.Equal(40, sala.Libres);
    }

    [Theory]
    [InlineData(0, 8)]
    [InlineData(27, 8)]
    [InlineData(5, 0)]
    public void Constructor_ConDimensionesNoValidas_LanzaExcepcion(int filas, int columnas)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SalaCine(filas, columnas));
    }

    [Fact]
    public void Reservar_UnAsientoLibre_LoReservaYLanzaElEvento()
    {
        var sala = new SalaCine();
        IReadOnlyList<Asiento>? avisados = null;
        sala.AsientosReservados += (sender, e) => avisados = e.Asientos;

        Assert.True(sala.Reservar(2, 3));

        Assert.True(sala.ObtenerAsiento(2, 3).Reservado);
        Assert.Equal("B3", Assert.Single(avisados!).Codigo);
        Assert.Equal(39, sala.Libres);
    }

    [Fact]
    public void Reservar_UnAsientoReservado_DevuelveFalse()
    {
        var sala = new SalaCine();
        sala.Reservar(1, 1);

        Assert.False(sala.Reservar(1, 1));
    }

    [Fact]
    public void Reservar_FueraDeLaSala_LanzaExcepcion()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SalaCine(5, 8).Reservar(6, 1));
    }

    [Fact]
    public void Cancelar_LiberaElAsientoSoloSiEstabaReservado()
    {
        var sala = new SalaCine();
        sala.Reservar(1, 1);

        Assert.True(sala.Cancelar(1, 1));
        Assert.False(sala.Cancelar(1, 1));
        Assert.Equal(40, sala.Libres);
    }

    [Fact]
    public void ReservarGrupo_BuscaElPrimerHuecoSeguidoDesdeLaFilaA()
    {
        var sala = new SalaCine(3, 5);
        sala.Reservar(1, 3);

        var grupo = sala.ReservarGrupo(3);

        Assert.NotNull(grupo);
        Assert.Equal(["B1", "B2", "B3"], grupo.Select(a => a.Codigo));
    }

    [Fact]
    public void ReservarGrupo_SinHuecoSuficiente_DevuelveNullYNoReservaNada()
    {
        var sala = new SalaCine(1, 4);
        sala.Reservar(1, 2);

        Assert.Null(sala.ReservarGrupo(3));
        Assert.Equal(3, sala.Libres);
    }

    [Fact]
    public void ReservarGrupo_LanzaUnSoloEventoConTodosLosAsientos()
    {
        var sala = new SalaCine(2, 4);
        var eventos = 0;
        sala.AsientosReservados += (sender, e) => eventos++;

        sala.ReservarGrupo(4);

        Assert.Equal(1, eventos);
    }

    [Theory]
    [InlineData("C5", true, 3, 5)]
    [InlineData(" a10 ", true, 1, 10)]
    [InlineData("5C", false, 0, 0)]
    [InlineData("C", false, 0, 0)]
    [InlineData("C0", false, 0, 0)]
    [InlineData(null, false, 0, 0)]
    public void TryParseCodigo_ReconoceElFormato(string? codigo, bool valido, int filaEsperada, int columnaEsperada)
    {
        var resultado = SalaCine.TryParseCodigo(codigo, out var fila, out var columna);

        Assert.Equal((valido, filaEsperada, columnaEsperada), (resultado, fila, columna));
    }

    [Fact]
    public void Mapa_DibujaLibresYReservados()
    {
        var sala = new SalaCine(2, 3);
        sala.Reservar(2, 2);

        var lineas = sala.Mapa().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        Assert.Equal(["    1 2 3", " A  ○ ○ ○", " B  ○ ● ○"], lineas);
    }
}
