# C# para quien viene de Java

[⬅️ Volver al tema 2](../02-desde-otros-lenguajes.md) · [⬅️ Volver a la unidad](../README.md)

Guía opcional para quien aprendió a programar con **Java**. Compara los dos lenguajes bloque a bloque, en el **mismo orden que los temas de la unidad**, con código lado a lado. No sustituye a los temas: te ayuda a leerlos más deprisa, fijándote en lo que cambia.

## Índice

- [1. Antes de empezar](#1-antes-de-empezar)
- [2. Tabla rápida de equivalencias](#2-tabla-rápida-de-equivalencias)
- [3. Plataforma y herramientas](#3-plataforma-y-herramientas)
- [4. Estructura de un programa](#4-estructura-de-un-programa)
- [5. Tipos, cadenas y operadores](#5-tipos-cadenas-y-operadores)
- [6. Control de flujo](#6-control-de-flujo)
- [7. Métodos](#7-métodos)
- [8. Clases y propiedades](#8-clases-y-propiedades)
- [9. Herencia e interfaces](#9-herencia-e-interfaces)
- [10. Excepciones](#10-excepciones)
- [11. `null`](#11-null)
- [12. Genéricos y colecciones](#12-genéricos-y-colecciones)
- [13. Lambdas, delegados y eventos](#13-lambdas-delegados-y-eventos)
- [14. De las *Streams* a LINQ](#14-de-las-streams-a-linq)
- [15. Asincronía](#15-asincronía)
- [16. Pruebas: de JUnit a xUnit](#16-pruebas-de-junit-a-xunit)
- [17. Los errores típicos de quien viene de Java](#17-los-errores-típicos-de-quien-viene-de-java)

---

## 1. Antes de empezar

C# y Java son **primos hermanos**: los dos nacieron en la familia de C, son orientados a objetos, se compilan a un código intermedio que ejecuta una máquina virtual con recolector de basura, y tienen genéricos, excepciones, lambdas e interfaces. Si sabes Java, **ya sabes leer casi todo el código de C#**.

Las diferencias que más se notan:

1. **Convenciones**: en C#, los métodos y las propiedades públicas van en `PascalCase` (`lista.Count`, `Console.WriteLine`, `cuenta.Ingresar(50)`).
2. **Propiedades** en lugar de *getters* y *setters*.
3. **`virtual`**: los métodos no se pueden sobrescribir salvo que la clase base lo permita.
4. **No hay excepciones comprobadas**.
5. **Tipos de valor propios** (`struct`) y genéricos sin borrado de tipos: `List<int>` funciona.
6. **Eventos**, **LINQ** y **`async`/`await`** forman parte del lenguaje.
7. **Avisos de `null`** del compilador.

> 📝 **Nota del Profesor**: El mayor riesgo al pasar de Java a C# no es que el código no compile, sino escribir «Java con sintaxis de C#»: `getSaldo()`, `camelCase` en los métodos, bucles donde iría LINQ, interfaces de *listener* donde iría un evento. Funciona, pero cualquier programador de C# lo leerá con dificultad.

---

## 2. Tabla rápida de equivalencias

| Java | C# | Tema |
|------|----|------|
| JVM, *bytecode* (`.class`, `.jar`) | CLR, IL (`.dll`, `.exe`) | 1 |
| JDK / JRE | SDK de .NET / entorno de ejecución | 1 |
| Maven / Gradle (`pom.xml`, `build.gradle`) | MSBuild y NuGet (`.csproj`) | 1 |
| `package com.tienda;` + carpetas | `namespace Tienda;` (sin relación obligatoria con las carpetas) | 3 |
| `import java.util.List;` | `using System.Collections.Generic;` | 3 |
| `public static void main(String[] args)` | Instrucciones de nivel superior, o `static void Main(string[] args)` | 3 |
| `System.out.println("Hola")` | `Console.WriteLine("Hola")` | 3 |
| `String` | `string` (alias de `System.String`) | 3 |
| `boolean` | `bool` | 3 |
| `BigDecimal` | `decimal` (tipo primitivo, con operadores) | 3 |
| `final int MAX = 10;` | `const int Max = 10;` o `readonly` | 3, 5 |
| `String.format("%.2f", x)` | `$"{x:F2}"` | 3 |
| `Integer.parseInt(s)` + `try/catch` | `int.TryParse(s, out var n)` | 3 |
| `for (String s : lista)` | `foreach (var s in lista)` | 4 |
| `int[][] m = new int[3][4];` | `int[,] m = new int[3, 4];` (rectangular) o `int[][]` | 4 |
| Sobrecarga para simular parámetros opcionales | Parámetros opcionales y con nombre | 4 |
| `int... numeros` | `params int[] numeros` | 4 |
| `getNombre()` / `setNombre(…)` | Propiedad `Nombre { get; set; }` | 5 |
| Sin modificador (paquete) | `internal` (proyecto); sin modificador = `private` | 5 |
| `record Punto(int x, int y)` | `record Punto(int X, int Y)` | 5 |
| `enum` con campos y métodos | `enum` (solo valores) + `record`/clase si hace falta más | 5 |
| `toString()`, `equals()`, `hashCode()` | `ToString()`, `Equals()`, `GetHashCode()` | 5, 8 |
| `extends` / `implements` | `:` | 6 |
| `super(…)` / `super.metodo()` | `: base(…)` / `base.Metodo()` | 6 |
| `@Override` (anotación opcional) | `override` (obligatorio) + `virtual` en la base | 6 |
| `final class` | `sealed class` | 6 |
| `x instanceof Documento d` | `x is Documento d` | 6 |
| `throws IOException` | — (no existe) | 7 |
| `try (var r = new …) { }` | `using (var r = new …) { }` o `using var r = …;` | 7 |
| `catch (A \| B e)` | `catch (Exception e) when (e is A or B)` | 7 |
| `IllegalArgumentException` | `ArgumentException` | 7 |
| `IllegalStateException` | `InvalidOperationException` | 7 |
| `NullPointerException` | `NullReferenceException` | 7 |
| `Optional<T>` | `T?` y los operadores `?.` y `??` | 7 |
| `ArrayList<T>`, `HashMap<K,V>`, `HashSet<T>` | `List<T>`, `Dictionary<TKey,TValue>`, `HashSet<T>` | 8 |
| `lista.size()`, `array.length`, `s.length()` | `lista.Count`, `array.Length`, `s.Length` | 8 |
| `Comparable<T>` / `Comparator<T>` | `IComparable<T>` / `IComparer<T>` o `Comparison<T>` | 8 |
| `Runnable`, `Supplier<T>`, `Consumer<T>`, `Function<T,R>` | `Action`, `Func<T>`, `Action<T>`, `Func<T,R>` | 9 |
| `x -> x * 2` | `x => x * 2` | 9 |
| `Clase::metodo` | `Metodo` (grupo de métodos) | 9 |
| `addActionListener(…)` (interfaz *listener*) | `Click += …` (evento) | 9 |
| `stream().filter().map().collect(toList())` | `Where().Select().ToList()` | 10 |
| `CompletableFuture<T>` | `Task<T>` con `async`/`await` | 11 |
| `Thread.sleep(1000)` | `await Task.Delay(1000)` (o `Thread.Sleep`, que bloquea) | 11 |
| JUnit: `@Test`, `@ParameterizedTest` | xUnit: `[Fact]`, `[Theory]` + `[InlineData]` | 12 |
| Javadoc (`/** … */`, `@param`) | Comentarios XML (`/// <param>`) | 12 |

---

## 3. Plataforma y herramientas

*Tema 1.*

| Java | C# / .NET |
|------|-----------|
| `javac` compila a *bytecode*; la JVM lo ejecuta con un JIT | `csc` (vía `dotnet build`) compila a IL; el CLR lo ejecuta con un JIT |
| Un `.jar` agrupa clases | Un **ensamblado** (`.dll` o `.exe`) agrupa tipos |
| Maven o Gradle: dependencias, compilación, pruebas | El `.csproj` (MSBuild) y **NuGet** para los paquetes; la CLI `dotnet` |
| IntelliJ IDEA, Eclipse | **Visual Studio** (también Rider o VS Code) |
| Versiones LTS de Java (cada dos años) | Versiones LTS de .NET (las pares, cada dos años) |

Atajos que te costará cambiar si vienes de IntelliJ:

| IntelliJ | Visual Studio |
|----------|---------------|
| Alt+Intro (acciones rápidas) | **Ctrl+.** |
| Ctrl+Alt+L (formatear) | **Ctrl+K, Ctrl+D** |
| Mayús+F6 (renombrar) | **Ctrl+R, Ctrl+R** |
| Ctrl+B (ir a la definición) | **F12** |
| Mayús+F10 / Mayús+F9 (ejecutar / depurar) | **Ctrl+F5** / **F5** |
| F8 / F7 (paso a paso) | **F10** / **F11** |

---

## 4. Estructura de un programa

*Tema 3.*

```java
// Java: Programa.java
package com.ejemplo;

import java.util.Scanner;

public class Programa {
    public static void main(String[] args) {
        System.out.println("Hola, 2DAM");
    }
}
```

```csharp
// C#: Program.cs, con instrucciones de nivel superior
Console.WriteLine("Hola, 2DAM");
```

- En Java, una clase pública **tiene** que estar en un fichero con su nombre y en una carpeta que coincide con su paquete. En C# **no es obligatorio** (aunque es la convención: un tipo público por fichero, con su nombre).
- `namespace` no tiene que coincidir con las carpetas, aunque por convención las sigue. Se declara con ámbito de fichero: `namespace Banco.Logica;`.
- `using` importa un **espacio de nombres completo**, no una clase: no existe `using System.Collections.Generic.List;`. Con los *implicit usings*, los más comunes ya están importados.
- Un fichero puede declarar varios tipos.

---

## 5. Tipos, cadenas y operadores

*Tema 3.*

### Tipos primitivos

| Java | C# | Diferencia |
|------|----|-----------|
| `int`, `long`, `short`, `byte` | `int`, `long`, `short`, **`sbyte`** | En C#, `byte` es **sin signo** (0-255) |
| — | `uint`, `ulong`, `ushort` | C# tiene enteros sin signo |
| `double`, `float` | `double`, `float` | Igual |
| `BigDecimal` (clase) | **`decimal`** (tipo de valor con operadores) | `precio * 1.21m` en lugar de `precio.multiply(new BigDecimal("1.21"))`. La `m` final es el sufijo que hace que el literal sea `decimal`, como la `L` de `long` o la `f` de `float`, que ya conoces (tema 3) |
| `boolean` | `bool` | |
| `char` | `char` | Igual (UTF-16) |
| `Integer`, `Double`… (envoltorios) | — | No hacen falta: `List<int>` funciona directamente |
| `Integer x = null;` | `int? x = null;` | Tipo de valor que admite `null` |

En C#, `int` es un alias de `System.Int32`, que es un `struct` con métodos: `int.Parse`, `int.MaxValue`, `5.ToString()`. No hay envoltorios separados.

### Cadenas

```java
// Java
String nombre = "Ana";
boolean iguales = nombre.equals("Ana");               // == compara referencias
String texto = String.format("%s tiene %d años", nombre, 20);
String json = """
    { "nombre": "Ana" }
    """;
```

```csharp
// C#
string nombre = "Ana";
bool iguales = nombre == "Ana";                        // == compara el CONTENIDO
var texto = $"{nombre} tiene {20} años";              // interpolación
var json = """
    { "nombre": "Ana" }
    """;                                               // literal sin procesar (C# 11)
```

> ⚠️ **Cuidado**: En Java, comparar cadenas con `==` es un error clásico. En C#, `==` compara el contenido de los `string` y es lo correcto. Para no distinguir mayúsculas: `string.Equals(a, b, StringComparison.OrdinalIgnoreCase)` (el `equalsIgnoreCase` de Java).

Métodos con otro nombre: `length()` → `Length` (propiedad), `charAt(i)` → `[i]`, `substring(a, b)` → `[a..b]` o `Substring(a, longitud)` (¡el segundo parámetro es la **longitud**, no el final!), `isEmpty()` → `string.IsNullOrEmpty(s)`, `isBlank()` → `string.IsNullOrWhiteSpace(s)`, `strip()` → `Trim()`.

### Constantes

| Java | C# |
|------|----|
| `static final int MAX = 10;` | `const int Max = 10;` (valor conocido al compilar) |
| `static final List<String> NOMBRES = List.of(…);` | `static readonly List<string> _nombres = […];` |
| `final` en un campo de instancia | `readonly` |
| `final` en una variable local | — (no existe; se usa `const` si es una constante) |

### Tipos de valor propios

Java solo tiene los primitivos como tipos de valor (hasta los *value classes* futuros). En C# puedes crear los tuyos con **`struct`**: se copian al asignar, como un `int`. `DateTime`, `TimeSpan` o `decimal` son `struct`. Lo usarás poco, pero tienes que saber que existen.

### Conversiones

```java
// Java
try {
    int edad = Integer.parseInt(texto);
} catch (NumberFormatException e) {
    // no es un número
}
```

```csharp
// C#
if (int.TryParse(texto, out var edad))
{
    // es un número: edad tiene el valor
}
```

---

## 6. Control de flujo

*Tema 4.*

Casi idéntico. Las diferencias:

```java
// Java
for (String nombre : nombres) { … }

switch (opcion) {
    case "1": mostrar(); break;
    case "2": reservar(); // sin break: cae al case "0" (error clásico)
    case "0": salir = true; break;
}

String calificacion = switch ((int) nota) {
    case 0, 1, 2, 3, 4 -> "Insuficiente";
    case 5 -> "Suficiente";
    default -> "Otra";
};
```

```csharp
// C#
foreach (var nombre in nombres) { … }

switch (opcion)
{
    case "1": Mostrar(); break;
    case "2": Reservar(); break;   // obligatorio: C# no deja caer de un case con código al siguiente
    case "0": salir = true; break;
}

var calificacion = nota switch
{
    < 5 => "Insuficiente",          // patrones relacionales, sin convertir a int
    < 6 => "Suficiente",
    _ => "Otra",
};
```

- La condición de un `if` tiene que ser `bool` en los dos.
- C# tiene **matrices rectangulares** (`int[,]`) además de las escalonadas (`int[][]`, las de Java). Para las dimensiones: `GetLength(0)` y `GetLength(1)`.
- Índices desde el final (`array[^1]`) y rangos (`array[1..3]`) no existen en Java.
- No hay `break` con etiqueta; se usa un método y `return` (o, si no queda más remedio, `goto`).

---

## 7. Métodos

*Tema 4.*

| Java | C# |
|------|----|
| `public int calcularTotal()` | `public int CalcularTotal()` (**PascalCase**) |
| Sobrecarga para simular opcionales | Parámetros opcionales: `void Exportar(string ruta, bool cabecera = true)` |
| — | Argumentos con nombre: `Exportar(ruta, cabecera: false)` |
| `int... numeros` | `params int[] numeros` |
| Devolver varios valores: una clase o un array | **Tuplas**: `(int Min, int Max) Rango()` |
| — | Parámetros `out` y `ref` |

En Java, todo se pasa por valor y no hay forma de que un método cambie una variable de quien lo llama. C# tiene **`out`** (el método asigna la variable) y **`ref`**. El uso más habitual es el patrón `TryXxx`:

```csharp
public static bool TryParseCodigo(string texto, out int fila, out int columna) { … }

if (TryParseCodigo("C5", out var fila, out var columna)) { … }
```

---

## 8. Clases y propiedades

*Tema 5.*

### Propiedades en lugar de *getters* y *setters*

```java
// Java
public class Cuenta {
    private BigDecimal saldo = BigDecimal.ZERO;
    private String titular;

    public BigDecimal getSaldo() { return saldo; }

    public String getTitular() { return titular; }
    public void setTitular(String titular) {
        if (titular == null || titular.isBlank()) {
            throw new IllegalArgumentException("Titular vacío");
        }
        this.titular = titular.strip();
    }
}

cuenta.setTitular("Ana");
System.out.println(cuenta.getSaldo());
```

```csharp
// C#
public class Cuenta
{
    private string _titular = "";

    public decimal Saldo { get; private set; }     // se lee desde fuera; cambia solo dentro

    public string Titular
    {
        get => _titular;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Titular vacío.", nameof(Titular));
            }

            _titular = value.Trim();
        }
    }
}

cuenta.Titular = "Ana";            // llama al set
Console.WriteLine(cuenta.Saldo);   // llama al get
```

> 💡 **Tip del Examinador**: Una propiedad **parece** un campo público, pero **es** un par de métodos. Por eso en C# los datos públicos se exponen **siempre** con propiedades: puedes añadir una validación más tarde sin cambiar el código que las usa. Y por eso **no** se escriben métodos `GetSaldo()`.

### Modificadores de acceso

| Java | C# |
|------|----|
| `public` | `public` |
| `private` | `private` |
| `protected` (clase, hijas **y paquete**) | `protected` (clase e hijas, **sin** paquete) |
| (sin modificador): paquete | `internal`: todo el **proyecto** |
| Miembro sin modificador: paquete | Miembro sin modificador: **`private`** |

### Constructores

```java
public Producto(String nombre) { this(nombre, 0); }        // Java
```

```csharp
public Producto(string nombre) : this(nombre, 0) { }       // C#: detrás de la firma
```

C# 12 añade los **constructores primarios**: `public class Tarea(string titulo) { … }`.

C# tiene además **inicializadores de objeto** y propiedades **`init`**, que no existen en Java:

```csharp
var cuenta = new CuentaBancaria("Ana") { FechaApertura = new DateOnly(2020, 1, 15) };
```

### `record`

Los dos lenguajes tienen `record` con igualdad por valor. En C#, las propiedades van en `PascalCase` (`record Punto(int X, int Y)`, se usa `p.X`, no `p.x()`), y se pueden copiar con cambios: `var q = p with { X = 5 };`.

### Enumeraciones

Un `enum` de Java es una clase: puede tener campos, constructores y métodos. Un `enum` de C# es **solo un conjunto de valores enteros con nombre**. Si necesitas datos asociados, usa un `record` o una clase con instancias estáticas, o un método de extensión.

```java
// Java
enum Pista {
    PADEL(12), TENIS(15);
    private final int precio;
    Pista(int precio) { this.precio = precio; }
    int getPrecio() { return precio; }
}
```

```csharp
// C#: el enum solo da los valores; los datos van aparte
public enum TipoPista { Padel, Tenis }

public record Pista(int Numero, TipoPista Tipo, decimal PrecioHora);
```

### Clases anidadas

Una clase anidada de C# equivale a una clase anidada **`static`** de Java: **no** tiene acceso implícito a una instancia de la clase que la contiene. No existen las *inner classes* de Java ni las clases anónimas (para eso se usan las lambdas).

---

## 9. Herencia e interfaces

*Tema 6.*

```java
// Java
public abstract class Archivo {
    protected Archivo(String nombre) { … }
    public abstract String getTipo();
    public String getIcono() { return "📄"; }       // cualquier método se puede sobrescribir
}

public final class Video extends Archivo implements Reproducible {
    public Video(String nombre) { super(nombre); }
    @Override public String getTipo() { return "vídeo"; }
    @Override public String getIcono() { return "🎬"; }
}
```

```csharp
// C#
public abstract class Archivo
{
    protected Archivo(string nombre) { … }
    public abstract string Tipo { get; }
    public virtual string Icono => "📄";            // hay que marcarlo virtual para poder sobrescribirlo
}

public sealed class Video : Archivo, IReproducible
{
    public Video(string nombre) : base(nombre) { }
    public override string Tipo => "vídeo";
    public override string Icono => "🎬";
}
```

> ⚠️ **Cuidado**: Es **la** diferencia más importante de este bloque. En Java, todos los métodos son virtuales salvo que sean `final`. En C#, **ninguno** lo es salvo que se marque `virtual` (o `abstract`). Si en la clase hija escribes un método con el mismo nombre sin `override`, **no** sobrescribe: **oculta** el de la base, y el polimorfismo deja de funcionar. El compilador te avisa (`CS0114`); no ignores ese aviso.

| Java | C# |
|------|----|
| `extends Base implements I1, I2` | `: Base, I1, I2` (la clase base, primero) |
| `super(…)` en la primera línea del constructor | `: base(…)` detrás de la firma |
| `super.metodo()` | `base.Metodo()` |
| `@Override` (opcional) | `override` (obligatorio) |
| `final class` / `final` en un método | `sealed class` / `sealed override` |
| Interfaces con `default` | Interfaces con implementación por defecto (C# 8) |
| `if (x instanceof Documento d)` | `if (x is Documento d)` |
| Nombres de interfaces sin prefijo (`Comparable`) | Con **`I`** (`IComparable`) |

---

## 10. Excepciones

*Tema 7.*

C# **no tiene excepciones comprobadas**. No hay cláusula `throws` ni obligación de capturar: las excepciones que lanza un método se documentan con `/// <exception>`.

```java
// Java
public String leer(String ruta) throws IOException {
    try (var lector = new BufferedReader(new FileReader(ruta))) {
        return lector.readLine();
    } catch (FileNotFoundException | SecurityException e) {
        throw new IllegalStateException("No se puede leer " + ruta, e);
    }
}
```

```csharp
// C#
/// <exception cref="InvalidOperationException">Si no se puede leer el fichero.</exception>
public string? Leer(string ruta)
{
    try
    {
        using var lector = new StreamReader(ruta);
        return lector.ReadLine();
    }
    catch (Exception ex) when (ex is FileNotFoundException or UnauthorizedAccessException)
    {
        throw new InvalidOperationException($"No se puede leer {ruta}", ex);
    }
}
```

| Java | C# |
|------|----|
| `IllegalArgumentException` | `ArgumentException` (y sus hijas `ArgumentNullException`, `ArgumentOutOfRangeException`) |
| `IllegalStateException` | `InvalidOperationException` |
| `NullPointerException` | `NullReferenceException` |
| `ArrayIndexOutOfBoundsException` | `IndexOutOfRangeException` |
| `IndexOutOfBoundsException` (listas) | `ArgumentOutOfRangeException` |
| `NumberFormatException` | `FormatException` |
| `UnsupportedOperationException` | `NotSupportedException` (o `NotImplementedException` si aún no está hecho) |
| `NoSuchElementException` | `InvalidOperationException` (`First()` sin elementos) o `KeyNotFoundException` |
| `Objects.requireNonNull(x)` | `ArgumentNullException.ThrowIfNull(x)` |
| `throw e;` dentro de un `catch` (conserva la traza) | **`throw;`** (`throw ex;` **borra** la traza) |

---

## 11. `null`

*Tema 7.*

Java usa `Optional<T>` (sobre todo como tipo de retorno) para indicar que puede no haber valor. C# lo resuelve en el sistema de tipos, con ayuda del compilador:

```java
// Java
Optional<Socio> socio = club.buscar(id);
String nombre = socio.map(Socio::getNombre).orElse("desconocido");
```

```csharp
// C#
Socio? socio = club.Buscar(id);                       // el ? indica que puede ser null
var nombre = socio?.Nombre ?? "desconocido";          // ?. y ??
```

Con `<Nullable>enable</Nullable>` (activado por defecto), el compilador **avisa** si usas algo que puede ser `null` sin comprobarlo (`CS8602`) o si asignas un posible `null` a algo que no lo admite (`CS8600`). Trata esos avisos como errores.

---

## 12. Genéricos y colecciones

*Tema 8.*

### Genéricos sin borrado de tipos

En Java, los genéricos se **borran** al compilar: `List<Integer>` y `List<String>` son la misma clase en ejecución, y no se pueden usar primitivos (`List<int>` no existe). En C#, los genéricos **existen en ejecución**: `List<int>` guarda enteros sin convertirlos en objetos, y se puede hacer `new T()` (con la restricción `new()`) o `typeof(T)`.

| Java | C# |
|------|----|
| `<T extends Comparable<T>>` | `where T : IComparable<T>` |
| `<T extends Base & Interfaz>` | `where T : Base, IInterfaz` |
| `? extends T` / `? super T` (comodines) | Varianza en las interfaces (`IEnumerable<out T>`): `IEnumerable<Documento>` sirve donde se pide `IEnumerable<Archivo>` |

### Colecciones

| Java | C# |
|------|----|
| `List<T>` (interfaz) / `ArrayList<T>` | `IList<T>` / **`List<T>`** |
| `Map<K,V>` / `HashMap<K,V>` | `IDictionary<K,V>` / **`Dictionary<TKey,TValue>`** |
| `Set<T>` / `HashSet<T>` | `ISet<T>` / **`HashSet<T>`** |
| `TreeMap<K,V>` | `SortedDictionary<TKey,TValue>` |
| `ArrayDeque<T>` como cola / pila | `Queue<T>` / `Stack<T>` |
| `Collections.unmodifiableList(l)` | Exponer como `IReadOnlyList<T>` |
| `List.of(1, 2, 3)` (inmutable) | `[1, 2, 3]` (expresión de colección, C# 12; el tipo lo decide el destino) |
| `lista.size()` / `array.length` | `lista.Count` / `array.Length` |
| `lista.get(i)` / `lista.set(i, x)` | `lista[i]` / `lista[i] = x` |
| `map.get(k)` devuelve `null` si no existe | `dic[k]` **lanza** `KeyNotFoundException`; usa `TryGetValue` o `GetValueOrDefault` |
| `map.put(k, v)` | `dic[k] = v` |
| `map.putIfAbsent(k, v)` | `dic.TryAdd(k, v)` |
| `for (var e : map.entrySet())` | `foreach (var (clave, valor) in dic)` |

### Igualdad y orden

| Java | C# |
|------|----|
| `equals(Object o)` + `hashCode()` | `Equals(object? obj)` + `GetHashCode()` (e implementar `IEquatable<T>`) |
| `Comparable<T>.compareTo` | `IComparable<T>.CompareTo` |
| `Comparator<T>` / `Comparator.comparing(Socio::getNombre)` | `IComparer<T>`, `Comparison<T>` o, más habitual, LINQ: `OrderBy(s => s.Nombre)` |

---

## 13. Lambdas, delegados y eventos

*Tema 9.*

### Interfaces funcionales y delegados

Java representa una función con una **interfaz funcional** (una interfaz con un solo método abstracto). C# tiene un tipo propio para eso: el **delegado**. Los equivalentes de las más usadas:

| Java (`java.util.function`) | C# |
|-----------------------------|----|
| `Runnable` | `Action` |
| `Supplier<T>` | `Func<T>` |
| `Consumer<T>` | `Action<T>` |
| `BiConsumer<T, U>` | `Action<T, U>` |
| `Function<T, R>` | `Func<T, R>` |
| `BiFunction<T, U, R>` | `Func<T, U, R>` |
| `Predicate<T>` | `Predicate<T>` o `Func<T, bool>` |
| `UnaryOperator<T>` | `Func<T, T>` |
| `Comparator<T>` | `Comparison<T>` |

| Java | C# |
|------|----|
| `x -> x * 2` | `x => x * 2` |
| `(a, b) -> { return a + b; }` | `(a, b) => { return a + b; }` |
| `String::trim`, `this::guardar` | Grupo de métodos: `Guardar` (sin paréntesis) |

> ⚠️ **Cuidado**: En Java, una lambda solo puede usar variables locales **efectivamente finales**. En C#, una lambda **captura la variable** y puede leerla e incluso **cambiarla**, y ve los cambios que se hagan después. Es más potente, pero puede sorprenderte: si la variable cambia después de crear la lambda, la lambda verá el valor nuevo.

### Eventos en lugar de *listeners*

En Java (Swing, Android), para que un objeto avise a otros se define una **interfaz *listener*** y una lista de suscriptores con métodos `addXxxListener` y `removeXxxListener`. En C#, los **eventos** son parte del lenguaje:

```java
// Java
public interface TareaListener {
    void completadaCambiada(Tarea tarea);
}

public class Tarea {
    private final List<TareaListener> listeners = new ArrayList<>();
    public void addTareaListener(TareaListener l) { listeners.add(l); }
    public void removeTareaListener(TareaListener l) { listeners.remove(l); }

    public void setCompletada(boolean valor) {
        this.completada = valor;
        for (var l : listeners) l.completadaCambiada(this);
    }
}

tarea.addTareaListener(t -> System.out.println("Cambiada: " + t.getTitulo()));
```

```csharp
// C#
public class Tarea
{
    public event EventHandler? CompletadaCambiada;     // la lista de suscriptores la gestiona el lenguaje

    public bool Completada
    {
        get => _completada;
        set
        {
            _completada = value;
            CompletadaCambiada?.Invoke(this, EventArgs.Empty);
        }
    }
}

tarea.CompletadaCambiada += (sender, e) => Console.WriteLine("Cambiada");   // add…Listener
tarea.CompletadaCambiada -= MiManejador;                                    // remove…Listener
```

---

## 14. De las *Streams* a LINQ

*Tema 10.*

| Java Stream | C# LINQ |
|-------------|---------|
| `lista.stream()` | No hace falta: LINQ funciona sobre cualquier `IEnumerable<T>` |
| `filter(p)` | `Where(p)` |
| `map(f)` | `Select(f)` |
| `flatMap(f)` | `SelectMany(f)` |
| `sorted(Comparator.comparing(f))` | `OrderBy(f)` |
| `.thenComparing(g)` | `.ThenBy(g)` |
| `sorted(...reversed())` | `OrderByDescending(f)` |
| `distinct()` | `Distinct()` |
| `limit(n)` / `skip(n)` | `Take(n)` / `Skip(n)` |
| `collect(Collectors.toList())` / `toList()` | `ToList()` |
| `collect(Collectors.toMap(k, v))` | `ToDictionary(k, v)` |
| `collect(Collectors.groupingBy(f))` | `GroupBy(f)` |
| `count()` | `Count()` |
| `mapToInt(f).sum()` | `Sum(f)` |
| `mapToDouble(f).average().orElse(0)` | `Average(f)` (lanza si está vacía) |
| `max(Comparator.comparing(f))` | `MaxBy(f)` |
| `anyMatch` / `allMatch` / `noneMatch` | `Any` / `All` / `!Any` |
| `findFirst()` (devuelve `Optional`) | `FirstOrDefault()` (devuelve `null`) |
| `reduce(…)` | `Aggregate(…)` |

```java
// Java
List<String> nombres = alumnos.stream()
    .filter(a -> a.getMedia() >= 5)
    .sorted(Comparator.comparing(Alumno::getNombre))
    .map(Alumno::getNombre)
    .toList();
```

```csharp
// C#
var nombres = alumnos
    .Where(a => a.Media >= 5)
    .OrderBy(a => a.Nombre)
    .Select(a => a.Nombre)
    .ToList();
```

Una diferencia práctica: una *Stream* de Java **solo se puede recorrer una vez**. Una consulta LINQ se puede recorrer varias veces… y **se vuelve a ejecutar** cada vez (ejecución diferida). Por eso, si vas a usar el resultado más de una vez, materialízalo con `ToList()`.

---

## 15. Asincronía

*Tema 11.*

```java
// Java
CompletableFuture<Factura> futura = CompletableFuture.supplyAsync(() -> leer(1));
futura.thenAccept(f -> System.out.println(f));     // encadenar callbacks
Factura f = futura.join();                           // o bloquear esperando
```

```csharp
// C#
Factura f = await LeerAsync(1);                      // espera sin bloquear, con código lineal
Console.WriteLine(f);
```

| Java | C# |
|------|----|
| `CompletableFuture<T>` | `Task<T>` |
| `thenApply`, `thenAccept`, `thenCompose` | `await` (el código sigue en la línea siguiente) |
| `CompletableFuture.allOf(…)` | `Task.WhenAll(…)` |
| `ExecutorService.submit(…)` | `Task.Run(…)` |
| `Thread.sleep(ms)` | `await Task.Delay(ms)` |
| `future.cancel(true)` | `CancellationTokenSource.Cancel()` (cooperativa) |
| Hilos virtuales (Java 21) | `async`/`await` |

---

## 16. Pruebas: de JUnit a xUnit

*Tema 12.*

```java
// JUnit 5
class CalculadoraTest {
    @Test
    void calcula_la_nota_ponderada() {
        assertEquals(7.40, Calculadora.calcular(6, 8, 7, 9), 0.001);
    }

    @ParameterizedTest
    @CsvSource({"4.99, Insuficiente", "5, Suficiente"})
    void calificacion(double nota, String esperada) {
        assertEquals(esperada, Calculadora.calificacion(nota));
    }

    @Test
    void nota_fuera_de_rango() {
        assertThrows(IllegalArgumentException.class, () -> Calculadora.calcular(11, 0, 0, 0));
    }
}
```

```csharp
// xUnit
public class CalculadoraNotaPruebas
{
    [Fact]
    public void Calcular_ConNotasDelEnunciado_DevuelveNotaPonderada()
    {
        Assert.Equal(7.40, CalculadoraNota.Calcular(6, 8, 7, 9));
    }

    [Theory]
    [InlineData(4.99, "Insuficiente")]
    [InlineData(5, "Suficiente")]
    public void Calificacion_SegunLaNota_DevuelveSuTexto(double nota, string esperada)
    {
        Assert.Equal(esperada, CalculadoraNota.Calificacion(nota));
    }

    [Fact]
    public void Calcular_ConNotaFueraDeRango_LanzaExcepcion()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => CalculadoraNota.Calcular(11, 0, 0, 0));
    }
}
```

| JUnit 5 | xUnit |
|---------|-------|
| `@Test` | `[Fact]` |
| `@ParameterizedTest` + `@ValueSource` / `@CsvSource` | `[Theory]` + `[InlineData]` |
| `@BeforeEach` | El **constructor** de la clase de pruebas (xUnit crea una instancia por prueba) |
| `@AfterEach` | Implementar `IDisposable` |
| `assertEquals(esperado, real)` | `Assert.Equal(esperado, real)` (el mismo orden) |
| `assertTrue`, `assertNull` | `Assert.True`, `Assert.Null` |
| `assertThrows(X.class, …)` | `Assert.Throws<X>(…)` |
| `@DisplayName` | El nombre del método (`Metodo_Escenario_Resultado`) |

Las clases de prueba de xUnit son `public`, y los métodos también.

---

## 17. Los errores típicos de quien viene de Java

| Escribes (estilo Java) | En C# se escribe | Por qué |
|------------------------|------------------|---------|
| `public decimal getSaldo()` | `public decimal Saldo { get; private set; }` | Propiedades |
| `public void calcularTotal()` | `public void CalcularTotal()` | `PascalCase` en métodos |
| `lista.size()`, `texto.length()` | `lista.Count`, `texto.Length` | Son propiedades |
| `if (nombre.equals("Ana"))` | `if (nombre == "Ana")` | `==` compara el contenido de `string` |
| `extends` / `implements` | `:` | |
| Sobrescribir sin `virtual` en la base | Marcar `virtual` en la base y `override` en la hija | Si no, se **oculta** |
| `throws IOException` | Nada (se documenta con `/// <exception>`) | No hay excepciones comprobadas |
| `catch (Exception e) { throw e; }` | `throw;` | `throw e;` borra la traza |
| `map.get(clave)` esperando `null` | `dic.GetValueOrDefault(clave)` o `TryGetValue` | El indexador **lanza** |
| `texto.substring(2, 5)` → `Substring(2, 5)` | `texto[2..5]` o `Substring(2, 3)` | El segundo parámetro de `Substring` es la longitud |
| `Integer`, `Double` en las colecciones | `List<int>`, `List<double>` | No hay envoltorios |
| `final` para constantes | `const` o `readonly` | |
| Una interfaz *listener* con `addXxxListener` | Un `event` con `+=` | Eventos del lenguaje |
| Un bucle para filtrar o sumar | LINQ: `Where`, `Sum` | |
| `Optional<T>` | `T?` con `?.` y `??` | |
| `byte` para valores de -128 a 127 | `sbyte` | En C#, `byte` no tiene signo |
| `protected` para dar acceso al paquete | `internal` | `protected` de C# no incluye el paquete |

---

[⬅️ Volver al tema 2](../02-desde-otros-lenguajes.md) · [⬅️ Volver a la unidad](../README.md)
