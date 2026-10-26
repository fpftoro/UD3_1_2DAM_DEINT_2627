# 4. Control de flujo y métodos

[⬅️ Volver a la unidad](./README.md)

**CE que trabaja este tema:** prepara RA1 e, f.

## Índice

- [4.1. Lo que ya sabes, en C#](#41-lo-que-ya-sabes-en-c)
- [4.2. Condicionales](#42-condicionales)
  - [4.2.1. `if` y el operador condicional](#421-if-y-el-operador-condicional)
  - [4.2.2. La instrucción `switch`](#422-la-instrucción-switch)
  - [4.2.3. La expresión `switch` y los patrones](#423-la-expresión-switch-y-los-patrones)
- [4.3. Bucles](#43-bucles)
- [4.4. Arrays](#44-arrays)
  - [4.4.1. Arrays de una dimensión](#441-arrays-de-una-dimensión)
  - [4.4.2. Matrices](#442-matrices)
  - [4.4.3. Índices desde el final y rangos](#443-índices-desde-el-final-y-rangos)
- [4.5. Métodos](#45-métodos)
  - [4.5.1. Declarar y llamar](#451-declarar-y-llamar)
  - [4.5.2. Parámetros opcionales y con nombre](#452-parámetros-opcionales-y-con-nombre)
  - [4.5.3. Sobrecarga](#453-sobrecarga)
  - [4.5.4. `ref`, `out` e `in`](#454-ref-out-e-in)
  - [4.5.5. Devolver varios valores: tuplas](#455-devolver-varios-valores-tuplas)
  - [4.5.6. Funciones locales](#456-funciones-locales)
- [4.6. Ejemplo integrador: un menú de consola](#46-ejemplo-integrador-un-menú-de-consola)
- [Resumen](#resumen)
- [Ejercicios de reflexión](#ejercicios-de-reflexión)

---

## 4.1. Lo que ya sabes, en C#

Condicionales, bucles, arrays y métodos funcionan en C# **como ya sabes**. Este tema no explica qué hace un bucle: enseña cómo se escribe en C# y se detiene en lo que C# tiene de particular:

| Concepto conocido | En C# | Lo particular |
|-------------------|-------|---------------|
| Condicional | `if`, `else` | La condición tiene que ser `bool`: `if (n)` con un entero no compila |
| Selección múltiple | `switch` | Sin «caída» de un `case` al siguiente; **expresión `switch`** con patrones |
| Bucles | `for`, `while`, `do … while`, `foreach` | `foreach` recorre cualquier colección |
| Arrays | `int[]`, `int[,]` | Matrices rectangulares de verdad; índices desde el final (`^1`) y rangos (`1..3`) |
| Métodos | Métodos con tipo de retorno | Parámetros **opcionales** y **con nombre**, `ref`/`out`, **tuplas**, funciones locales |

---

## 4.2. Condicionales

### 4.2.1. `if` y el operador condicional

```csharp
if (nota >= 5)
{
    Console.WriteLine("Aprobado");
}
else if (nota >= 4)
{
    Console.WriteLine("Casi: revisa el examen");
}
else
{
    Console.WriteLine("Suspenso");
}

var resultado = nota >= 5 ? "Aprobado" : "Suspenso";   // operador condicional
```

La condición tiene que ser de tipo `bool`. `if (cantidad)` con un `int`, o `if (nombre)` con un `string`, **no compila**: hay que escribir `if (cantidad != 0)` o `if (!string.IsNullOrEmpty(nombre))`.

> ✅ **Buena práctica**: Pon siempre las llaves, aunque el bloque tenga una sola instrucción. Es una de las reglas del `.editorconfig` del módulo: evita errores al añadir una segunda línea que parece estar dentro del `if` y no lo está.

### 4.2.2. La instrucción `switch`

```csharp
switch (opcion)
{
    case "1":
        MostrarSala();
        break;
    case "2":
    case "R":                      // varios case para la misma acción
        Reservar();
        break;
    case "0":
        salir = true;
        break;
    default:
        Console.WriteLine($"❌ «{opcion}» no es una opción");
        break;
}
```

Cada `case` con instrucciones tiene que terminar en `break`, `return` o `throw`: C# **no** deja que la ejecución «caiga» al `case` siguiente por olvido. Se puede hacer `switch` sobre números, `string`, `char`, enumeraciones y patrones.

### 4.2.3. La expresión `switch` y los patrones

Cuando cada caso **calcula un valor**, la **expresión `switch`** (C# 8) es más corta y clara:

```csharp
var calificacion = nota switch
{
    < 5 => "Insuficiente",
    < 6 => "Suficiente",
    < 7 => "Bien",
    < 9 => "Notable",
    _ => "Sobresaliente",        // _ es «cualquier otro caso»
};
```

Los casos se evalúan **en orden** y gana el primero que encaja. Si ninguno encaja y no hay `_`, el compilador avisa y, en ejecución, se lanza una excepción.

Los **patrones** son condiciones que se pueden combinar:

| Patrón | Ejemplo |
|--------|---------|
| Constante | `"Pádel" => 12m` |
| Relacional | `< 5`, `>= 18` |
| Lógico | `>= 0 and <= 10`, `'A' or 'E' or 'I'`, `not null` |
| De tipo | `Documento d => d.Paginas` (tema 6) |
| De propiedad | `{ Activo: true, Edad: >= 18 } => …` |
| De tupla | `(true, > 100) => "Grande y urgente"` |
| Descarte | `_` |

```csharp
decimal PrecioEntrada(int edad, bool esSocio) => (edad, esSocio) switch
{
    (< 4, _) => 0m,
    (< 18, true) => 4m,
    (< 18, false) => 6m,
    (>= 65, _) => 5m,
    (_, true) => 7m,
    _ => 9m,
};
```

Los patrones también sirven en un `if` con **`is`**:

```csharp
if (nota is >= 0 and <= 10)
{
    // nota válida
}

if (codigo[0] is < 'A' or > 'Z')
{
    // no empieza por una letra mayúscula
}
```

> 💡 **Tip del Examinador**: «¿Qué devuelve esta expresión `switch` con `nota = 5`?» Recuerda que los casos se evalúan **en orden**: con `< 5`, `< 6`… el 5 no encaja en `< 5` y sí en `< 6`, así que devuelve «Suficiente». Si los casos estuvieran desordenados, el resultado cambiaría.

> 🔁 **Transferencia**: Java (desde la versión 21), Kotlin (`when`), Swift, Rust o Python (`match`, desde la 3.10) tienen *pattern matching* parecido. Es una tendencia de los lenguajes modernos para sustituir largas cadenas de `if … else if`.

---

## 4.3. Bucles

Funcionan como ya sabes:

```csharp
for (var i = 1; i <= 3; i++)
{
    Console.WriteLine($"Fila {i}");
}

var intentos = 0;
while (intentos < 3 && !acertado)
{
    intentos++;
    // …
}

string? linea;
do
{
    Console.Write("Opción: ");
    linea = Console.ReadLine();
}
while (linea is not ("0" or null));

foreach (var alumno in alumnos)
{
    Console.WriteLine(alumno.Nombre);
}
```

`break` sale del bucle y `continue` pasa a la siguiente vuelta.

**`foreach`** recorre cualquier colección (arrays, listas, diccionarios, el resultado de una consulta LINQ…). Es el bucle que más usarás. Su variable es de **solo lectura**: no puedes asignarle otro valor, aunque sí cambiar las propiedades del objeto al que apunta.

> ⚠️ **Cuidado**: No añadas ni quites elementos de una colección mientras la recorres con `foreach`: se lanza `InvalidOperationException` («Collection was modified»). Recorre una copia (`foreach (var x in lista.ToList())`), usa un `for` hacia atrás o, para quitar, `lista.RemoveAll(…)` (tema 9).

---

## 4.4. Arrays

### 4.4.1. Arrays de una dimensión

```csharp
int[] notas = new int[5];                  // cinco ceros
string[] dias = { "L", "M", "X", "J", "V" };
decimal[] precios = [25.90m, 12.50m, 189.99m];   // expresión de colección (C# 12)

Console.WriteLine(dias.Length);            // 5
Console.WriteLine(dias[0]);                // L
Array.Sort(precios);                       // ordena el propio array
```

Un array tiene **tamaño fijo**: se decide al crearlo. Si necesitas añadir y quitar elementos, usa una **`List<T>`** (tema 8). En el módulo, los arrays aparecen sobre todo para datos fijos y para matrices.

### 4.4.2. Matrices

C# tiene **matrices rectangulares** de verdad, con varias dimensiones en un solo objeto:

```csharp
var sala = new char[3, 4];                 // 3 filas y 4 columnas

for (var f = 0; f < sala.GetLength(0); f++)        // GetLength(0): filas
{
    for (var c = 0; c < sala.GetLength(1); c++)    // GetLength(1): columnas
    {
        sala[f, c] = '○';
    }
}

sala[1, 2] = '●';
Console.WriteLine(sala.Length);            // 12: el total de elementos
```

`foreach` recorre todos los elementos de la matriz, fila a fila. También existen los **arrays escalonados** (`char[][]`): un array de arrays, en el que cada fila puede tener un tamaño distinto.

### 4.4.3. Índices desde el final y rangos

```csharp
int[] numeros = [10, 20, 30, 40, 50];

Console.WriteLine(numeros[^1]);    // 50: el último
Console.WriteLine(numeros[^2]);    // 40: el penúltimo

int[] centro = numeros[1..4];      // [20, 30, 40]: del índice 1 al 4, sin incluir el 4
int[] primeros = numeros[..2];     // [10, 20]
string resto = "C15"[1..];         // "15"
```

---

## 4.5. Métodos

### 4.5.1. Declarar y llamar

```csharp
public static double Media(double a, double b)
{
    return (a + b) / 2;
}

public static bool EsPar(int n) => n % 2 == 0;     // cuerpo de expresión
```

- Primero los **modificadores** (`public`, `private`, `static`…), después el **tipo devuelto** (`void` si no devuelve nada), el **nombre** en `PascalCase` y los **parámetros**.
- Si el cuerpo es una sola expresión, se puede escribir con **`=>`** (*expression-bodied member*).
- Un método `static` pertenece a la clase y se llama con su nombre (`CalculadoraNota.Calcular(…)`); uno sin `static`, a cada objeto (tema 5).

### 4.5.2. Parámetros opcionales y con nombre

```csharp
public static decimal Precio(decimal precioBase, int unidades = 1, decimal descuento = 0)
{
    return precioBase * unidades * (1 - descuento);
}

Precio(10m);                              // 1 unidad, sin descuento
Precio(10m, 3);                           // 3 unidades
Precio(10m, descuento: 0.2m);             // 1 unidad con descuento: argumento con nombre
Precio(unidades: 2, precioBase: 10m);     // el orden da igual con nombres
```

Los **parámetros opcionales** tienen un valor por defecto y van al final. Los **argumentos con nombre** permiten saltarse opcionales y hacen las llamadas más legibles, sobre todo con valores `bool`: `Exportar(datos, incluirCabecera: true)` se entiende mejor que `Exportar(datos, true)`.

### 4.5.3. Sobrecarga

Varios métodos pueden llamarse igual si sus parámetros son distintos:

```csharp
public static int Sumar(int a, int b) => a + b;
public static double Sumar(double a, double b) => a + b;
public static int Sumar(params int[] numeros)      // cualquier número de argumentos
{
    var total = 0;
    foreach (var n in numeros)
    {
        total += n;
    }

    return total;
}

Sumar(1, 2);          // la versión int, int
Sumar(1.5, 2);        // la versión double, double
Sumar(1, 2, 3, 4);    // la versión params
```

> ✅ **Buena práctica**: Antes de sobrecargar, piensa si bastan los parámetros opcionales: una sola versión con opcionales es más fácil de mantener que tres sobrecargas que hacen casi lo mismo.

### 4.5.4. `ref`, `out` e `in`

Por defecto, los argumentos se pasan **por valor**: el método recibe una copia (del valor, o de la referencia si es un objeto, tema 3). Tres modificadores cambian eso:

| Modificador | El método… | Quien llama… | Uso típico |
|-------------|-----------|--------------|------------|
| `ref` | Puede leer y **cambiar** la variable de quien llama | Pasa una variable inicializada, con `ref` | Raro: intercambiar dos valores |
| `out` | **Tiene que** asignarle un valor | Pasa una variable (puede declararla en la llamada), con `out` | Devolver un resultado además del valor de retorno: el patrón `TryParse` |
| `in` | Solo puede leerla | Pasa la variable (opcionalmente con `in`) | Rendimiento con `struct` grandes |

El uso más importante es el patrón **`TryXxx`**: devuelve si ha funcionado y deja el resultado en un `out`.

```csharp
public static bool TryParseCodigo(string? codigo, out int fila, out int columna)
{
    fila = 0;
    columna = 0;
    if (string.IsNullOrWhiteSpace(codigo) || codigo.Length < 2)
    {
        return false;
    }

    codigo = codigo.Trim().ToUpperInvariant();
    if (codigo[0] is < 'A' or > 'Z' || !int.TryParse(codigo[1..], out columna))
    {
        return false;
    }

    fila = codigo[0] - 'A' + 1;
    return true;
}

if (TryParseCodigo("C5", out var f, out var c))
{
    Console.WriteLine($"Fila {f}, columna {c}");   // Fila 3, columna 5
}
```

### 4.5.5. Devolver varios valores: tuplas

Una **tupla** agrupa varios valores sin crear una clase. Sirve para devolver más de un resultado:

```csharp
public static (double Minimo, double Maximo, double Media) Estadisticas(double[] notas)
{
    var minimo = notas[0];
    var maximo = notas[0];
    double suma = 0;
    foreach (var n in notas)
    {
        minimo = Math.Min(minimo, n);
        maximo = Math.Max(maximo, n);
        suma += n;
    }

    return (minimo, maximo, suma / notas.Length);
}

var resultado = Estadisticas([6, 8.5, 4, 9]);
Console.WriteLine($"{resultado.Minimo} – {resultado.Maximo}, media {resultado.Media}");
// 4 – 9, media 6,875

var (min, max, _) = Estadisticas([6, 8.5, 4, 9]);   // deconstrucción: _ descarta la media
```

> 📝 **Nota del Profesor**: Las tuplas son cómodas para resultados internos o de una consulta. Si un grupo de datos tiene sentido propio en tu dominio y se usa en varios sitios (un movimiento bancario, un resumen de un curso), crea un `record` (tema 5).

### 4.5.6. Funciones locales

Un método puede tener **funciones locales**: métodos declarados dentro de otro, visibles solo allí. En los programas con instrucciones de nivel superior, son la forma de organizar el código en funciones:

```csharp
var precio = PedirNumero("Precio");
var unidades = PedirNumero("Unidades");
Console.WriteLine($"Total: {precio * unidades:N2} €");

double PedirNumero(string pregunta)
{
    while (true)
    {
        Console.Write($"{pregunta}: ");
        if (double.TryParse(Console.ReadLine(), out var valor) && valor >= 0)
        {
            return valor;
        }

        Console.WriteLine("❌ Escribe un número positivo");
    }
}
```

---

## 4.6. Ejemplo integrador: un menú de consola

Muchos programas de consola de la unidad son un **menú** que se repite hasta salir. La estructura es siempre la misma: `while` + `switch` + funciones locales, y la lógica en otra clase.

```csharp
using System.Globalization;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
CultureInfo.CurrentCulture = new CultureInfo("es-ES");

var saldo = 0m;
var salir = false;

while (!salir)
{
    Console.WriteLine($"1) Ingresar  2) Retirar  0) Salir · saldo: {saldo:N2} €");
    Console.Write("Opción: ");

    switch (Console.ReadLine()?.Trim())
    {
        case "1":
            saldo += PedirImporte();
            break;
        case "2":
            var importe = PedirImporte();
            if (importe > saldo)
            {
                Console.WriteLine("❌ Saldo insuficiente");
            }
            else
            {
                saldo -= importe;
            }

            break;
        case "0":
        case null:                // no hay más entrada: se sale
            salir = true;
            break;
        default:
            Console.WriteLine("❌ Opción no válida");
            break;
    }
}

decimal PedirImporte()
{
    Console.Write("Importe: ");
    return decimal.TryParse(Console.ReadLine(), out var importe) && importe > 0 ? importe : 0;
}
```

En este ejemplo, el saldo y la regla «no se puede retirar más de lo que hay» están en el propio menú. Funciona, pero tiene el mismo problema del tema 1: la regla no se puede probar ni reutilizar. En el tema 5 moverás esa regla a una clase `CuentaBancaria`, y el menú solo la usará (es el ejercicio E02). En el E07 harás un menú completo sobre una sala de cine.

---

## Resumen

- Condicionales, bucles, arrays y métodos funcionan como ya sabes; la condición de un `if` tiene que ser **`bool`**.
- El **`switch`** no deja caer de un `case` al siguiente. La **expresión `switch`** calcula un valor con **patrones** (relacionales, lógicos, de tipo, de propiedad, de tupla) evaluados **en orden**.
- `is` comprueba patrones en un `if`: `nota is >= 0 and <= 10`.
- **`foreach`** recorre cualquier colección; no se puede modificar la colección dentro.
- Los **arrays** tienen tamaño fijo; las **matrices** `[,]` son rectangulares (`GetLength`). Índices desde el final (`^1`) y **rangos** (`1..3`).
- Los métodos admiten **parámetros opcionales** y **argumentos con nombre**, **sobrecarga** y `params`.
- **`out`** permite el patrón **`TryXxx`**; las **tuplas** devuelven varios valores; las **funciones locales** organizan el código dentro de un método.

## Ejercicios de reflexión

1. Reescribe con una expresión `switch` y patrones una cadena de `if … else if` de algún programa que hicieras en primer curso. ¿Es más corta? ¿Es más clara?
2. ¿Qué pasa si en la expresión `switch` de la calificación pones `_ => "Sobresaliente"` como primer caso? ¿Y si quitas el `_`? Pruébalo y lee los avisos del compilador.
3. Compara una matriz `int[3, 4]` con un array escalonado `int[3][]`. ¿Cuándo usarías cada uno? Piensa en la sala de un cine y en las notas de alumnos con distinto número de exámenes.
4. ¿Qué ventaja tiene `TryParseCodigo` con dos `out` frente a devolver una tupla `(bool Valido, int Fila, int Columna)`? ¿Y frente a lanzar una excepción si el código no es válido?
5. En el ejemplo del menú, ¿qué líneas son lógica de la cuenta y cuáles son entrada y salida? ¿Cómo las separarías para poder probar la lógica?

---

[⬅️ Volver a la unidad](./README.md)
