# Katas de C# (opcionales)

- [Katas de C# (opcionales)](#katas-de-c-opcionales)
  - [Qué es un kata](#qué-es-un-kata)
  - [Cómo se trabaja](#cómo-se-trabaja)
  - [Los katas](#los-katas)

## Qué es un kata

Un **kata** es un ejercicio pequeño que se repite hasta dominarlo, como en las artes marciales. En programación sirve para practicar el lenguaje y el hábito de **escribir una prueba antes que el código**, sin el peso de un programa completo.

Estos katas son **opcionales**: no llevan nota ni forman parte de los ejercicios de la unidad. Son para quien quiera seguir practicando C#, repasar un tema antes de un examen o ir más despacio de lo que permiten los ejercicios. Se pueden hacer en cualquier orden, aunque cada uno indica los temas que usa.

## Cómo se trabaja

Todos tienen la misma forma:

- Una solución de **dos proyectos**: `*.Logica` (las clases, con las firmas y la documentación, sin implementar) y `*.Pruebas` (xUnit).
- Las pruebas están **escritas por pasos**. Todas menos la primera llevan `Skip`, que impide ejecutarlas.
- El ciclo es siempre el mismo: **rojo** (la prueba falla), **verde** (escribes lo mínimo para que pase) y **refactor** (limpias el código sin romper nada). Después quitas el `Skip` de la siguiente prueba.
- No se modifican las pruebas, salvo para quitar el `Skip`. Puedes añadir pruebas propias.
- Cada enunciado termina con una lista para comprobar la solución y un **desafío** sin pruebas.

Para ejecutar las pruebas desde la terminal: `dotnet test --solution <Nombre>.slnx`.

Si trabajas con el repositorio de la unidad, cada kata va en su propia carpeta, con su solución, igual que los ejercicios.

## Los katas

| # | Kata | Temas | Dificultad | Tiempo | Descripción |
|---|------|-------|:----------:|:------:|-------------|
| 1 | [FizzBuzz](./K01-FizzBuzz/ENUNCIADO.md) | 4 | ★☆☆ | 30 min | Expresión `switch` y un primer ciclo rojo, verde y refactor |
| 2 | [Números romanos](./K02-NumerosRomanos/ENUNCIADO.md) | 3, 4, 7 | ★★☆ | 1 h | Una tabla en lugar de trece `if`, y validar volviendo a convertir |
| 3 | [Calculadora de cadenas](./K03-CalculadoraCadenas/ENUNCIADO.md) | 3, 7, 10 | ★★☆ | 1,5 h | Sumar números dentro de un texto; ocho reglas que se van añadiendo |
| 4 | [Bolera](./K04-Bolera/ENUNCIADO.md) | 5, 7 | ★★★ | 2 h | Puntuar una partida de bolos: semiplenos, plenos y el último cuadro |
| 5 | [Anagramas](./K05-Anagramas/ENUNCIADO.md) | 10 | ★★☆ | 1 h | Buscar y agrupar anagramas con LINQ |
| 6 | [Limitador de peticiones](./K06-LimitadorPeticiones/ENUNCIADO.md) | 5, 9, 12 | ★★☆ | 1,5 h | Una ventana deslizante, un evento al rechazar y un reloj falso en las pruebas |
| 7 | [Invernadero](./K07-Invernadero/ENUNCIADO.md) | 9 | ★☆☆ | 1 h | Un sensor que avisa con un evento al pasar un umbral y al volver a la normalidad, y un suscriptor que lo registra |
| 8 | [Almacén](./K08-Almacen/ENUNCIADO.md) | 8, 9 | ★★☆ | 1,5 h | Stock en un diccionario, dos eventos en orden (stock bajo y agotado) y varios suscriptores |

Si no sabes por cuál empezar, empieza por el 1: el resto de katas se trabajan igual.
