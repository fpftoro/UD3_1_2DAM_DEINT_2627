# K03 · Calculadora de cadenas

**Tipo:** kata opcional (autocorrección)

Suma los números que vienen escritos dentro de un texto (`"1,2,3"`). Empieza siendo trivial y va añadiendo reglas, como los requisitos de un cliente: es el mejor kata para sentir cómo el código crece paso a paso con las pruebas.

**CE:** — (opcional; practica el RA1: cadenas, colecciones y excepciones) · **Dificultad:** ★★☆ · **Tiempo estimado:** 1,5 h · **Temas:** 3, 7 y 10

## Cómo se trabaja un kata

1. Abre la solución `Calculadora.slnx`. Las pruebas están escritas por pasos, en `Calculadora.Pruebas`, y todas menos la primera llevan `Skip = "…"` en su atributo, así que no se ejecutan.
2. **Rojo:** ejecuta las pruebas y comprueba que la primera falla.
3. **Verde:** escribe en `Calculadora.Logica` el código **más sencillo** que la haga pasar, aunque sea una trampa. Ya lo mejorarás.
4. **Refactoriza:** si el código queda feo o repetido, límpialo sin que ninguna prueba falle.
5. Quita el `Skip` de la prueba siguiente y repite desde el paso 2. Al final, ninguna prueba debe llevar `Skip`.

No modifiques las pruebas, salvo para quitar el `Skip`. Puedes añadir pruebas tuyas.

## Punto de partida

La solución `Calculadora.slnx` tiene dos proyectos:

- `Calculadora.Logica`: la clase estática `CalculadoraCadenas` con la firma de `Sumar`, la constante `Maximo` y la documentación, sin implementar.
- `Calculadora.Pruebas`: las pruebas de `CalculadoraCadenasPruebas.cs`, agrupadas en ocho pasos.

## Requisitos

### `int Sumar(string numeros)`

Cada paso añade una regla a las anteriores:

| Paso | Regla | Ejemplo |
|:----:|-------|---------|
| 1 | Un texto vacío suma 0. Un solo número se suma a sí mismo | `""` → 0 · `"42"` → 42 |
| 2 | Varios números separados por comas | `"1,2,3,4"` → 10 |
| 3 | El salto de línea también separa | `"1\n2,3"` → 6 |
| 4 | Un trozo que no es un número lanza `FormatException`; un texto `null`, `ArgumentNullException` | `"1,"` · `"1,,2"` · `"1,a"` |
| 5 | Un separador propio: el texto empieza por `//`, el separador y un salto de línea | `"//;\n1;2"` → 3 |
| 6 | Los negativos lanzan `ArgumentException` y el mensaje **los lista todos** | `"-1,2,-3"` → «…-1, -3» |
| 7 | Los números mayores que `Maximo` (1000) se ignoran; el 1000 sí cuenta | `"2,1001"` → 2 |
| 8 | Un separador de varios caracteres entre corchetes, o varios separadores | `"//[***]\n1***2"` → 3 · `"//[*][%]\n1*2%3"` → 6 |

Además:

1. Si la cabecera `//…` no va seguida de un salto de línea, lanza `FormatException`.
2. Convierte los trozos con `int.Parse` y `CultureInfo.InvariantCulture`.
3. Los pasos 1 a 4 se resuelven con `Split` y LINQ (`Select`, `Sum`). Para el paso 8 recorre la cabecera a mano con `IndexOf`: busca un `[`, luego el `]` siguiente, y repite.

## Comprueba tu solución

1. Todas las pruebas en verde y **ninguna** con `Skip` (`dotnet test --solution Calculadora.slnx`).
2. Comprueba a mano estos casos, que las pruebas no cubren todos juntos:

   ```text
   "1\n2,3"                → 6
   "//|\n4|5|6"            → 15
   "//[**][%%]\n1**2%%3"   → 6
   "1000,1001,2"           → 1002
   ```

3. Cada paso obligó a cambiar el código del anterior. ¿Qué partes has tenido que reescribir? Si has tenido que reescribir mucho, prueba a hacer el refactor antes de añadir la regla siguiente.

> **Desafío (sin pruebas):** haz que `Maximo` no sea una constante, sino un parámetro opcional de `Sumar` con valor 1000.
