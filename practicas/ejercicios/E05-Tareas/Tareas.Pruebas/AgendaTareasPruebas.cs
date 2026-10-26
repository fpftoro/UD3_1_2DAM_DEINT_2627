using Tareas.Logica;

namespace Tareas.Pruebas;

public class TareaPruebas
{
    [Fact]
    public void Completada_AlCambiar_LanzaElEventoConLaTareaComoSender()
    {
        var tarea = new Tarea("Estudiar");
        object? emisor = null;
        tarea.CompletadaCambiada += (sender, e) => emisor = sender;

        tarea.Completada = true;

        Assert.Same(tarea, emisor);
    }

    [Fact]
    public void Completada_ConElMismoValor_NoLanzaElEvento()
    {
        var tarea = new Tarea("Estudiar") { Completada = true };
        var avisos = 0;
        tarea.CompletadaCambiada += (sender, e) => avisos++;

        tarea.Completada = true;

        Assert.Equal(0, avisos);
    }

    [Fact]
    public void Constructor_ConTituloVacio_LanzaArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Tarea(" "));
    }

    [Fact]
    public void ToString_MuestraLaCasillaSegunElEstado()
    {
        var tarea = new Tarea("Pan");

        Assert.Equal("[ ] Pan", tarea.ToString());
        tarea.Completada = true;
        Assert.Equal("[x] Pan", tarea.ToString());
    }
}

public class AgendaTareasPruebas
{
    [Fact]
    public void Agregar_LanzaTareaAnadida()
    {
        var agenda = new AgendaTareas();
        Tarea? anadida = null;
        agenda.TareaAnadida += (sender, e) => anadida = e.Tarea;
        var tarea = new Tarea("Pan");

        agenda.Agregar(tarea);

        Assert.Same(tarea, anadida);
        Assert.Single(agenda.Tareas);
    }

    [Fact]
    public void Agregar_ConTituloRepetido_LanzaInvalidOperation()
    {
        var agenda = new AgendaTareas();
        agenda.Agregar(new Tarea("Pan"));

        Assert.Throws<InvalidOperationException>(() => agenda.Agregar(new Tarea("PAN")));
    }

    [Fact]
    public void Completar_LanzaEstadoCambiadoYActualizaPendientes()
    {
        var agenda = new AgendaTareas();
        agenda.Agregar(new Tarea("Pan"));
        agenda.Agregar(new Tarea("Leche"));
        var avisos = 0;
        agenda.EstadoCambiado += (sender, e) => avisos++;

        Assert.True(agenda.Completar("pan"));

        Assert.Equal(1, avisos);
        Assert.Equal(1, agenda.Pendientes);
    }

    [Fact]
    public void CambiarLaTareaDirectamente_TambienLanzaEstadoCambiado()
    {
        var agenda = new AgendaTareas();
        var tarea = new Tarea("Pan");
        agenda.Agregar(tarea);
        Tarea? cambiada = null;
        agenda.EstadoCambiado += (sender, e) => cambiada = e.Tarea;

        tarea.Completada = true;

        Assert.Same(tarea, cambiada);
    }

    [Fact]
    public void Eliminar_LanzaTareaEliminadaYDejaDeEscucharLaTarea()
    {
        var agenda = new AgendaTareas();
        var tarea = new Tarea("Pan");
        agenda.Agregar(tarea);
        var eliminadas = 0;
        var cambios = 0;
        agenda.TareaEliminada += (sender, e) => eliminadas++;
        agenda.EstadoCambiado += (sender, e) => cambios++;

        Assert.True(agenda.Eliminar("Pan"));
        tarea.Completada = true;

        Assert.Equal(1, eliminadas);
        Assert.Equal(0, cambios);
        Assert.Empty(agenda.Tareas);
    }

    [Fact]
    public void Completar_YEliminar_UnaTareaQueNoExiste_DevuelvenFalse()
    {
        var agenda = new AgendaTareas();

        Assert.False(agenda.Completar("Nada"));
        Assert.False(agenda.Eliminar("Nada"));
    }

    [Fact]
    public void SinSuscriptores_LasOperacionesNoFallan()
    {
        var agenda = new AgendaTareas();

        agenda.Agregar(new Tarea("Pan"));
        agenda.Completar("Pan");
        agenda.Eliminar("Pan");

        Assert.Empty(agenda.Tareas);
    }
}
