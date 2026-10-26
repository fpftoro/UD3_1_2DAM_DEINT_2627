# K05 · Anagramas

**Tipo:** kata opcional (autocorrección)

Un anagrama es una palabra o frase con las mismas letras que otra, en otro orden: «Roma» y «amor». Este kata se resuelve casi entero con LINQ: filtrar, ordenar y agrupar letras.

**CE:** — (opcional; practica el RA1: enlace de datos con consultas) · **Dificultad:** ★★☆ · **Tiempo estimado:** 1 h · **Tema:** 10

## Cómo se trabaja un kata

1. Abre la solución `Anagramas.slnx`. Las pruebas están escritas por pasos, en `Anagramas.Pruebas`, y todas menos la primera llevan `Skip = "…"` en su atributo, así que no se ejecutan.
2. **Rojo:** ejecuta las pruebas y comprueba que la primera falla.
3. **Verde:** escribe en `Anagramas.Logica` el código **más sencillo** que la haga pasar, aunque sea una trampa. Ya lo mejorarás.
4. **Refactoriza:** si el código queda feo o repetido, límpialo sin que ninguna prueba falle.
5. Quita el `Skip` de la prueba siguiente y repite desde el paso 2. Al final, ninguna prueba debe llevar `Skip`.

No modifiques las pruebas, salvo para quitar el `Skip`. Puedes añadir pruebas tuyas.

## Punto de partida

La solución `Anagramas.slnx` tiene dos proyectos:

- `Anagramas.Logica`: la clase estática `BuscadorAnagramas` con las firmas y la documentación, sin implementar.
- `Anagramas.Pruebas`: las pruebas de `BuscadorAnagramasPruebas.cs`, agrupadas en seis pasos.

## Requisitos

### `BuscadorAnagramas`

| Miembro | Comportamiento |
|---------|----------------|
| `bool SonAnagramas(string primero, string segundo)` | `true` si tienen las mismas letras en otro orden. Se ignoran las mayúsculas, los espacios y todo lo que no sea una letra. Un texto **no** es anagrama de sí mismo: «Roma» y «roma» dan `false` |
| `IReadOnlyList<string> Buscar(string palabra, IEnumerable<string> candidatas)` | Las candidatas que son anagramas de la palabra, en el orden en que vienen |
| `IReadOnlyList<IReadOnlyList<string>> Agrupar(IEnumerable<string> palabras)` | Agrupa las palabras que son anagramas entre sí y devuelve solo los grupos de dos o más. Los grupos van en el orden de su primera palabra y, dentro de cada grupo, las palabras en el orden en que aparecen. Las repetidas (sin distinguir mayúsculas) cuentan una vez |

Además:

1. Los tres métodos lanzan `ArgumentNullException` si algún argumento es `null`.
2. La clave de un anagrama son **sus letras ordenadas**: «amor» y «Roma» comparten `amor`. Escribe dos métodos privados, uno que deje solo las letras en minúscula y otro que las ordene.
3. Resuelve los tres métodos **sin `for`, `foreach` ni `while`**: con `Where`, `Select`, `GroupBy`, `Distinct` y `ToList`.

## Comprueba tu solución

1. Todas las pruebas en verde y **ninguna** con `Skip` (`dotnet test --solution Anagramas.slnx`).
2. Comprueba a mano:

   ```text
   SonAnagramas("Dormitory", "dirty room")        → True
   SonAnagramas("Roma", "roma")                   → False
   Buscar("listen", ["inlets", "banana", "silent"]) → inlets, silent
   Agrupar(["listen", "google", "silent", "gogole", "casa"])
                                                  → [listen, silent] y [google, gogole]
   ```

3. ¿Qué pasa con las tildes? Prueba `SonAnagramas("canción", "cancion")`. Decide si tu solución debería tratarlas igual y qué habría que cambiar.

> **Desafío (sin pruebas):** añade `Ordenar` por tamaño de grupo, de mayor a menor, y a igualdad, por la primera palabra.
