# K04 · Bolera

**Tipo:** kata opcional (autocorrección)

Calcula la puntuación de una partida de bolos. Las reglas parecen sencillas, pero hay un caso especial detrás de otro: el semipleno, el pleno y el último cuadro. Es el kata más completo de esta colección.

**CE:** — (opcional; practica el RA1: clases, propiedades y estado interno) · **Dificultad:** ★★★ · **Tiempo estimado:** 2 h · **Temas:** 5 y 7

## Las reglas de los bolos

Una partida tiene **10 cuadros**. En cada cuadro el jugador tiene hasta **dos tiradas** para derribar los **10 bolos**.

- **Cuadro normal:** puntúa los bolos derribados en sus dos tiradas.
- **Semipleno** (los 10 bolos en las dos tiradas): puntúa 10 más los bolos de la **tirada siguiente**.
- **Pleno** (los 10 bolos en la primera tirada): puntúa 10 más los bolos de las **dos tiradas siguientes**. El cuadro termina en esa tirada.
- **Décimo cuadro:** si hay semipleno, se tiene **una tirada extra**; si hay pleno, **dos**. Esas tiradas extra solo sirven de bono: no forman cuadros nuevos.

Ejemplo: `10, 3, 4` da 17 (pleno con 3 + 4) más 7 del segundo cuadro = **24**.

## Cómo se trabaja un kata

1. Abre la solución `Bolera.slnx`. Las pruebas están escritas por pasos, en `Bolera.Pruebas`, y todas menos la primera llevan `Skip = "…"` en su atributo, así que no se ejecutan.
2. **Rojo:** ejecuta las pruebas y comprueba que la primera falla.
3. **Verde:** escribe en `Bolera.Logica` el código **más sencillo** que la haga pasar, aunque sea una trampa. Ya lo mejorarás.
4. **Refactoriza:** si el código queda feo o repetido, límpialo sin que ninguna prueba falle.
5. Quita el `Skip` de la prueba siguiente y repite desde el paso 2. Al final, ninguna prueba debe llevar `Skip`.

No modifiques las pruebas, salvo para quitar el `Skip`. Puedes añadir pruebas tuyas.

## Punto de partida

La solución `Bolera.slnx` tiene dos proyectos:

- `Bolera.Logica`: la clase `Partida` con las constantes, las firmas y la documentación, sin implementar.
- `Bolera.Pruebas`: las pruebas de `PartidaPruebas.cs`, agrupadas en siete pasos.

## Requisitos

### `Partida`

| Miembro | Comportamiento |
|---------|----------------|
| `Bolos`, `Cuadros` | Constantes con valor 10 |
| `void Tirar(int bolos)` | Anota una tirada. Lanza `ArgumentOutOfRangeException` si los bolos no están entre 0 y 10, e `InvalidOperationException` si la partida ya ha terminado |
| `int Puntuacion` | Puntos con las tiradas hechas hasta ahora. Un bono que todavía no se puede calcular (la tirada siguiente a un pleno que aún no se ha hecho) cuenta 0 |
| `bool Terminada` | `true` cuando ya se han hecho todas las tiradas, incluidas las extras del décimo cuadro |

Además:

1. Guarda las tiradas en **una lista de enteros** privada. La puntuación se calcula recorriendo esa lista, no hace falta una clase `Cuadro`.
2. Escribe un método privado `Tirada(int indice)` que devuelva 0 si todavía no existe esa tirada: te evita comprobar los límites en todas partes.
3. No hace falta validar que las dos tiradas de un cuadro no sumen más de 10.

## Comprueba tu solución

1. Todas las pruebas en verde y **ninguna** con `Skip` (`dotnet test --solution Bolera.slnx`).
2. Estas partidas completas deben dar:

   ```text
   20 tiradas de 0                       → 0
   20 tiradas de 1                       → 20
   21 tiradas de 5 (todo semiplenos)     → 150
   12 tiradas de 10 (partida perfecta)   → 300
   ```

3. Reproduce una partida real: `10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8, 1` debe dar **167** y `Terminada` debe ser `true` tras la última tirada.
4. ¿Por qué la puntuación de una partida a medias no es un error, sino «lo que llevo»? Lee el comentario de `Puntuacion` y prueba con `10` y `10`.

> **Desafío (sin pruebas):** rechaza con `ArgumentException` una segunda tirada que, sumada a la primera de su cuadro, pase de 10 bolos. Fíjate en que el décimo cuadro tiene sus propias reglas.
