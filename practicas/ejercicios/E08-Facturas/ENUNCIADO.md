# E08 · Importación lenta de facturas

**Tipo:** autocorrección

Completa un importador que lee facturas de un servidor lento **sin bloquear** a quien lo llama: informa del progreso, se puede cancelar a mitad, propaga los errores de lectura y sabe leer también todas las facturas a la vez.

**CE:** — (formativo; prepara el RA1: aplicaciones que no se congelan) · **Dificultad:** ★★★ · **Tiempo estimado:** 2,5 h · **Tema:** 11

## Punto de partida

- `Facturas.Logica`: `Factura`, `ResultadoImportacion` e `IOrigenFacturas` ya están hechos. `OrigenSimulado` e `ImportadorFacturas` tienen las firmas y la documentación, sin implementar (y sin `async`: añádelo tú).
- `Facturas.Consola`: `ProgresoConsola.cs` (dibuja la barra y cancela al llegar a un porcentaje) y `Program.cs`. **No los modifiques.**
- `Facturas.Pruebas/ImportadorFacturasPruebas.cs`: **no lo modifiques**.

## Requisitos

### `OrigenSimulado : IOrigenFacturas`

Constructor primario `(int total, TimeSpan retardo, int? facturaDanada = null)`.

`Task<Factura> LeerAsync(int numero, CancellationToken cancelacion = default)`:

1. Lanza `ArgumentOutOfRangeException` si el número no está entre 1 y `Total`.
2. Espera el retardo con `await Task.Delay(retardo, cancelacion)`: así, si se cancela durante la espera, la espera se interrumpe.
3. Si el número es el de la factura dañada, lanza `InvalidDataException("La factura <n> está dañada")`.
4. Devuelve `new Factura(numero, "Servicio <número con tres cifras>", numero * 12.5m)`.

### `ImportadorFacturas`

Constructor primario con un `IOrigenFacturas`. El importador no sabe si las facturas vienen de una simulación o de un servidor real.

`Task<ResultadoImportacion> ImportarAsync(IProgress<int>? progreso = null, CancellationToken cancelacion = default)`:

1. Lee las facturas **una a una**, en orden, con `await`.
2. Antes de cada lectura, llama a `cancelacion.ThrowIfCancellationRequested()`.
3. Después de cada lectura, informa del porcentaje completado (`numero * 100 / Total`) con `progreso?.Report(…)`.
4. Devuelve las facturas y la suma de sus importes.

`Task<ResultadoImportacion> ImportarEnParaleloAsync(CancellationToken cancelacion = default)`:

1. Lanza **todas** las lecturas sin esperar (guarda las `Task<Factura>` en una lista).
2. Espera a todas con `await Task.WhenAll(…)` y devuelve el resultado, en orden de número.

## Comprueba tu solución

1. Todas las pruebas en verde. Fíjate en que las pruebas son métodos `async Task` y usan `Assert.ThrowsAsync`.
2. `Facturas.Consola` muestra exactamente:

   ```text
   📥 Importando 5 facturas…
      ▓▓░░░░░░░░  20 %
      ▓▓▓▓░░░░░░  40 %
      ▓▓▓▓▓▓░░░░  60 %
      ▓▓▓▓▓▓▓▓░░  80 %
      ▓▓▓▓▓▓▓▓▓▓ 100 %
   ✅ 5 facturas · total: 187,50 €
   📥 Importando 8 facturas y cancelando al llegar al 50 %…
      ▓░░░░░░░░░  12 %
      ▓▓░░░░░░░░  25 %
      ▓▓▓░░░░░░░  37 %
      ▓▓▓▓▓░░░░░  50 %
   ⛔ Importación cancelada
   📥 Importando 5 facturas, con la 3 dañada…
      ▓▓░░░░░░░░  20 %
      ▓▓▓▓░░░░░░  40 %
   ❌ La factura 3 está dañada
   ⚡ Importando 20 facturas en paralelo…
   ✅ 20 facturas · primera: Servicio 001 · última: Servicio 020 · total: 2.625,00 €
   ```

3. Mide cuánto tarda cada importación de 20 facturas con un `Stopwatch` (en una copia de `Program.cs`): ¿cuánto tarda una a una y cuánto en paralelo? ¿Por qué?
4. Cambia temporalmente `await origen.LeerAsync(…)` por `origen.LeerAsync(…).Result`. El programa sigue funcionando, pero ¿qué hace el hilo mientras espera? Relaciónalo con el apartado 11.1 del tema 11.

> **Para qué te servirá:** cualquier operación lenta (cargar datos, guardarlos, generar un informe) debe esperar sin bloquear, informar de su progreso y poder cancelarse.
