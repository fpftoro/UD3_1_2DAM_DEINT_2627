using Notas.Logica;

namespace Notas.Pruebas;

public class ConsultasAlumnosPruebas
{
    private static readonly List<Alumno> _alumnos =
    [
        new("Carla", "A", 20, [10, 8]),
        new("Bruno", "B", 17, [4, 4]),
        new("Alba", "A", 16, [6, 7]),
        new("Dani", "B", 19, [9, 10]),
    ];

    [Fact]
    public void Media_DeUnAlumno_EsLaMediaDeSusNotas()
    {
        Assert.Equal(9, _alumnos[0].Media);
        Assert.Equal(0, new Alumno("X", "A", 20, []).Media);
    }

    [Fact]
    public void Aprobados_DevuelveLosAprobadosPorOrdenAlfabetico()
    {
        var consultas = new ConsultasAlumnos(_alumnos);

        var nombres = consultas.Aprobados().Select(a => a.Nombre);

        Assert.Equal(["Alba", "Carla", "Dani"], nombres);
    }

    [Fact]
    public void Mejores_OrdenaPorMediaYDesempataPorNombre()
    {
        var consultas = new ConsultasAlumnos(_alumnos);

        var nombres = consultas.Mejores(2).Select(a => a.Nombre);

        Assert.Equal(["Dani", "Carla"], nombres);
    }

    [Fact]
    public void Mejores_ConMasCantidadQueAlumnos_DevuelveTodos()
    {
        Assert.Equal(4, new ConsultasAlumnos(_alumnos).Mejores(10).Count);
    }

    [Fact]
    public void BuscarPorNombre_NoDistingueMayusculas()
    {
        var consultas = new ConsultasAlumnos(_alumnos);

        Assert.Equal(["Alba", "Bruno"], consultas.BuscarPorNombre("B"));
        Assert.Equal(["Carla"], consultas.BuscarPorNombre(" AR "));
        Assert.Empty(consultas.BuscarPorNombre("zz"));
    }

    [Fact]
    public void ResumenPorCurso_AgrupaYCalculaLosDatosDeCadaCurso()
    {
        var consultas = new ConsultasAlumnos(_alumnos);

        var resumen = consultas.ResumenPorCurso();

        Assert.Equal(
            [new ResumenCurso("A", 2, 7.75, 2), new ResumenCurso("B", 2, 6.75, 1)],
            resumen);
    }

    [Fact]
    public void MediaGeneral_SinAlumnos_EsCero()
    {
        Assert.Equal(0, new ConsultasAlumnos([]).MediaGeneral());
        Assert.Equal(7.25, new ConsultasAlumnos(_alumnos).MediaGeneral());
    }

    [Fact]
    public void HayNotasPorDebajoDe_MiraTodasLasNotasDeTodosLosAlumnos()
    {
        var consultas = new ConsultasAlumnos(_alumnos);

        Assert.True(consultas.HayNotasPorDebajoDe(5));
        Assert.False(consultas.HayNotasPorDebajoDe(4));
    }

    [Fact]
    public void MenoresDeEdad_FiltraPorCursoYEdad()
    {
        var consultas = new ConsultasAlumnos(_alumnos);

        Assert.Equal([("Alba", 16)], consultas.MenoresDeEdad("a"));
    }

    [Fact]
    public void Consultas_NoModificanLaListaOriginal()
    {
        var lista = new List<Alumno>(_alumnos);
        var consultas = new ConsultasAlumnos(lista);

        consultas.Mejores(4);
        lista.Clear();

        Assert.Equal(4, consultas.Mejores(4).Count);
    }
}

public class CargadorAlumnosPruebas
{
    [Fact]
    public void DesdeTexto_LeeLasPropiedadesEnCamelCase()
    {
        var json = """[ { "nombre": "Ana", "curso": "2DAM", "edad": 20, "notas": [5, 7] } ]""";

        var alumno = Assert.Single(CargadorAlumnos.DesdeTexto(json));

        Assert.Equal("Ana", alumno.Nombre);
        Assert.Equal("2DAM", alumno.Curso);
        Assert.Equal(6, alumno.Media);
    }

    [Fact]
    public void DesdeTexto_ConJsonNoValido_LanzaJsonException()
    {
        Assert.ThrowsAny<System.Text.Json.JsonException>(() => CargadorAlumnos.DesdeTexto("{ esto no es json"));
    }
}
