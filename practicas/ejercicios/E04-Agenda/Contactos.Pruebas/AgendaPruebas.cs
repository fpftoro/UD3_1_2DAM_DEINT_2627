using Contactos.Logica;

namespace Contactos.Pruebas;

public class AgendaPruebas
{
    [Fact]
    public void Constructor_SinCapacidad_TieneDiezHuecos()
    {
        var agenda = new Agenda();

        Assert.Equal(10, agenda.Capacidad);
        Assert.Equal(10, agenda.HuecosLibres);
    }

    [Fact]
    public void Anadir_ContactoNuevo_DevuelveAnadido()
    {
        var agenda = new Agenda(2);

        Assert.Equal(ResultadoAlta.Anadido, agenda.Anadir(new Contacto("Ana", "1")));
        Assert.Equal(1, agenda.Cantidad);
    }

    [Fact]
    public void Anadir_NombreRepetidoConOtrasMayusculas_DevuelveDuplicado()
    {
        var agenda = new Agenda(2);
        agenda.Anadir(new Contacto("Ana", "1"));

        Assert.Equal(ResultadoAlta.Duplicado, agenda.Anadir(new Contacto("ANA", "2")));
        Assert.Equal("1", agenda.BuscarTelefono("ana"));
    }

    [Fact]
    public void Anadir_ConLaAgendaLlena_DevuelveAgendaLlena()
    {
        var agenda = new Agenda(1);
        agenda.Anadir(new Contacto("Ana", "1"));

        Assert.True(agenda.EstaLlena);
        Assert.Equal(ResultadoAlta.AgendaLlena, agenda.Anadir(new Contacto("Luis", "2")));
    }

    [Fact]
    public void Eliminar_DevuelveSiExistiaYLiberaHueco()
    {
        var agenda = new Agenda(1);
        agenda.Anadir(new Contacto("Ana", "1"));

        Assert.True(agenda.Eliminar("ANA"));
        Assert.False(agenda.Eliminar("Ana"));
        Assert.Equal(1, agenda.HuecosLibres);
    }

    [Fact]
    public void BuscarTelefono_SiNoExiste_DevuelveNull()
    {
        Assert.Null(new Agenda().BuscarTelefono("Nadie"));
    }

    [Fact]
    public void Listar_DevuelveLosContactosEnOrdenAlfabetico()
    {
        var agenda = new Agenda();
        agenda.Anadir(new Contacto("Zoe", "3"));
        agenda.Anadir(new Contacto("ana", "1"));
        agenda.Anadir(new Contacto("Luis", "2"));

        var nombres = new List<string>();
        foreach (var contacto in agenda.Listar())
        {
            nombres.Add(contacto.Nombre);
        }

        Assert.Equal(["ana", "Luis", "Zoe"], nombres);
    }

    [Fact]
    public void Contacto_EsIgualAOtroConElMismoNombre()
    {
        var a = new Contacto("Ana", "1");
        var b = new Contacto("ANA ", "2");

        Assert.Equal(a, b);
        Assert.Equal(a.GetHashCode(), b.GetHashCode());
        Assert.Single(new HashSet<Contacto> { a, b });
    }
}

public class RepositorioPruebas
{
    private sealed class Producto(string codigo) : IConClave
    {
        public string Clave { get; } = codigo;
    }

    [Fact]
    public void Repositorio_FuncionaConCualquierTipoConClave()
    {
        var repositorio = new Repositorio<Producto>(2);

        Assert.True(repositorio.Anadir(new Producto("P1")));
        Assert.False(repositorio.Anadir(new Producto("p1")));
        Assert.NotNull(repositorio.Buscar("P1"));
        Assert.Equal(1, repositorio.HuecosLibres);
    }

    [Fact]
    public void Repositorio_ConCapacidadCero_LanzaExcepcion()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Repositorio<Producto>(0));
    }
}
