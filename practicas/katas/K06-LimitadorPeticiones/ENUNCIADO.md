# K06 · Limitador de peticiones

**Tipo:** kata opcional (autocorrección)

Un servicio no acepta más de N peticiones cada cierto tiempo (por ejemplo, 3 cada 10 segundos) y avisa cuando rechaza una. Se prueba sin esperar de verdad, con un reloj falso que se inyecta.

**CE:** — (opcional; practica el RA1: clases y eventos) · **Dificultad:** ★★☆ · **Tiempo estimado:** 1,5 h · **Temas:** 5, 9 y 12

## Cómo se trabaja un kata

1. Abre la solución `Limitador.slnx`. Las pruebas están escritas por pasos, en `Limitador.Pruebas`, y todas menos la primera llevan `Skip = "…"` en su atributo, así que no se ejecutan.
2. **Rojo:** ejecuta las pruebas y comprueba que la primera falla.
3. **Verde:** escribe en `Limitador.Logica` el código **más sencillo** que la haga pasar, aunque sea una trampa. Ya lo mejorarás.
4. **Refactoriza:** si el código queda feo o repetido, límpialo sin que ninguna prueba falle.
5. Quita el `Skip` de la prueba siguiente y repite desde el paso 2. Al final, ninguna prueba debe llevar `Skip`.

No modifiques las pruebas, salvo para quitar el `Skip`. Puedes añadir pruebas tuyas.

## Punto de partida

La solución `Limitador.slnx` tiene dos proyectos:

- `Limitador.Logica`: `LimitadorPeticiones` con las firmas, el evento declarado y la documentación, sin implementar, y `RechazoEventArgs`, que ya está hecha.
- `Limitador.Pruebas`: las pruebas de `LimitadorPeticionesPruebas.cs`, agrupadas en cuatro pasos, y `RelojFalso.cs`, un reloj que solo avanza cuando la prueba se lo dice. **No lo modifiques.**

## Requisitos

### `LimitadorPeticiones`

| Miembro | Comportamiento |
|---------|----------------|
| `LimitadorPeticiones(int maximo, TimeSpan ventana, TimeProvider? reloj = null)` | Lanza `ArgumentOutOfRangeException` si el máximo o la ventana no son mayores que 0. Si no se da reloj, usa `TimeProvider.System` |
| `bool Intentar()` | Acepta la petición (`true`) si en la última ventana hay menos de `maximo` aceptadas. Si no, la rechaza (`false`) y lanza `PeticionRechazada` |
| `int Disponibles` | Cuántas peticiones se aceptarían ahora mismo |
| `event EventHandler<RechazoEventArgs>? PeticionRechazada` | Se lanza una vez por cada petición rechazada. El emisor es el limitador y `Espera` es el tiempo que falta para que se acepte otra |

La **ventana deslizante** funciona así: una petición aceptada a las 12:00:00 con una ventana de 10 s cuenta hasta las 12:00:10, momento en que deja de contar (a las 12:00:09,9 todavía cuenta). Las peticiones rechazadas no cuentan.

Además:

1. Pide la hora **siempre** a `reloj.GetUtcNow()`, nunca a `DateTime.Now` ni a `DateTimeOffset.UtcNow`: así la prueba controla el tiempo.
2. Guarda la hora de cada petición aceptada en una `Queue<DateTimeOffset>`. La más antigua está siempre la primera, así que para olvidar las caducadas basta con mirar la cabeza de la cola.
3. `Espera` se calcula con la petición aceptada más antigua: su hora más la ventana, menos la hora actual.
4. Lanza el evento con el operador `?.Invoke(this, …)`: sin oyentes no debe fallar.

## Comprueba tu solución

1. Todas las pruebas en verde y **ninguna** con `Skip` (`dotnet test --solution Limitador.slnx`).
2. Haz el recorrido a mano en papel con `maximo = 2` y `ventana = 10 s`, y comprueba que las pruebas dicen lo mismo:

   ```text
   t = 0   Intentar() → True
   t = 6   Intentar() → True
   t = 8   Intentar() → False   (Espera = 2 s)
   t = 10  Intentar() → True    (la de t = 0 ya no cuenta)
   t = 10  Intentar() → False   (cuentan las de t = 6 y t = 10)
   ```

3. Cambia `Disponibles` para que no llame a la limpieza de caducadas: ¿qué prueba falla y por qué?
4. ¿Por qué `LimitadorPeticiones` recibe el reloj en el constructor en lugar de crearlo dentro? Intenta escribir la prueba del paso 3 sin `RelojFalso` y calcula cuánto tardaría en ejecutarse.

> **Desafío (sin pruebas):** haz que `Intentar` sea seguro cuando lo llaman varios hilos a la vez (`lock`), y explica en un comentario qué podría pasar sin él.
