# Test: Programación en C#

- [Test: Programación en C#](#test-programación-en-c)
  - [Bloque 1: El entorno de trabajo: .NET y Visual Studio](#bloque-1-el-entorno-de-trabajo-net-y-visual-studio)
  - [Bloque 2: Si vienes de otro lenguaje](#bloque-2-si-vienes-de-otro-lenguaje)
  - [Bloque 3: Estructura de un programa, tipos y operadores](#bloque-3-estructura-de-un-programa-tipos-y-operadores)
  - [Bloque 4: Control de flujo y métodos](#bloque-4-control-de-flujo-y-métodos)
  - [Bloque 5: Clases, objetos y propiedades](#bloque-5-clases-objetos-y-propiedades)
  - [Bloque 6: Herencia, interfaces y polimorfismo](#bloque-6-herencia-interfaces-y-polimorfismo)
  - [Bloque 7: Excepciones y tipos que admiten null](#bloque-7-excepciones-y-tipos-que-admiten-null)
  - [Bloque 8: Genéricos y colecciones](#bloque-8-genéricos-y-colecciones)
  - [Bloque 9: Delegados, lambdas y eventos](#bloque-9-delegados-lambdas-y-eventos)
  - [Bloque 10: LINQ](#bloque-10-linq)
  - [Bloque 11: Programación asíncrona](#bloque-11-programación-asíncrona)
  - [Bloque 12: Depurar, documentar y probar](#bloque-12-depurar-documentar-y-probar)

Una sola respuesta correcta por pregunta. La clave está en `soluciones/00-test/README.md`.

---

#### Bloque 1: El entorno de trabajo: .NET y Visual Studio

1. **¿Qué genera el compilador de C# al compilar un proyecto?**
   - a) Bytecode de Java que ejecuta la JVM
   - b) Un fichero `.cs` optimizado
   - c) Código máquina para el procesador del equipo donde se compila
   - d) Código intermedio (IL) dentro de un fichero `.dll`

2. **¿Qué parte de .NET traduce el IL a código máquina mientras se ejecuta el programa?**
   - a) El compilador JIT del CLR
   - b) NuGet
   - c) La BCL
   - d) El recolector de basura

3. **¿Qué es una versión LTS de .NET?**
   - a) Una versión con soporte de larga duración (tres años), la que se usa en el módulo
   - b) Una versión de prueba que todavía no es estable
   - c) La versión de .NET que solo funciona en Windows
   - d) Una versión que se publica cada mes

4. **En la solución de tres proyectos de la unidad, ¿qué proyecto no debe usar nunca la clase `Console`?**
   - a) Ninguno: todos pueden usarla
   - b) El de las pruebas (`.Pruebas`)
   - c) El de la lógica (`.Logica`)
   - d) El de la consola (`.Consola`)

5. **En Visual Studio, ¿qué hace Ctrl+F5?**
   - a) Compila la solución sin ejecutarla
   - b) Da formato al documento
   - c) Ejecuta el proyecto con el depurador
   - d) Ejecuta el proyecto de inicio sin el depurador

6. **¿Qué atajo de Visual Studio muestra las acciones rápidas (añadir un `using`, implementar una interfaz…) sobre un error?**
   - a) F12
   - b) Ctrl+K, Ctrl+D
   - c) Ctrl+.
   - d) Ctrl+Mayús+B

---

#### Bloque 2: Si vienes de otro lenguaje

7. **¿Cómo se escribe por convención el nombre de un método público en C#?**
   - a) En minúsculas con guiones bajos: `calcular_total`
   - b) En `camelCase`: `calcularTotal`
   - c) En `PascalCase`: `CalcularTotal`
   - d) En mayúsculas con guiones bajos: `CALCULAR_TOTAL`

8. **¿Cuál de estas afirmaciones sobre C# es correcta?**
   - a) Las excepciones no se declaran en la firma de los métodos
   - b) Los genéricos no admiten tipos de valor como `int`
   - c) Los métodos se pueden sobrescribir siempre, sin marcar nada en la clase base
   - d) `==` compara las referencias de dos `string`, no su contenido

---

#### Bloque 3: Estructura de un programa, tipos y operadores

9. **¿Qué tipo de C# debe usarse para guardar importes de dinero?**
   - a) `double`
   - b) `decimal`
   - c) `float`
   - d) `int`, guardando los céntimos

10. **¿Qué muestra este código?**

    ```csharp
    int aprobados = 3, total = 4;
    double porcentaje = aprobados / total * 100;
    Console.WriteLine(porcentaje);
    ```

    - a) No compila
    - b) `75`
    - c) `0`
    - d) `0,75`

11. **¿Qué muestra este código?**

    ```csharp
    var lista1 = new List<int> { 1 };
    var lista2 = lista1;
    lista2.Add(2);
    Console.WriteLine(lista1.Count);
    ```

    - a) Lanza una excepción
    - b) `2`
    - c) `1`
    - d) `0`

12. **¿Qué muestra este código?**

    ```csharp
    int a = 5;
    int b = a;
    b = 7;
    Console.WriteLine(a);
    ```

    - a) `0`
    - b) `7`
    - c) `5`
    - d) `12`

13. **¿Qué hace `int.TryParse(texto, out var n)` si `texto` es «doce»?**
    - a) Devuelve `false` y deja `n` a 0
    - b) Devuelve `null`
    - c) Lanza una `FormatException`
    - d) Devuelve `true` y deja `n` a 12

14. **¿Qué significa `var` en `var precio = 19.99m;`?**
    - a) `precio` es de tipo `object`
    - b) `precio` es una constante
    - c) `precio` es una variable dinámica que puede guardar cualquier tipo
    - d) El compilador deduce que `precio` es `decimal` y no puede cambiar de tipo

15. **Con la cultura `es-ES`, ¿qué muestra `Console.WriteLine($"{1234.5m:N2}");`?**
    - a) `1234.50`
    - b) `1234,5`
    - c) `1,234.50`
    - d) `1.234,50`

16. **¿Qué tipo permite guardar una nota que todavía no existe (sin valor)?**
    - a) `int?`
    - b) `int`
    - c) `int!`
    - d) `object?`

---

#### Bloque 4: Control de flujo y métodos

17. **¿Qué devuelve esta expresión con `nota = 5`?**

    ```csharp
    var texto = nota switch
    {
        < 5 => "Insuficiente",
        < 6 => "Suficiente",
        _ => "Otra",
    };
    ```

    - a) `"Suficiente"`
    - b) `"Insuficiente"`
    - c) `"Otra"`
    - d) No compila

18. **¿Qué ocurre en C# si un `case` de una instrucción `switch` tiene instrucciones pero no termina en `break`, `return` o `throw`?**
    - a) La ejecución continúa en el `case` siguiente
    - b) Se sale del método
    - c) Se ejecuta el `default`
    - d) No compila

19. **Dada la matriz `var sala = new char[3, 4];`, ¿qué devuelve `sala.GetLength(1)`?**
    - a) `1`
    - b) `12`
    - c) `4`
    - d) `3`

20. **Con `int[] numeros = [10, 20, 30, 40, 50];`, ¿qué es `numeros[1..3]`?**
    - a) `[20, 30, 40]`
    - b) `[20, 30]`
    - c) `[10, 20, 30]`
    - d) `[10, 20]`

21. **¿Para qué sirve el modificador `out` en un parámetro?**
    - a) Para que el parámetro sea opcional
    - b) Para que el método no pueda modificar el parámetro
    - c) Para que el método asigne un valor a una variable de quien lo llama, como en `TryParse`
    - d) Para recibir cualquier número de argumentos

22. **Dado `decimal Precio(decimal precioBase, int unidades = 1, decimal descuento = 0)`, ¿qué llamada aplica un descuento del 20 % a una sola unidad?**
    - a) `Precio(10m, descuento: 0.2m)`
    - b) `Precio(10m, 0.2m)`
    - c) `Precio(10m, , 0.2m)`
    - d) `Precio(descuento = 0.2m, 10m)`

---

#### Bloque 5: Clases, objetos y propiedades

23. **¿Qué diferencia hay entre `public decimal Saldo { get; private set; }` y `public decimal Saldo { get; set; }`?**
    - a) Con `private set`, el saldo solo se puede asignar desde dentro de la clase
    - b) Con `private set`, el saldo no se puede leer desde fuera
    - c) Con `private set`, solo se puede asignar en el constructor
    - d) Ninguna: las dos son públicas

24. **¿Dónde se puede asignar una propiedad declarada `{ get; init; }`?**
    - a) En el constructor o en un inicializador de objeto al crearlo
    - b) En cualquier método de la clase
    - c) En cualquier sitio, como una propiedad normal
    - d) Solo en el constructor

25. **¿Qué ocurre al leer esta propiedad?**

    ```csharp
    private string _titular = "";
    public string Titular
    {
        get => Titular;
        set => _titular = value;
    }
    ```

    - a) Devuelve una cadena vacía
    - b) El programa termina con un `StackOverflowException`
    - c) Devuelve el valor de `_titular`
    - d) No compila

26. **Dado `public record Movimiento(string Concepto, decimal Importe);`, ¿qué muestra `Console.WriteLine(new Movimiento("Ingreso", 50) == new Movimiento("Ingreso", 50));`?**
    - a) Lanza una excepción
    - b) `True`
    - c) `False`
    - d) No compila: los `record` no admiten `==`

27. **¿Qué es `value` dentro del `set` de una propiedad?**
    - a) El campo de respaldo de la propiedad
    - b) El valor actual de la propiedad
    - c) Una palabra reservada sin significado en ese contexto
    - d) El valor que se está asignando a la propiedad

28. **¿Qué significa `static` en `public static int CuentasAbiertas`?**
    - a) Que solo se puede usar dentro de la clase
    - b) Que pertenece a la clase y se comparte entre todos los objetos
    - c) Que su valor no puede cambiar
    - d) Que se calcula cada vez que se lee

29. **¿Qué permite la palabra clave `partial` en `public partial class Factura`?**
    - a) Repartir la declaración de la clase en varios ficheros, que el compilador une
    - b) Que la clase tenga métodos sin implementar
    - c) Que solo se pueda instanciar una vez
    - d) Que la clase herede de varias clases a la vez

---

#### Bloque 6: Herencia, interfaces y polimorfismo

30. **¿Qué hace falta en C# para que una clase hija pueda sobrescribir un método de su clase base?**
    - a) Que la base lo declare `virtual` (o `abstract`) y la hija lo declare `override`
    - b) Nada: todos los métodos se pueden sobrescribir
    - c) Que la hija lo declare `new`
    - d) Que los dos métodos sean `static`

31. **¿Cómo se llama al constructor de la clase base desde el constructor de una clase hija?**
    - a) Con `super(…)` en la primera línea
    - b) Con `: base(…)` detrás de la firma del constructor
    - c) Con `this(…)` en la primera línea
    - d) No hace falta: se llama siempre al constructor sin parámetros

32. **¿Qué impide la palabra clave `sealed` en `public sealed class Video : Archivo`?**
    - a) Que otra clase herede de `Video`
    - b) Que `Video` implemente interfaces
    - c) Que se creen objetos de `Video`
    - d) Que `Video` sobrescriba métodos de `Archivo`

33. **¿Qué hace `if (archivo is IPrevisualizable p) { … }`?**
    - a) Comprueba si `archivo` es `null`
    - b) Crea un objeto nuevo que implementa la interfaz
    - c) Convierte el objeto y lanza una excepción si no implementa la interfaz
    - d) Comprueba si el objeto implementa la interfaz y, si es así, lo deja en `p` convertido

34. **Una agenda necesita guardar contactos sin duplicados y ya existe una clase `Repositorio<T>`. ¿Qué diseño es más adecuado?**
    - a) Copiar el código del repositorio dentro de `Agenda`
    - b) Que `Agenda` herede de `Repositorio<Contacto>`
    - c) Que `Agenda` tenga un campo privado de tipo `Repositorio<Contacto>` y le delegue el trabajo
    - d) Que `Repositorio<T>` herede de `Agenda`

35. **¿Cuál es una diferencia entre una clase abstracta y una interfaz en C#?**
    - a) Una clase abstracta no puede tener métodos con implementación
    - b) Una interfaz puede tener campos y constructores
    - c) Una clase solo puede heredar de una clase, pero puede implementar varias interfaces
    - d) Las interfaces se pueden instanciar con `new`

---

#### Bloque 7: Excepciones y tipos que admiten null

36. **¿Qué excepción de .NET es la adecuada cuando un método recibe un importe negativo que no admite?**
    - a) `Exception`
    - b) `ArgumentOutOfRangeException`
    - c) `InvalidOperationException`
    - d) `NullReferenceException`

37. **¿Qué excepción es la adecuada al intentar reparar un coche que no está en reparación?**
    - a) `InvalidOperationException`
    - b) `IndexOutOfRangeException`
    - c) `FormatException`
    - d) `ArgumentNullException`

38. **¿Por qué no se debe relanzar una excepción con `throw ex;` dentro de un `catch`?**
    - a) Porque convierte la excepción en `Exception`
    - b) Porque borra la pila de llamadas original y se pierde dónde ocurrió el error
    - c) Porque el `finally` ya no se ejecuta
    - d) Porque no compila

39. **Si hay dos bloques `catch (ArgumentException)` y `catch (ArgumentOutOfRangeException)`, en ese orden, ¿qué ocurre?**
    - a) Se ejecuta siempre el segundo, que es el más concreto
    - b) Se ejecutan los dos
    - c) Funciona igual que en el orden contrario
    - d) No compila, porque el segundo `catch` nunca se podría ejecutar

40. **¿Qué garantiza la instrucción `using var lector = new StreamReader(ruta);`?**
    - a) Que el fichero existe
    - b) Que el fichero se lee en otro hilo
    - c) Que no se lanzará ninguna excepción al leerlo
    - d) Que se llama a `Dispose` y se cierra el fichero al terminar el bloque, aunque haya una excepción

41. **¿Qué devuelve `socio?.Nombre ?? "desconocido"` si `socio` es `null`?**
    - a) Una cadena vacía
    - b) Lanza `NullReferenceException`
    - c) `"desconocido"`
    - d) `null`

42. **Con los tipos que admiten `null` activados, ¿qué indica el `?` en `public Socio? BuscarSocio(int id)`?**
    - a) Que el método puede devolver `null`, y el compilador avisará si se usa el resultado sin comprobarlo
    - b) Que el método es opcional
    - c) Que el resultado se convierte en un tipo de valor
    - d) Que el método lanza una excepción si no encuentra el socio

---

#### Bloque 8: Genéricos y colecciones

43. **¿Qué ocurre al ejecutar `var precio = precios["Silla"];` si el diccionario `precios` no tiene esa clave?**
    - a) Devuelve 0
    - b) Añade la clave con valor 0
    - c) Se lanza `KeyNotFoundException`
    - d) Devuelve `null`

44. **¿Qué colección es la más adecuada para guardar etiquetas sin repetir y saber rápidamente si una existe?**
    - a) `List<string>`
    - b) `HashSet<string>`
    - c) `Queue<string>`
    - d) `string[]`

45. **Una clase guarda sus tareas en una `List<Tarea>` privada. ¿Cómo debe exponerlas para que desde fuera no se puedan añadir ni quitar?**
    - a) Como una propiedad `public List<Tarea> Tareas { get; }`
    - b) Como una propiedad de tipo `IReadOnlyList<Tarea>`
    - c) Marcando la lista como `readonly`
    - d) Como un campo `public List<Tarea>`

46. **Si una clase sobrescribe `Equals` pero no `GetHashCode`, ¿qué puede pasar?**
    - a) Nada: `GetHashCode` no se usa en las colecciones
    - b) No compila
    - c) Un `HashSet` o un `Dictionary` pueden guardar como distintos dos objetos que son iguales
    - d) `Equals` deja de funcionar

47. **¿Para qué sirve la restricción `where T : IConClave` en `class Repositorio<T> where T : class, IConClave`?**
    - a) Para que `T` pueda ser `null`
    - b) Para que `T` tenga un constructor sin parámetros
    - c) Para poder usar `elemento.Clave` dentro de la clase, porque todo `T` la tiene
    - d) Para que el repositorio solo admita la clase `IConClave`

48. **¿Qué interfaz debe implementar una clase para que `List<T>.Sort()` sin argumentos sepa ordenarla?**
    - a) `IEnumerable<T>`
    - b) `IComparable<T>`
    - c) `IEquatable<T>`
    - d) `IDisposable`

---

#### Bloque 9: Delegados, lambdas y eventos

49. **¿Qué delegado de .NET representa un método que recibe un `decimal` y devuelve un `decimal`?**
    - a) `Predicate<decimal>`
    - b) `Func<decimal, decimal>`
    - c) `Func<decimal>`
    - d) `Action<decimal, decimal>`

50. **¿Qué muestra este código?**

    ```csharp
    var minimo = 5;
    Func<double, bool> aprobado = nota => nota >= minimo;
    minimo = 6;
    Console.WriteLine(aprobado(5.5));
    ```

    - a) No compila: `minimo` no es constante
    - b) Lanza una excepción
    - c) `True`
    - d) `False`

51. **¿Por qué se lanza un evento con `CompletadaCambiada?.Invoke(this, EventArgs.Empty);` y no con `CompletadaCambiada(this, EventArgs.Empty);`?**
    - a) Porque solo así reciben el aviso todos los suscriptores
    - b) Porque sin `?.` el evento se lanzaría dos veces
    - c) Porque `Invoke` es más rápido
    - d) Porque si nadie se ha suscrito el evento vale `null`, y sin `?.` se lanzaría `NullReferenceException`

52. **En un manejador de eventos `void Manejador(object? sender, TareaEventArgs e)`, ¿qué es `sender`?**
    - a) Los datos del evento
    - b) El objeto que se ha suscrito al evento
    - c) El hilo en el que se lanza el evento
    - d) El objeto que ha lanzado el evento

53. **¿Qué impide la palabra clave `event` respecto a un campo público de tipo delegado?**
    - a) Que desde fuera de la clase se sustituyan los suscriptores con `=` o se lance el evento
    - b) Que haya más de un suscriptor
    - c) Que el evento tenga datos
    - d) Que se usen lambdas como manejadores

54. **¿Por qué es importante darse de baja (`-=`) de los eventos de un objeto de vida larga?**
    - a) Porque un objeto solo puede estar suscrito a un evento a la vez
    - b) Porque mientras se esté suscrito, el emisor mantiene una referencia al suscriptor y no se libera su memoria
    - c) Porque si no, el evento deja de lanzarse
    - d) Porque el compilador da un error si no se hace

55. **¿Qué criterio de evaluación del RA1 prepara suscribir un manejador a un evento, como en `temporizador.Elapsed += AlPasarUnSegundo;`?**
    - a) Ubicar los componentes de la interfaz (CE c)
    - b) Asociar a los eventos las acciones correspondientes (CE g)
    - c) Analizar el código generado por el editor visual (CE e)
    - d) Analizar las librerías disponibles (CE a)

---

#### Bloque 10: LINQ

56. **¿Qué hace `alumnos.Where(a => a.Media >= 5).Select(a => a.Nombre).ToList()`?**
    - a) Devuelve `true` si algún alumno está aprobado
    - b) Devuelve una lista nueva con los nombres de los alumnos con media de 5 o más
    - c) Devuelve los alumnos aprobados completos
    - d) Elimina de `alumnos` los que tienen media menor que 5

57. **¿Cómo se ordena por media descendente y, a igualdad de media, por nombre?**
    - a) `OrderByDescending(a => a.Media).ThenBy(a => a.Nombre)`
    - b) `OrderByDescending(a => a.Media).OrderBy(a => a.Nombre)`
    - c) `OrderBy(a => a.Nombre).OrderByDescending(a => a.Media)`
    - d) `Sort(a => a.Media, a => a.Nombre)`

58. **¿Qué diferencia hay entre `First(condicion)` y `FirstOrDefault(condicion)`?**
    - a) `First` devuelve el primero y `FirstOrDefault` el último
    - b) Si ningún elemento cumple la condición, `First` lanza una excepción y `FirstOrDefault` devuelve `null` (o el valor por defecto)
    - c) `FirstOrDefault` ordena antes de buscar
    - d) Ninguna: son sinónimos

59. **¿Qué muestra este código?**

    ```csharp
    var numeros = new List<int> { 1, 2, 3 };
    var pares = numeros.Where(n => n % 2 == 0);
    numeros.Add(4);
    Console.WriteLine(pares.Count());
    ```

    - a) Lanza una excepción
    - b) `1`
    - c) `0`
    - d) `2`

60. **¿Qué método de LINQ se usa para obtener, por ejemplo, el número de alumnos de cada curso?**
    - a) `Select`
    - b) `Distinct`
    - c) `Aggregate`
    - d) `GroupBy`

61. **¿Qué hace `JsonSerializerDefaults.Web` al leer un JSON con `System.Text.Json`?**
    - a) Descarga el JSON de una URL
    - b) Ordena las propiedades alfabéticamente
    - c) Permite leer ficheros XML
    - d) Empareja las propiedades del JSON en `camelCase` (`nombre`) con las de C# en `PascalCase` (`Nombre`)

---

#### Bloque 11: Programación asíncrona

62. **¿Qué le pasa a un programa cuyo código espera una operación lenta de forma síncrona (por ejemplo, con `Thread.Sleep`)?**
    - a) El sistema operativo cierra el programa
    - b) El hilo queda bloqueado esperando y no puede hacer nada más hasta que termine la operación
    - c) El hilo sigue ejecutando el resto del código mientras espera
    - d) La operación se ejecuta automáticamente en otro hilo

63. **¿Qué hace `await Task.Delay(1000);`?**
    - a) Bloquea el hilo un segundo, como `Thread.Sleep(1000)`
    - b) Espera un segundo sin bloquear el hilo
    - c) Crea un hilo nuevo que espera un segundo
    - d) Cancela la tarea al cabo de un segundo

64. **¿Qué debe devolver un método asíncrono que no devuelve ningún valor y no es un manejador de eventos?**
    - a) `object`
    - b) `Task`
    - c) `Task<void>`
    - d) `void`

65. **¿Qué excepción indica que una operación asíncrona se ha cancelado con un `CancellationToken`?**
    - a) `TaskSchedulerException`
    - b) `InvalidOperationException`
    - c) `OperationCanceledException`
    - d) `TimeoutException`

66. **¿Por qué no se debe usar `.Result` para obtener el resultado de una tarea?**
    - a) Porque bloquea el hilo mientras espera y, en algunos programas, puede dejarlo bloqueado para siempre
    - b) Porque devuelve siempre `null`
    - c) Porque `.Result` no existe en `Task<T>`
    - d) Porque lanza siempre una excepción

67. **¿Qué permite `Task.WhenAll(tareas)`?**
    - a) Esperar solo a la primera que termine
    - b) Ejecutar las tareas una detrás de otra
    - c) Esperar a que terminen varias tareas lanzadas a la vez
    - d) Cancelar todas las tareas

---

#### Bloque 12: Depurar, documentar y probar

68. **En el depurador de Visual Studio, ¿qué diferencia hay entre F10 y F11?**
    - a) Ninguna: los dos avanzan una línea
    - b) F10 continúa hasta el siguiente punto de interrupción; F11 detiene la depuración
    - c) F10 ejecuta la línea sin entrar en los métodos que llama; F11 entra en ellos
    - d) F10 pone un punto de interrupción; F11 lo quita

69. **En la traza de una excepción, ¿qué indica la primera línea que empieza por `at`?**
    - a) El método donde se lanzó la excepción
    - b) El método que capturó la excepción
    - c) El último método que se ejecutó correctamente
    - d) El método `Main` del programa

70. **¿Qué etiqueta de los comentarios XML documenta las excepciones que puede lanzar un método?**
    - a) `<exception cref="…">`
    - b) `<returns>`
    - c) `<throws>`
    - d) `<remarks>`

71. **¿Qué es un `[Theory]` en xUnit?**
    - a) Una prueba que se ejecuta en paralelo con las demás
    - b) Una prueba que todavía no está terminada
    - c) Una prueba con parámetros que se ejecuta una vez por cada `[InlineData]`
    - d) Una prueba que no comprueba nada

72. **En `Assert.Equal(a, b)`, ¿qué debe ser `a`?**
    - a) El mensaje de error
    - b) El valor esperado
    - c) El valor obtenido
    - d) Indiferente: el orden no importa para nada

73. **Para corregir un fallo del que avisa un usuario, ¿qué se hace primero según el ciclo visto en el tema?**
    - a) Corregir el código y después ejecutar el programa
    - b) Capturar la excepción para que el usuario no la vea
    - c) Escribir una prueba que reproduzca el fallo y comprobar que falla
    - d) Añadir `Console.WriteLine` en todos los métodos

---
