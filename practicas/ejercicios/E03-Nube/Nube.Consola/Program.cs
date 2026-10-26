using System.Globalization;
using System.Text;
using Nube.Logica;

Console.OutputEncoding = Encoding.UTF8;
CultureInfo.CurrentCulture = new CultureInfo("es-ES");

var nube = new NubeAlmacenamiento(500);

Archivo[] archivos =
[
    new Documento("memoria.pdf", 2.5, 34),
    new Imagen("portada.png", 4.2, 1920, 1080),
    new Video("clase-csharp.mp4", 320, TimeSpan.FromMinutes(42.5)),
    new Documento("notas.docx", 0.3, 1),
    new Video("demo.mp4", 180, TimeSpan.FromSeconds(95)),
    new Imagen("PORTADA.png", 1, 800, 600),
];

foreach (var archivo in archivos)
{
    try
    {
        nube.Subir(archivo);
        Console.WriteLine($"⬆️ {archivo}");
    }
    catch (EspacioInsuficienteException ex)
    {
        Console.WriteLine($"❌ {ex.Message}");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"❌ {ex.Message}");
    }
}

Console.WriteLine($"💾 Ocupado: {nube.OcupadoMb:N1} de {nube.CapacidadMb:N0} MB · libre: {nube.LibreMb:N1} MB");

Console.WriteLine("👀 Vistas previas:");
foreach (var linea in nube.Previsualizaciones())
{
    Console.WriteLine($"   {linea}");
}

Console.WriteLine($"🔎 Buscar «Notas.DOCX»: {nube.Buscar("Notas.DOCX")?.ToString() ?? "no existe"}");
Console.WriteLine($"🗑️ Eliminar clase-csharp.mp4: {nube.Eliminar("clase-csharp.mp4")}");
Console.WriteLine($"🗑️ Eliminar clase-csharp.mp4 otra vez: {nube.Eliminar("clase-csharp.mp4")}");
Console.WriteLine($"💾 Libre: {nube.LibreMb:N1} MB");
