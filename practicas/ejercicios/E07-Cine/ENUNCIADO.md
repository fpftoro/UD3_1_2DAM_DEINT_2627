# E07 · Reserva de asientos de un cine

**Tipo:** autocorrección

Completa una sala de cine con una **matriz** de asientos que se pueden reservar uno a uno o en grupo, que **avisa con eventos** y que se dibuja en texto, y un **menú de consola** para usarla. Integra lo visto en los temas 3 a 9.

**CE:** — (formativo; prepara el RA1 g: asociar acciones a los eventos) · **Dificultad:** ★★★ · **Tiempo estimado:** 3 h · **Temas:** 3 a 9

## Punto de partida

- `Cine.Logica`: `AsientosEventArgs` ya está hecha. `Asiento` y `SalaCine` tienen las firmas y la documentación, sin implementar.
- `Cine.Consola/Program.cs`: **vacío**. Escribe tú el menú.
- `Cine.Pruebas/SalaCinePruebas.cs`: **no lo modifiques**.

## Requisitos

### `Asiento`

`Fila` y `Columna` (desde 1), `Reservado` con **`internal set`** (solo la sala lo cambia) y `Codigo`: la letra de la fila y el número de columna (`B3`). Pista: `(char)('A' + Fila - 1)`. `ToString()` devuelve el código.

### `SalaCine`

| Miembro | Comportamiento |
|---------|----------------|
| Constructor `(int filas = 5, int columnas = 8)` | De 1 a 26 filas y de 1 a 30 columnas (si no, `ArgumentOutOfRangeException`). Crea la matriz `Asiento[,]` con todos los asientos |
| `Filas`, `Columnas` | Con `GetLength(0)` y `GetLength(1)` |
| `Libres` | Asientos sin reservar (un `foreach` recorre todos los elementos de una matriz) |
| `static bool TryParseCodigo(string? codigo, out int fila, out int columna)` | Convierte `C5`, ` a10 ` o `c5` en fila y columna. Devuelve `false` (y pone las dos a 0) si no hay letra, no hay número o el número es menor que 1. No comprueba si existe en la sala |
| `Asiento ObtenerAsiento(int fila, int columna)` | `ArgumentOutOfRangeException` si no existe |
| `bool Reservar(int fila, int columna)` | `false` si ya estaba reservado. Si no, lo reserva y lanza `AsientosReservados` |
| `bool Cancelar(int fila, int columna)` | `false` si no estaba reservado. Si no, lo libera y lanza `ReservaCancelada` |
| `IReadOnlyList<Asiento>? ReservarGrupo(int cantidad)` | Busca, empezando por la fila A, el primer hueco de `cantidad` asientos **seguidos en la misma fila**. Si lo encuentra, los reserva, lanza **un solo** evento con todos y los devuelve; si no, devuelve `null` y no reserva nada |
| `string Mapa()` | La sala en texto, con `StringBuilder`: una cabecera con los números de columna y una línea por fila con `○` (libre) o `●` (reservado). Formato exacto en la prueba `Mapa_DibujaLibresYReservados` |

### El menú (`Program.cs`)

1. Crea una sala de **4 filas y 6 columnas** y suscríbete a sus dos eventos para mostrar `📢 Reservados: B3` y `📢 Liberado: C1` (con `string.Join(", ", e.Asientos)`).
2. Repite, hasta elegir `0` (o hasta que no haya más entrada, `Console.ReadLine()` devuelve `null`), un menú con: `1) Ver la sala  2) Reservar  3) Reservar para un grupo  4) Cancelar  0) Salir · libres: <n>`. Usa `while` y `switch`.
3. Para reservar y cancelar, pide un código y valídalo con `TryParseCodigo` y con las dimensiones de la sala antes de llamar a la sala. Escribe una **función local** que pida y valide el código y reciba como parámetro la acción a hacer (`Action<int, int>`), para no repetir ese código en las opciones 2 y 4.
4. Mensajes: `✅ Reservado`, `❌ Ese asiento ya está reservado`, `✅ Grupo reservado`, `❌ No hay <n> asientos seguidos en ninguna fila`, `✅ Cancelado`, `❌ Ese asiento no estaba reservado`, `❌ «<texto>» no es un código de asiento`, `❌ El asiento <código> no existe en esta sala`, `❌ «<texto>» no es una opción` y `👋 Hasta pronto` al salir.

## Comprueba tu solución

1. Todas las pruebas en verde.
2. Ejecuta la consola y haz: reservar B3, reservar un grupo de 4, reservar un grupo de 6, reservar B3 otra vez, reservar Z9, cancelar C1, la opción 7, ver la sala y salir. La sala debe quedar así:

   ```text
       1 2 3 4 5 6
    A  ● ● ● ● ○ ○
    B  ○ ○ ● ○ ○ ○
    C  ○ ● ● ● ● ●
    D  ○ ○ ○ ○ ○ ○
   ```

   ¿Por qué el grupo de 6 ha ido a la fila C y no a la B?
3. ¿Qué pasa si en `ReservarGrupo` no reinicias el contador de asientos seguidos al cambiar de fila? Crea una sala de 2×3, reserva A1 y A2 y pide un grupo de 3: ¿qué devuelve tu código y qué debería devolver?
4. Compara tu menú con el de la solución cuando el profesor la publique: ¿dónde has puesto las validaciones, en la consola o en la sala?

> **Para qué te servirá:** la sala no sabe nada de la consola. Si mañana el menú se sustituye por otra forma de usarla, `SalaCine` no cambia ni una línea.
