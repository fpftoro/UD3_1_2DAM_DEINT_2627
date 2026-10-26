# K08 · Almacén

**Tipo:** kata opcional (autocorrección)

Un almacén lleva las unidades de cada producto. Cuando una salida deja un producto por debajo del stock mínimo hay que avisar, y si lo deja a cero, avisar también de que se ha agotado. El servicio de compras escucha los avisos para apuntar qué hay que pedir al proveedor; el encargado, para enterarse.

**CE:** — (opcional; practica el RA1: colecciones, eventos y escuchadores) · **Dificultad:** ★★☆ · **Tiempo estimado:** 1,5 h · **Temas:** 8 y 9

## Cómo se trabaja un kata

1. Abre la solución `Almacen.slnx`. Las pruebas están escritas por pasos, en `Almacen.Pruebas`, y todas menos la primera llevan `Skip = "…"` en su atributo, así que no se ejecutan.
2. **Rojo:** ejecuta las pruebas y comprueba que la primera falla.
3. **Verde:** escribe en `Almacen.Logica` el código **más sencillo** que la haga pasar, aunque sea una trampa. Ya lo mejorarás.
4. **Refactoriza:** si el código queda feo o repetido, límpialo sin que ninguna prueba falle.
5. Quita el `Skip` de la prueba siguiente y repite desde el paso 2. Al final, ninguna prueba debe llevar `Skip`.

No modifiques las pruebas, salvo para quitar el `Skip`. Puedes añadir pruebas tuyas.

## Punto de partida

La solución `Almacen.slnx` tiene dos proyectos:

- `Almacen.Logica`: `ControlStock` y `ServicioCompras` con las firmas, los eventos declarados y la documentación, sin implementar, y `StockEventArgs`, que ya está hecha.
- `Almacen.Pruebas`: las pruebas de `ControlStockPruebas.cs`, agrupadas en cinco pasos.

## Requisitos

### `ControlStock`

| Miembro | Comportamiento |
|---------|----------------|
| `ControlStock(int stockMinimo)` | Almacén vacío. `ArgumentOutOfRangeException` si el mínimo es negativo |
| `int StockMinimo` | Por debajo de estas unidades, el stock es bajo |
| `int Unidades(string producto)` | Las unidades del producto, o 0 si no está |
| `void Entrada(string producto, int unidades)` | Suma unidades (da de alta el producto si no estaba). `ArgumentOutOfRangeException` si no son mayores que 0 |
| `void Salida(string producto, int unidades)` | Resta unidades. `ArgumentOutOfRangeException` si no son mayores que 0; `InvalidOperationException` si no hay suficientes, **sin cambiar nada** |
| `event EventHandler<StockEventArgs>? StockBajo` | Cuando una salida deja el producto **por debajo** del mínimo y antes no lo estaba |
| `event EventHandler<StockEventArgs>? ProductoAgotado` | Cuando una salida deja el producto a 0 |

Guarda las unidades en un `Dictionary<string, int>`. Si una salida provoca los dos avisos, primero `StockBajo` y después `ProductoAgotado`.

### `ServicioCompras`

Un **suscriptor**: `Vigilar(almacen)` se suscribe a `StockBajo`; cada aviso apunta el producto en `Pedidos`, **sin repetirlo**. `Recibir(producto)` lo quita de los pendientes y devuelve si estaba.

## Comprueba tu solución

1. Todas las pruebas en verde y **ninguna** con `Skip` (`dotnet test --solution Almacen.slnx`).
2. Con un mínimo de 5, haz a mano: entran 8 tornillos; salen 3 (quedan 5, nada); sale 1 (quedan 4, `StockBajo`); salen 4 (quedan 0, solo `ProductoAgotado`, porque ya estaba bajo). Comprueba que las pruebas dicen lo mismo.
3. ¿Por qué `Salida` comprueba las unidades **antes** de cambiar nada? ¿Qué pasaría si restara primero y comprobara después?
4. `ServicioCompras` y el encargado no se conocen entre sí. ¿Qué ventaja tiene el patrón publicador-suscriptor frente a que `ControlStock` llame directamente a los dos?

> **Desafío (sin pruebas):** añade un evento `StockRepuesto` que se lance cuando una entrada devuelve un producto al mínimo o por encima, y haz que `ServicioCompras` lo escuche para quitar el producto de los pedidos sin llamar a `Recibir`.
