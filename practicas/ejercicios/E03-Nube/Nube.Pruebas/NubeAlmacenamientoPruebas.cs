using Nube.Logica;

namespace Nube.Pruebas;

public class NubeAlmacenamientoPruebas
{
    [Fact]
    public void Subir_ConEspacio_GuardaElArchivoYOcupaSuTamano()
    {
        var nube = new NubeAlmacenamiento(100);

        nube.Subir(new Documento("a.pdf", 10, 3));

        Assert.Single(nube.Archivos);
        Assert.Equal(10, nube.OcupadoMb);
        Assert.Equal(90, nube.LibreMb);
    }

    [Fact]
    public void Subir_SinEspacio_LanzaEspacioInsuficienteYNoLoGuarda()
    {
        var nube = new NubeAlmacenamiento(100);
        nube.Subir(new Video("a.mp4", 80, TimeSpan.FromMinutes(1)));

        var ex = Assert.Throws<EspacioInsuficienteException>(() => nube.Subir(new Video("b.mp4", 30, TimeSpan.FromMinutes(1))));

        Assert.Equal(20, ex.LibreMb);
        Assert.Single(nube.Archivos);
    }

    [Fact]
    public void Subir_ConUnNombreRepetido_LanzaInvalidOperation()
    {
        var nube = new NubeAlmacenamiento();
        nube.Subir(new Imagen("foto.png", 1, 10, 10));

        Assert.Throws<InvalidOperationException>(() => nube.Subir(new Imagen("FOTO.png", 1, 10, 10)));
    }

    [Fact]
    public void Constructor_SinCapacidad_Tiene500Mb()
    {
        Assert.Equal(500, new NubeAlmacenamiento().CapacidadMb);
    }

    [Fact]
    public void Buscar_NoDistingueMayusculas()
    {
        var nube = new NubeAlmacenamiento();
        var doc = new Documento("Memoria.pdf", 1, 1);
        nube.Subir(doc);

        Assert.Same(doc, nube.Buscar("memoria.PDF"));
        Assert.Null(nube.Buscar("otro.pdf"));
    }

    [Fact]
    public void Eliminar_DevuelveSiExistiaYLiberaEspacio()
    {
        var nube = new NubeAlmacenamiento(100);
        nube.Subir(new Documento("a.pdf", 10, 3));

        Assert.True(nube.Eliminar("a.pdf"));
        Assert.False(nube.Eliminar("a.pdf"));
        Assert.Equal(100, nube.LibreMb);
    }

    [Fact]
    public void Previsualizaciones_SoloIncluyeLosArchivosPrevisualizables()
    {
        var nube = new NubeAlmacenamiento();
        nube.Subir(new Documento("a.pdf", 1, 12));
        nube.Subir(new Video("b.mp4", 1, TimeSpan.FromSeconds(30)));
        nube.Subir(new Imagen("c.png", 1, 640, 480));

        Assert.Equal(["a.pdf: 12 páginas", "c.png: 640×480 px"], nube.Previsualizaciones());
    }

    [Fact]
    public void Polimorfismo_CadaTipoDeArchivoTieneSuTipoEIcono()
    {
        Archivo documento = new Documento("a.pdf", 1, 1);
        Archivo imagen = new Imagen("b.png", 1, 1, 1);
        Archivo video = new Video("c.mp4", 1, TimeSpan.Zero);

        Assert.Equal(("documento", "📄"), (documento.Tipo, documento.Icono));
        Assert.Equal(("imagen", "🖼️"), (imagen.Tipo, imagen.Icono));
        Assert.Equal(("vídeo", "🎬"), (video.Tipo, video.Icono));
    }

    [Theory]
    [InlineData("", 1)]
    [InlineData("a.pdf", 0)]
    public void Documento_ConDatosNoValidos_LanzaExcepcion(string nombre, double tamano)
    {
        Assert.ThrowsAny<ArgumentException>(() => new Documento(nombre, tamano, 1));
    }

    [Fact]
    public void Video_ToStringAnadeLaDuracion()
    {
        var video = new Video("c.mp4", 120, TimeSpan.FromSeconds(330));

        Assert.EndsWith("05:30", video.ToString());
    }
}
