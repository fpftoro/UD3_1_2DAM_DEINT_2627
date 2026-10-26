using GestionTaller.Logica;

namespace GestionTaller.Pruebas;

public class TallerPruebas
{
    [Fact]
    public void Coche_NormalizaLaMatricula()
    {
        var coche = new Coche("1234 bcd", "Seat");

        Assert.Equal("1234BCD", coche.Matricula);
    }

    [Theory]
    [InlineData("123BCD")]
    [InlineData("1234BC1")]
    [InlineData("ABCD123")]
    public void Coche_ConMatriculaNoValida_LanzaArgumentException(string matricula)
    {
        Assert.Throws<ArgumentException>(() => new Coche(matricula, "Seat"));
    }

    [Fact]
    public void Agregar_UnCocheNuevo_LoAnade()
    {
        var taller = new Taller();

        Assert.True(taller.Agregar(new Coche("1234BCD", "Seat")));
        Assert.Single(taller.Coches);
    }

    [Fact]
    public void Reparar_UnCocheQueNoEstaEnReparacion_LanzaInvalidOperation()
    {
        var taller = new Taller();
        taller.Agregar(new Coche("1234BCD", "Seat"));

        Assert.Throws<InvalidOperationException>(() => taller.Reparar("1234BCD", 1));
    }

    [Fact]
    public void CalcularFactura_DeUnCocheSinReparar_LanzaInvalidOperation()
    {
        var taller = new Taller();
        taller.Agregar(new Coche("1234BCD", "Seat"));

        Assert.Throws<InvalidOperationException>(() => taller.CalcularFactura("1234BCD"));
    }

    // --- Escribe aquí tus pruebas: una por cada fallo, antes de corregirlo ---
}
