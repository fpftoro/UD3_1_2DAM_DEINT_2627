using System.Text;
using Tareas.Logica;

Console.OutputEncoding = Encoding.UTF8;

var agenda = new AgendaTareas();

// Primer suscriptor: un registro de todo lo que pasa
agenda.TareaAnadida += (sender, e) => Console.WriteLine($"📢 Añadida: {e.Tarea.Titulo}");
agenda.TareaEliminada += (sender, e) => Console.WriteLine($"📢 Eliminada: {e.Tarea.Titulo}");
agenda.EstadoCambiado += (sender, e) => Console.WriteLine($"📢 Cambio de estado: {e.Tarea}");

// Segundo suscriptor: un contador de pendientes que se actualiza solo
agenda.TareaAnadida += MostrarPendientes;
agenda.TareaEliminada += MostrarPendientes;
agenda.EstadoCambiado += MostrarPendientes;

agenda.Agregar(new Tarea("Instalar Visual Studio"));
agenda.Agregar(new Tarea("Estudiar eventos"));
var ejercicio = new Tarea("Hacer el E05");
agenda.Agregar(ejercicio);

agenda.Completar("instalar visual studio");
agenda.Completar("Instalar Visual Studio");   // ya estaba completada: no avisa
ejercicio.Completada = true;                  // cambiada desde la tarea: la agenda también avisa

try
{
    agenda.Agregar(new Tarea("Estudiar EVENTOS"));
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"❌ {ex.Message}");
}

agenda.Eliminar("Hacer el E05");
ejercicio.Completada = false;                 // ya no es de la agenda: nadie avisa

agenda.EstadoCambiado -= MostrarPendientes;   // el contador deja de escuchar los cambios de estado
agenda.Completar("Estudiar eventos");

Console.WriteLine("📋 Tareas:");
foreach (var tarea in agenda.Tareas)
{
    Console.WriteLine($"   {tarea}");
}

static void MostrarPendientes(object? sender, TareaEventArgs e)
{
    if (sender is AgendaTareas agenda)
    {
        Console.WriteLine($"   🔢 Pendientes: {agenda.Pendientes}");
    }
}
