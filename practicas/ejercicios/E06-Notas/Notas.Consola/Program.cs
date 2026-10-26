using System.Globalization;
using System.Text;
using Notas.Logica;

Console.OutputEncoding = Encoding.UTF8;
CultureInfo.CurrentCulture = new CultureInfo("es-ES");

// AppContext.BaseDirectory es la carpeta del ejecutable, donde se copia alumnos.json
var ruta = Path.Combine(AppContext.BaseDirectory, "alumnos.json");
var alumnos = CargadorAlumnos.DesdeFichero(ruta);
var consultas = new ConsultasAlumnos(alumnos);

Console.WriteLine($"📂 {alumnos.Count} alumnos cargados · media general: {consultas.MediaGeneral():F2}");

Console.WriteLine("✅ Aprobados:");
foreach (var alumno in consultas.Aprobados())
{
    Console.WriteLine($"   {alumno.Nombre,-14} {alumno.Curso,-5} {alumno.Media,5:F2}");
}

Console.WriteLine("🏆 Los tres mejores:");
var posicion = 1;
foreach (var alumno in consultas.Mejores(3))
{
    Console.WriteLine($"   {posicion++}. {alumno.Nombre} ({alumno.Media:F2})");
}

Console.WriteLine("📊 Resumen por curso:");
foreach (var resumen in consultas.ResumenPorCurso())
{
    Console.WriteLine($"   {resumen.Curso,-5} {resumen.Alumnos} alumnos · media {resumen.Media:F2} · aprobados {resumen.Aprobados}");
}

Console.WriteLine($"🔎 Nombres con «ar»: {string.Join(", ", consultas.BuscarPorNombre("ar"))}");
Console.WriteLine($"⚠️ ¿Alguna nota por debajo de 3? {(consultas.HayNotasPorDebajoDe(3) ? "Sí" : "No")}");

var menores = consultas.MenoresDeEdad("1dam");
Console.WriteLine($"🧒 Menores de edad en 1DAM: {string.Join(", ", menores.Select(m => $"{m.Nombre} ({m.Edad})"))}");
