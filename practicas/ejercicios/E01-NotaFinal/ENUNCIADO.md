# E01 · Calculadora de la nota final

**Tipo:** autocorrección

Crea desde cero tu primera **solución de tres proyectos** en Visual Studio: una biblioteca con la lógica, una consola que pide los datos y un proyecto de pruebas. Es la estructura que usarás en todos los ejercicios de la unidad.

**CE:** — (formativo; prepara el RA1: clases y métodos) · **Dificultad:** ★☆☆ · **Tiempo estimado:** 1,5 h · **Temas:** 1, 3 y 4

## Punto de partida

No hay código de partida: lo creas todo tú, siguiendo el tema 1.

## Requisitos

### 1. La solución

1. Crea una solución `NotaFinal` (formato `.slnx`) con tres proyectos, todos con .NET 10:

   | Proyecto | Plantilla | Para qué |
   |----------|-----------|----------|
   | `NotaFinal.Logica` | Biblioteca de clases | La lógica: ni lee ni escribe en la consola |
   | `NotaFinal.Consola` | Aplicación de consola | Pide los datos y muestra el resultado |
   | `NotaFinal.Pruebas` | xUnit.net v3 Test Project | Comprueba la lógica |

2. `NotaFinal.Consola` y `NotaFinal.Pruebas` **hacen referencia** a `NotaFinal.Logica`.

### 2. La lógica

En `NotaFinal.Logica`, una clase **estática** `CalculadoraNota` con este contrato:

| Miembro | Comportamiento |
|---------|----------------|
| `PesoParciales`, `PesoExamen`, `PesoTrabajo` | Constantes (`const double`): 0,5, 0,3 y 0,2 |
| `bool EsNotaValida(double nota)` | `true` si la nota está entre 0 y 10, ambos incluidos |
| `double Calcular(double parcial1, double parcial2, double examen, double trabajo)` | 50 % de la media de los parciales + 30 % del examen + 20 % del trabajo, **redondeado a dos decimales**. Si alguna nota no es válida, lanza `ArgumentOutOfRangeException` |
| `string Calificacion(double nota)` | `Insuficiente` (< 5), `Suficiente` (< 6), `Bien` (< 7), `Notable` (< 9) o `Sobresaliente`. Usa una **expresión `switch`** con patrones relacionales. Si la nota no es válida, lanza `ArgumentOutOfRangeException` |

Documenta la clase y cada miembro público con comentarios XML (`///`).

### 3. La consola

1. Muestra el título `📘 Nota final de Desarrollo de Interfaces`.
2. Pide, en este orden, `Primer parcial`, `Segundo parcial`, `Examen` y `Trabajo final`. Cada pregunta se escribe con `Console.Write` y termina en `: `.
3. Si lo escrito no es un número entre 0 y 10, muestra `❌ «<texto>» no es una nota entre 0 y 10. Usa la coma para los decimales.` y vuelve a preguntar **la misma** nota. Usa `double.TryParse`, nunca `double.Parse`.
4. Muestra `✅ Nota final: <nota con dos decimales> (<calificación>)`.
5. Al principio del programa, pon la consola en UTF-8 (para los emojis) y la cultura en `es-ES` (para la coma decimal):

   ```csharp
   Console.OutputEncoding = Encoding.UTF8;
   CultureInfo.CurrentCulture = new CultureInfo("es-ES");
   ```

### 4. Las pruebas

Escribe al menos estas pruebas en `NotaFinal.Pruebas`:

1. `Calcular` con 6, 8, 7 y 9 devuelve 7,40.
2. `Calcular` con una nota de 11 lanza `ArgumentOutOfRangeException` (`Assert.Throws`).
3. Un `[Theory]` con varios `[InlineData]` que compruebe los **límites** de cada calificación (4,99, 5, 6,5, 8,99 y 9).

## Comprueba tu solución

Ejecuta la consola (Ctrl+F5) y escribe `6`, `ocho`, `8`, `7`, `12` y `9`. Debe verse así (lo que tecleas aparece detrás de cada pregunta):

```text
📘 Nota final de Desarrollo de Interfaces
Primer parcial: 6
Segundo parcial: ocho
❌ «ocho» no es una nota entre 0 y 10. Usa la coma para los decimales.
Segundo parcial: 8
Examen: 7
Trabajo final: 12
❌ «12» no es una nota entre 0 y 10. Usa la coma para los decimales.
Trabajo final: 9
✅ Nota final: 7,40 (Notable)
```

- Prueba también `7.5` con punto: ¿qué pasa y por qué? Prueba `7,5`.
- Abre el **Explorador de pruebas** (`Prueba > Explorador de pruebas`) y ejecuta todas: deben salir en verde.
- Cambia `< 5` por `<= 5` en `Calificacion` y vuelve a ejecutar las pruebas: alguna debe ponerse en rojo. Si ninguna falla, tus pruebas no comprueban los límites.
- `CalculadoraNota` no contiene ningún `Console.`: compruébalo con `Ctrl+F`.

> **Para qué te servirá:** la misma `CalculadoraNota` se puede usar desde la consola, desde las pruebas o desde la interfaz gráfica de la UD3 sin cambiarla. Por eso la lógica no puede leer ni escribir en la consola.
