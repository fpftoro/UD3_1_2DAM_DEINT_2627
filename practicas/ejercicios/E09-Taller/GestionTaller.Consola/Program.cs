using System.Globalization;
using System.Text;
using GestionTaller.Logica;

Console.OutputEncoding = Encoding.UTF8;
CultureInfo.CurrentCulture = new CultureInfo("es-ES");

var taller = new Taller();
Console.WriteLine($"🚗 Entra 1234 BCD: {taller.Agregar(new Coche("1234 BCD", "Seat"))}");
Console.WriteLine($"🚗 Entra 5678 FGH: {taller.Agregar(new Coche("5678fgh", "Renault"))}");
Console.WriteLine($"🚗 Entra 9012 JKL: {taller.Agregar(new Coche("9012JKL", "Kia"))}");
Console.WriteLine($"🚗 Entra 1234bcd otra vez: {taller.Agregar(new Coche("1234bcd", "Seat"))}");

taller.EmpezarReparacion("1234BCD");
taller.Reparar("1234 bcd", 2.5m);
taller.EmpezarReparacion("5678FGH");

Console.WriteLine($"🔧 Pendientes: {taller.Pendientes}");
Console.WriteLine($"🔎 Buscar 5678 fgh: {taller.Buscar("5678 fgh")?.ToString() ?? "no está"}");
Console.WriteLine($"🧾 Factura de 1234BCD: {taller.CalcularFactura("1234BCD"):N2} €");
Console.WriteLine($"🗑️ Sale 9012JKL (el último): {taller.Eliminar("9012JKL")}");
Console.WriteLine($"📋 Quedan {taller.Coches.Count} coches:");
foreach (var coche in taller.Coches)
{
    Console.WriteLine($"   {coche}");
}
