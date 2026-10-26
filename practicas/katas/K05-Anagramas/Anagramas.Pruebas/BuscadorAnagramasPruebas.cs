using Anagramas.Logica;

namespace Anagramas.Pruebas;

public class BuscadorAnagramasPruebas
{
    // --- Paso 1: dos palabras ---

    [Theory]
    [InlineData("listen", "silent")]
    [InlineData("amor", "mora")]
    [InlineData("sal", "las")]
    public void SonAnagramas_ConLasMismasLetrasEnOtroOrden_EsTrue(string primero, string segundo)
    {
        Assert.True(BuscadorAnagramas.SonAnagramas(primero, segundo));
    }

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData("casa", "cosa")]
    [InlineData("sal", "sala")]
    [InlineData("aab", "abb")]
    public void SonAnagramas_ConLetrasDistintas_EsFalse(string primero, string segundo)
    {
        Assert.False(BuscadorAnagramas.SonAnagramas(primero, segundo));
    }

    // --- Paso 2: mayúsculas, espacios y signos no cuentan ---

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData("Roma", "AMOR")]
    [InlineData("Dormitory", "dirty room")]
    [InlineData("Eleven plus two", "Twelve plus one!")]
    public void SonAnagramas_IgnoraMayusculasEspaciosYSignos(string primero, string segundo)
    {
        Assert.True(BuscadorAnagramas.SonAnagramas(primero, segundo));
    }

    // --- Paso 3: una palabra no es anagrama de sí misma ---

    [Theory(Skip = "Quita el Skip cuando llegue su turno")]
    [InlineData("Roma", "roma")]
    [InlineData("sal", "s a l")]
    public void SonAnagramas_ConLaMismaPalabra_EsFalse(string primero, string segundo)
    {
        Assert.False(BuscadorAnagramas.SonAnagramas(primero, segundo));
    }

    // --- Paso 4: buscar en una lista ---

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Buscar_DevuelveSoloLosAnagramasEnSuOrden()
    {
        var resultado = BuscadorAnagramas.Buscar("listen", ["enlists", "google", "inlets", "banana", "silent", "LISTEN"]);

        Assert.Equal(["inlets", "silent"], resultado);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Buscar_SinNingunAnagrama_DevuelveUnaListaVacia()
    {
        Assert.Empty(BuscadorAnagramas.Buscar("casa", ["perro", "gato"]));
    }

    // --- Paso 5: agrupar ---

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Agrupar_JuntaLasPalabrasQueSonAnagramasEntreSi()
    {
        var grupos = BuscadorAnagramas.Agrupar(["listen", "google", "silent", "gogole", "casa", "enlist"]);

        Assert.Equal(2, grupos.Count);
        Assert.Equal(["listen", "silent", "enlist"], grupos[0]);
        Assert.Equal(["google", "gogole"], grupos[1]);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Agrupar_DescartaLasPalabrasSinAnagramas()
    {
        Assert.Empty(BuscadorAnagramas.Agrupar(["casa", "perro", "gato"]));
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Agrupar_CuentaUnaSolaVezLasPalabrasRepetidas()
    {
        var grupos = BuscadorAnagramas.Agrupar(["Roma", "roma", "amor", "ROMA"]);

        var grupo = Assert.Single(grupos);
        Assert.Equal(["Roma", "amor"], grupo);
    }

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Agrupar_ConUnaListaVacia_DevuelveNingunGrupo()
    {
        Assert.Empty(BuscadorAnagramas.Agrupar([]));
    }

    // --- Paso 6: argumentos nulos ---

    [Fact(Skip = "Quita el Skip cuando llegue su turno")]
    public void Metodos_ConArgumentosNulos_LanzanArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => BuscadorAnagramas.SonAnagramas(null!, "a"));
        Assert.Throws<ArgumentNullException>(() => BuscadorAnagramas.SonAnagramas("a", null!));
        Assert.Throws<ArgumentNullException>(() => BuscadorAnagramas.Buscar(null!, []));
        Assert.Throws<ArgumentNullException>(() => BuscadorAnagramas.Buscar("a", null!));
        Assert.Throws<ArgumentNullException>(() => BuscadorAnagramas.Agrupar(null!));
    }
}
