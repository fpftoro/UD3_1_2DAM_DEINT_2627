using System.Globalization;
using System.Text;
using Facturas.Consola;
using Facturas.Logica;

Console.OutputEncoding = Encoding.UTF8;
CultureInfo.CurrentCulture = new CultureInfo("es-ES");

var retardo = TimeSpan.FromMilliseconds(100);

Console.WriteLine("📥 Importando 5 facturas…");
var importador = new ImportadorFacturas(new OrigenSimulado(5, retardo));
var resultado = await importador.ImportarAsync(new ProgresoConsola());
Console.WriteLine($"✅ {resultado.Facturas.Count} facturas · total: {resultado.ImporteTotal:N2} €");

Console.WriteLine("📥 Importando 8 facturas y cancelando al llegar al 50 %…");
using (var cancelacion = new CancellationTokenSource())
{
    try
    {
        var importador8 = new ImportadorFacturas(new OrigenSimulado(8, retardo));
        await importador8.ImportarAsync(new ProgresoConsola(cancelacion, 50), cancelacion.Token);
        Console.WriteLine("⚠️ No se ha cancelado");
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("⛔ Importación cancelada");
    }
}

Console.WriteLine("📥 Importando 5 facturas, con la 3 dañada…");
try
{
    await new ImportadorFacturas(new OrigenSimulado(5, retardo, facturaDanada: 3)).ImportarAsync(new ProgresoConsola());
}
catch (InvalidDataException ex)
{
    Console.WriteLine($"❌ {ex.Message}");
}

Console.WriteLine("⚡ Importando 20 facturas en paralelo…");
var paralelo = await new ImportadorFacturas(new OrigenSimulado(20, retardo)).ImportarEnParaleloAsync();
Console.WriteLine($"✅ {paralelo.Facturas.Count} facturas · primera: {paralelo.Facturas[0].Concepto} · última: {paralelo.Facturas[^1].Concepto} · total: {paralelo.ImporteTotal:N2} €");
