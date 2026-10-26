# E02 · Cuenta bancaria

**Tipo:** autocorrección

Completa una clase `CuentaBancaria` que protege su saldo: desde fuera se puede leer, pero solo cambia con ingresos, retiradas y transferencias, que se validan y quedan anotadas en un extracto.

**CE:** — (formativo; prepara el RA1: clases, propiedades y métodos) · **Dificultad:** ★★☆ · **Tiempo estimado:** 2 h · **Temas:** 5 y 7

## Punto de partida

La solución `Banco.slnx` ya tiene los tres proyectos:

- `Banco.Logica`: `CuentaBancaria.cs`, `Movimiento.cs` y `SaldoInsuficienteException.cs`, con las firmas y la documentación, pero **sin implementar** (`throw new NotImplementedException()`).
- `Banco.Consola/Program.cs`: crea dos cuentas, opera con ellas y comprueba que la clase se protege. **No lo modifiques.**
- `Banco.Pruebas/CuentaBancariaPruebas.cs`: 16 pruebas que ahora fallan. **No las modifiques**: tu trabajo es ponerlas en verde.

## Requisitos

### `CuentaBancaria`

| Miembro | Tipo | Comportamiento |
|---------|------|----------------|
| `Prefijo` | Constante | `"ES-"` |
| `CuentaBancaria(string titular, decimal saldoInicial = 0)` | Constructor | Asigna el titular (con sus validaciones) y lanza `ArgumentOutOfRangeException` si el saldo es negativo. Asigna el número **después** de validar. Si el saldo inicial es mayor que 0, lo anota como movimiento `Apertura` |
| `CuentasAbiertas` | Propiedad **estática** de solo lectura | Cuántas cuentas se han abierto |
| `Numero` | Propiedad sin `set` | `ES-0001`, `ES-0002`…: el prefijo y un número consecutivo de cuatro cifras |
| `Titular` | Propiedad con lógica | El `set` lanza `ArgumentException` (con `nameof(Titular)` como nombre del parámetro) si el texto está vacío o solo tiene espacios, y guarda el texto sin espacios en los extremos en un **campo privado** |
| `Saldo` | Propiedad con `private set` | Saldo actual |
| `FechaApertura` | Propiedad `DateOnly` con `init` | Por defecto, la fecha de hoy. Se puede fijar al crear la cuenta: `new CuentaBancaria("Ana") { FechaApertura = … }` |
| `Movimientos` | `IReadOnlyList<Movimiento>` | Los movimientos, guardados en una `List<Movimiento>` privada |
| `decimal Ingresar(decimal importe)` | Método | Suma el importe, anota `Ingreso` y devuelve el saldo |
| `decimal Retirar(decimal importe)` | Método | Resta el importe, anota `Retirada` y devuelve el saldo. Si no alcanza, lanza `SaldoInsuficienteException` **sin cambiar nada** |
| `void Transferir(CuentaBancaria destino, decimal importe)` | Método | Lanza `ArgumentException` si el destino es la misma cuenta. Anota `Transferencia a <número destino>` en esta cuenta y `Transferencia de <número origen>` en la otra |
| `ToString()` | Sobrescritura | `ES-0001 · Ana López · 150,00 €` (saldo con formato `N2`) |

Además:

1. Los tres métodos que mueven dinero lanzan `ArgumentOutOfRangeException` si el importe no es mayor que 0. Usa `ArgumentOutOfRangeException.ThrowIfNegativeOrZero(importe)` en **un método privado**, no repetido en cada método.
2. El saldo solo cambia en **un único método privado** que también anota el movimiento (con el importe con signo y el saldo resultante).

### `Movimiento` y `SaldoInsuficienteException`

- `Movimiento` es un `record` posicional con `Concepto`, `Importe` y `SaldoResultante`. Ya está hecho.
- `SaldoInsuficienteException` hereda de `Exception`, tiene la propiedad `Disponible` (el saldo cuando se intentó la operación) y el mensaje `Saldo insuficiente: <disponible con N2> € disponibles`. Completa el constructor.

## Comprueba tu solución

1. Todas las pruebas en verde en el Explorador de pruebas (o `dotnet test --solution Banco.slnx`).
2. Ejecuta `Banco.Consola`. Debe mostrar exactamente:

   ```text
   🏦 ES-0001 · Ana López · 119,50 €
   🏦 ES-0002 · Luis Pérez · 50,50 €
   ❌ Retirar 500 € de Ana: Saldo insuficiente: 119,50 € disponibles
   ❌ Ingresar -5 € en Ana: ArgumentOutOfRangeException (importe)
   ❌ Abrir una cuenta sin titular: ArgumentException (Titular)
   ❌ Transferir de Ana a Ana: ArgumentException (destino)
   📄 Extracto de Ana:
      Apertura                      100,00 € →     100,00 €
      Ingreso                        50,00 € →     150,00 €
      Transferencia a ES-0002       -30,50 € →     119,50 €
   🔢 Cuentas abiertas: 2
   ```

3. Si «Cuentas abiertas» sale 3, la cuenta sin titular ha gastado un número: asígnalo después de validar.
4. Escribe en `Program.cs`, temporalmente, `ana.Saldo = 1000;` y `ana.Movimientos.Clear();`. Ninguna de las dos líneas debe compilar. Lee el error de cada una y bórralas.
5. ¿Por qué `Saldo` es `decimal` y no `double`? Pruébalo: `Console.WriteLine(0.1 + 0.2 == 0.3);` y `Console.WriteLine(0.1m + 0.2m == 0.3m);`.

> **Para qué te servirá:** un objeto que valida sus datos y protege su estado no se puede dejar en una situación incorrecta, lo use quien lo use. Es la base de cualquier formulario de datos.
