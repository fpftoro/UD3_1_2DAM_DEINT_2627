# E06 · Consultas sobre alumnos y notas

**Tipo:** autocorrección

Carga los alumnos de un fichero JSON y resuelve cada consulta (aprobados, los mejores, búsquedas, resumen por curso…) con **LINQ**, sin bucles.

**CE:** — (formativo; prepara el RA1: enlace de componentes a orígenes de datos) · **Dificultad:** ★★☆ · **Tiempo estimado:** 2 h · **Tema:** 10

## Punto de partida

- `Notas.Consola/alumnos.json`: doce alumnos. El proyecto ya lo copia junto al ejecutable (`CopyToOutputDirectory` en el `.csproj`).
- `Notas.Logica`: `ResumenCurso` ya está hecho. `Alumno`, `CargadorAlumnos` y `ConsultasAlumnos` tienen las firmas y la documentación, sin implementar.
- `Notas.Consola/Program.cs` y `Notas.Pruebas/ConsultasAlumnosPruebas.cs`: **no los modifiques**.

Un alumno del JSON:

```json
{ "nombre": "Ana López", "curso": "2DAM", "edad": 20, "notas": [8, 7.5, 9] }
```

## Requisitos

### `Alumno` (record)

- `Media`: media de las notas redondeada a dos decimales (`Math.Round`), o 0 si no tiene notas.
- `Aprobado`: media de 5 o más.

### `CargadorAlumnos`

- `DesdeTexto(string json)`: deserializa con `JsonSerializer.Deserialize<List<Alumno>>` y unas opciones `new JsonSerializerOptions(JsonSerializerDefaults.Web)` guardadas en un campo estático. Si el resultado es `null`, devuelve una lista vacía.
- `DesdeFichero(string ruta)`: lee el fichero y llama a `DesdeTexto`.

### `ConsultasAlumnos`

Constructor primario con un `IEnumerable<Alumno>` que se **copia** en una lista privada. Cada método es **una sola expresión LINQ** que termina en `ToList()` (o en un agregado):

| Método | Resultado |
|--------|-----------|
| `Aprobados()` | Aprobados, por nombre |
| `Mejores(int cantidad)` | Los de mayor media; si empatan, por nombre (`ThenBy`) |
| `BuscarPorNombre(string texto)` | Los **nombres** que contienen el texto, sin distinguir mayúsculas, en orden alfabético |
| `ResumenPorCurso()` | Un `ResumenCurso` por curso (`GroupBy`): nombre, alumnos, media de las medias con dos decimales y aprobados, ordenado por curso |
| `MediaGeneral()` | Media de las medias con dos decimales, o 0 si no hay alumnos |
| `HayNotasPorDebajoDe(double nota)` | Si algún alumno tiene alguna nota menor (`Any` dentro de `Any`) |
| `MenoresDeEdad(string curso)` | Tuplas `(Nombre, Edad)` de los menores de 18 de ese curso, sin distinguir mayúsculas en el curso |

## Comprueba tu solución

1. Todas las pruebas en verde.
2. `Notas.Consola` muestra exactamente:

   ```text
   📂 12 alumnos cargados · media general: 6,60
   ✅ Aprobados:
      Ana López      2DAM   8,17
      Elena Vidal    2DAW   9,83
      Hugo Navarro   1DAM   5,00
      Iván Romero    2DAW   5,33
      Lucía Moreno   1DAM   9,00
      Marta Ruiz     2DAM   9,50
      Óscar Gil      2DAM   6,50
      Sara Ortega    2DAW   7,00
      Zoe Martín     1DAM   7,17
   🏆 Los tres mejores:
      1. Elena Vidal (9,83)
      2. Marta Ruiz (9,50)
      3. Lucía Moreno (9,00)
   📊 Resumen por curso:
      1DAM  4 alumnos · media 6,34 · aprobados 3
      2DAM  4 alumnos · media 7,08 · aprobados 3
      2DAW  4 alumnos · media 6,37 · aprobados 3
   🔎 Nombres con «ar»: Hugo Navarro, Marta Ruiz, Óscar Gil, Sara Ortega, Zoe Martín
   ⚠️ ¿Alguna nota por debajo de 3? Sí
   🧒 Menores de edad en 1DAM: Zoe Martín (17), Lucía Moreno (17)
   ```

3. Quita el `ToList()` de `Aprobados` y cambia el tipo devuelto a `IEnumerable<Alumno>`. Pon un punto de interrupción dentro de la lambda del `Where`: ¿cuándo se detiene, al llamar a `Aprobados()` o al recorrer el resultado? Deja el `ToList()` como estaba.
4. Cambia `"nombre"` por `"Nombre"` en el JSON y quita `JsonSerializerDefaults.Web`. ¿Qué pasa? Deshaz los cambios.

> **Para qué te servirá:** estas consultas son las búsquedas, los filtros y los resúmenes de cualquier aplicación de gestión, y el fichero JSON es el primer origen de datos del proyecto del curso.
