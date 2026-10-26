using System.Globalization;
using System.Text;
using Contactos.Logica;

Console.OutputEncoding = Encoding.UTF8;
CultureInfo.CurrentCulture = new CultureInfo("es-ES");

var agenda = new Agenda(4);

Contacto[] nuevos =
[
    new("Luis Pérez", "600 222 333"),
    new("ana lópez", "600 111 222"),
    new("Marta Ruiz", "611 444 555"),
    new("ANA LÓPEZ", "699 999 999"),
    new("Óscar Gil", "622 777 888"),
    new("Zoe Martín", "633 000 111"),
];

foreach (var contacto in nuevos)
{
    var resultado = agenda.Anadir(contacto);
    var icono = resultado == ResultadoAlta.Anadido ? "✅" : "❌";
    Console.WriteLine($"{icono} {contacto}: {resultado}");
}

Console.WriteLine($"📒 {agenda.Cantidad} de {agenda.Capacidad} contactos · llena: {agenda.EstaLlena} · huecos: {agenda.HuecosLibres}");
foreach (var contacto in agenda.Listar())
{
    Console.WriteLine($"   {contacto}");
}

Console.WriteLine($"🔎 Teléfono de «ANA LÓPEZ»: {agenda.BuscarTelefono("ANA LÓPEZ") ?? "no existe"}");
Console.WriteLine($"🔎 Teléfono de «Pedro»: {agenda.BuscarTelefono("Pedro") ?? "no existe"}");
Console.WriteLine($"🗑️ Eliminar «luis pérez»: {agenda.Eliminar("luis pérez")}");
Console.WriteLine($"➕ Añadir a Zoe otra vez: {agenda.Anadir(new Contacto("Zoe Martín", "633 000 111"))}");

// La igualdad de Contacto también la usan las colecciones de .NET
var conjunto = new HashSet<Contacto> { new("Eva", "1"), new("EVA", "2"), new("Eva ", "3") };
Console.WriteLine($"🧮 Contactos distintos en el HashSet: {conjunto.Count}");
