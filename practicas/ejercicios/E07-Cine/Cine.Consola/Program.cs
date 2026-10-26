using System.Text;
using Cine.Logica;

Console.OutputEncoding = Encoding.UTF8;

// Escribe aquí el menú (ver el apartado «El menú» del enunciado)
var sala = new SalaCine(filas: 4, columnas: 6);
Console.WriteLine($"🎬 Reservas del cine · libres: {sala.Libres}");
