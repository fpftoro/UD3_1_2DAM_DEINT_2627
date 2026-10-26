using System.Globalization;
using System.Text;
using Banco.Logica;

Console.OutputEncoding = Encoding.UTF8;
CultureInfo.CurrentCulture = new CultureInfo("es-ES");

var ana = new CuentaBancaria("  Ana López ", 100);
var luis = new CuentaBancaria("Luis Pérez");

ana.Ingresar(50);
luis.Ingresar(20);
ana.Transferir(luis, 30.5m);

Console.WriteLine($"🏦 {ana}");
Console.WriteLine($"🏦 {luis}");

Probar("Retirar 500 € de Ana", () => ana.Retirar(500));
Probar("Ingresar -5 € en Ana", () => ana.Ingresar(-5));
Probar("Abrir una cuenta sin titular", () => new CuentaBancaria("   "));
Probar("Transferir de Ana a Ana", () => ana.Transferir(ana, 10));

Console.WriteLine("📄 Extracto de Ana:");
foreach (var movimiento in ana.Movimientos)
{
    Console.WriteLine($"   {movimiento.Concepto,-25} {movimiento.Importe,10:N2} € → {movimiento.SaldoResultante,10:N2} €");
}

Console.WriteLine($"🔢 Cuentas abiertas: {CuentaBancaria.CuentasAbiertas}");

// Ejecuta una operación que debe fallar y muestra qué excepción lanza
static void Probar(string descripcion, Action operacion)
{
    try
    {
        operacion();
        Console.WriteLine($"⚠️ {descripcion}: no ha fallado");
    }
    catch (SaldoInsuficienteException ex)
    {
        Console.WriteLine($"❌ {descripcion}: {ex.Message}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"❌ {descripcion}: {ex.GetType().Name} ({ex.ParamName})");
    }
}
