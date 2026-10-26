# K01 · FizzBuzz

**Tipo:** kata opcional (autocorrección)

El kata más conocido para empezar: convierte números en palabras según por cuánto se pueden dividir. Sirve para aprender el ciclo de trabajo de todos los katas, que es hacer una prueba cada vez.

**CE:** — (opcional; practica el RA1: métodos y estructuras de control) · **Dificultad:** ★☆☆ · **Tiempo estimado:** 30 min · **Tema:** 4

## Cómo se trabaja un kata

1. Abre la solución `Divisibles.slnx`. Las pruebas están escritas por pasos, en `Divisibles.Pruebas`, y todas menos la primera llevan `Skip = "…"` en su atributo, así que no se ejecutan.
2. **Rojo:** ejecuta las pruebas y comprueba que la primera falla.
3. **Verde:** escribe en `Divisibles.Logica` el código **más sencillo** que la haga pasar, aunque sea una trampa (devolver siempre `"1"`). Ya lo mejorarás.
4. **Refactoriza:** si el código queda feo o repetido, límpialo sin que ninguna prueba falle.
5. Quita el `Skip` de la prueba siguiente y repite desde el paso 2. Al final, ninguna prueba debe llevar `Skip`.

No modifiques las pruebas, salvo para quitar el `Skip`. Puedes añadir pruebas tuyas.

## Punto de partida

La solución `Divisibles.slnx` tiene dos proyectos:

- `Divisibles.Logica`: la clase estática `FizzBuzz` con las firmas y la documentación, sin implementar (`throw new NotImplementedException()`).
- `Divisibles.Pruebas`: las pruebas de `FizzBuzzPruebas.cs`, agrupadas en seis pasos.

## Requisitos

### `FizzBuzz`

| Miembro | Comportamiento |
|---------|----------------|
| `string Convertir(int numero)` | Devuelve `"Fizz"` si el número es múltiplo de 3, `"Buzz"` si lo es de 5, `"FizzBuzz"` si lo es de los dos y, en otro caso, el número como texto |
| `IReadOnlyList<string> Generar(int hasta)` | Devuelve la secuencia de `Convertir` desde 1 hasta `hasta`, ambos incluidos |

Además:

1. Los dos métodos lanzan `ArgumentOutOfRangeException` si reciben un número que no es mayor que 0.
2. Resuelve `Convertir` con una **expresión `switch`** sobre el par de restos `(numero % 3, numero % 5)`.
3. Resuelve `Generar` sin escribir un bucle: se puede con una sola línea de LINQ.

## Comprueba tu solución

1. Todas las pruebas en verde y **ninguna** con `Skip` (`dotnet test --solution Divisibles.slnx`).
2. `FizzBuzz.Generar(15)` debe dar esta secuencia:

   ```text
   1, 2, Fizz, 4, Buzz, Fizz, 7, 8, Fizz, Buzz, 11, Fizz, 13, 14, FizzBuzz
   ```

3. Comprueba que el orden de los casos importa: ¿qué devolvería `Convertir(15)` si preguntaras primero por los múltiplos de 3? Pruébalo en tu `switch` y deshazlo.

> **Desafío (sin pruebas):** haz que las reglas no estén escritas en el código, sino en una lista de pares `(divisor, palabra)`. Con ella, añadir «los múltiplos de 7 son `Bang`» debe costar una línea.
