# K02 · Números romanos

**Tipo:** kata opcional (autocorrección)

Convierte números enteros a romanos y los romanos a enteros. Hay que descubrir que las reglas del sistema (sumar, repetir y restar) caben en una tabla.

**CE:** — (opcional; practica el RA1: métodos, estructuras de control y excepciones) · **Dificultad:** ★★☆ · **Tiempo estimado:** 1 h · **Temas:** 3, 4 y 7

## Cómo se trabaja un kata

1. Abre la solución `Romanos.slnx`. Las pruebas están escritas por pasos, en `Romanos.Pruebas`, y todas menos la primera llevan `Skip = "…"` en su atributo, así que no se ejecutan.
2. **Rojo:** ejecuta las pruebas y comprueba que la primera falla.
3. **Verde:** escribe en `Romanos.Logica` el código **más sencillo** que la haga pasar, aunque sea una trampa. Ya lo mejorarás.
4. **Refactoriza:** si el código queda feo o repetido, límpialo sin que ninguna prueba falle.
5. Quita el `Skip` de la prueba siguiente y repite desde el paso 2. Al final, ninguna prueba debe llevar `Skip`.

No modifiques las pruebas, salvo para quitar el `Skip`. Puedes añadir pruebas tuyas.

## Punto de partida

La solución `Romanos.slnx` tiene dos proyectos:

- `Romanos.Logica`: la clase estática `ConversorRomano` con las firmas, la constante `Maximo` y la documentación, sin implementar.
- `Romanos.Pruebas`: las pruebas de `ConversorRomanoPruebas.cs`, agrupadas en siete pasos.

## Requisitos

### `ConversorRomano`

| Miembro | Comportamiento |
|---------|----------------|
| `Maximo` | Constante con valor 3999 (`MMMCMXCIX`) |
| `string ARomano(int numero)` | Devuelve el número en romano, con mayúsculas. Lanza `ArgumentOutOfRangeException` si no está entre 1 y `Maximo` |
| `int ADecimal(string romano)` | Devuelve el número que representa el texto. Lanza `ArgumentException` si el texto está vacío y `FormatException` si no es un número romano bien escrito |

Los símbolos son `I`=1, `V`=5, `X`=10, `L`=50, `C`=100, `D`=500 y `M`=1000. Se repiten para sumar (`XXX` = 30) y, en seis casos, un símbolo menor delante de otro mayor resta: `IV` (4), `IX` (9), `XL` (40), `XC` (90), `CD` (400) y `CM` (900).

Además:

1. Guarda los valores y los símbolos en **una tabla** (un array de pares, ordenado de mayor a menor) y usa un bucle sobre ella. No escribas 13 `if` seguidos.
2. «Bien escrito» significa que es **la forma habitual**: `IV`, no `IIII`; `XCIX`, no `IC`. Una forma sencilla de comprobarlo es volver a convertir el resultado con `ARomano` y comparar con el texto recibido.
3. Solo se admiten mayúsculas: `xiv` es un `FormatException`.

## Comprueba tu solución

1. Todas las pruebas en verde y **ninguna** con `Skip` (`dotnet test --solution Romanos.slnx`).
2. Estos valores deben salir exactamente así:

   ```text
   4    → IV
   14   → XIV
   1994 → MCMXCIV
   2024 → MMXXIV
   3999 → MMMCMXCIX
   ```

3. La última prueba convierte los 3999 números a romano y vuelta. Si pasa, no tienes ningún caso suelto mal resuelto.
4. ¿Por qué la tabla incluye `CM`, `CD`, `XC`… además de los siete símbolos? Quítalos y mira qué pruebas fallan.

> **Desafío (sin pruebas):** acepta también minúsculas, sin romper las pruebas que piden `FormatException` para `xiv`: tendrás que decidir qué debe hacer entonces esa prueba y justificarlo.
