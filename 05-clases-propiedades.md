# 5. Clases, objetos y propiedades

[⬅️ Volver a la unidad](./README.md)

**CE que trabaja este tema:** prepara RA1 d, e, f (contenidos «clases, propiedades, métodos»).

## Índice

- [5.1. Del problema a la clase](#51-del-problema-a-la-clase)
- [5.2. Declarar una clase y crear objetos](#52-declarar-una-clase-y-crear-objetos)
- [5.3. Modificadores de acceso](#53-modificadores-de-acceso)
- [5.4. Propiedades](#54-propiedades)
  - [5.4.1. El problema: campos públicos o métodos *get* y *set*](#541-el-problema-campos-públicos-o-métodos-get-y-set)
  - [5.4.2. Propiedades automáticas](#542-propiedades-automáticas)
  - [5.4.3. Propiedades con lógica](#543-propiedades-con-lógica)
  - [5.4.4. Solo lectura, `private set` e `init`](#544-solo-lectura-private-set-e-init)
  - [5.4.5. Propiedades calculadas](#545-propiedades-calculadas)
  - [5.4.6. `required`](#546-required)
- [5.5. Constructores](#55-constructores)
  - [5.5.1. Validar al construir](#551-validar-al-construir)
  - [5.5.2. Varios constructores](#552-varios-constructores)
  - [5.5.3. Constructores primarios](#553-constructores-primarios)
- [5.6. Métodos y `ToString`](#56-métodos-y-tostring)
- [5.7. Miembros estáticos, `const` y `readonly`](#57-miembros-estáticos-const-y-readonly)
- [5.8. `record`: datos con igualdad por valor](#58-record-datos-con-igualdad-por-valor)
- [5.9. `class`, `struct` o `record`](#59-class-struct-o-record)
- [5.10. Enumeraciones](#510-enumeraciones)
- [5.11. Organizar el código](#511-organizar-el-código)
- [5.12. Errores frecuentes](#512-errores-frecuentes)
- [5.13. Ejemplo integrador: un producto con stock](#513-ejemplo-integrador-un-producto-con-stock)
- [Resumen](#resumen)
- [Ejercicios de reflexión](#ejercicios-de-reflexión)

---

## 5.1. Del problema a la clase

En el menú del tema 4, el saldo era una variable del programa y la regla «no se puede retirar más de lo que hay» estaba dentro del `switch`. Imagina que ahora hay que gestionar varias cuentas, guardar sus movimientos y comprobar que las reglas se cumplen. Con variables sueltas:

- Nada impide escribir `saldo = -500` en cualquier parte del programa.
- La regla de la retirada habría que repetirla en cada sitio que retire dinero.
- No se puede probar la regla sin ejecutar el menú.

Ya conoces la solución: **encapsulación**. Un objeto agrupa sus datos y las operaciones que los modifican, y **controla el acceso** a su estado. En C#, el mecanismo principal para ese control son las **propiedades**.

```csharp
var cuenta = new CuentaBancaria("Ana López", 100);
cuenta.Ingresar(50);
Console.WriteLine(cuenta.Saldo);  // 150: se puede leer…
// cuenta.Saldo = 1000;           // …pero no asignar: no compila
```

---

## 5.2. Declarar una clase y crear objetos

```csharp
namespace Tienda.Logica;

public class Producto
{
    // Campo: dato privado del objeto
    private int _stock;

    // Constructor: se ejecuta al hacer new
    public Producto(string nombre, decimal precio)
    {
        Nombre = nombre;
        Precio = precio;
    }

    // Propiedades: el estado que se ve desde fuera
    public string Nombre { get; }
    public decimal Precio { get; set; }
    public int Stock => _stock;

    // Método: una operación del objeto
    public void Reponer(int unidades)
    {
        _stock += unidades;
    }
}
```

Para crear objetos:

```csharp
var teclado = new Producto("Teclado", 25.90m);
Producto raton = new("Ratón", 12.50m);       // new con tipo deducido (C# 9)
teclado.Reponer(10);
Console.WriteLine($"{teclado.Nombre}: {teclado.Stock} uds");   // Teclado: 10 uds
```

Dentro de la clase, **`this`** es el objeto actual. Solo hace falta escribirlo para distinguir un miembro de un parámetro que se llama igual; con la convención `_campo` para los campos privados casi nunca hace falta.

> 🔁 **Transferencia**: La estructura «campos privados + constructor + métodos públicos» es la misma en todos los lenguajes orientados a objetos. Lo que cambia en C# es **cómo** se expone el estado: con propiedades.

---

## 5.3. Modificadores de acceso

| Modificador | Accesible desde | Uso típico |
|-------------|-----------------|------------|
| `public` | Cualquier sitio | La interfaz pública de la clase |
| `private` | Solo la propia clase | Campos y métodos auxiliares |
| `protected` | La clase y sus clases hijas (tema 6) | Lo que las hijas necesitan y el resto no |
| `internal` | Cualquier clase del **mismo proyecto** (ensamblado) | Lo que la biblioteca usa por dentro pero no expone |
| `protected internal`, `private protected` | Combinaciones de las anteriores | Poco frecuentes |

Si no escribes nada, un miembro es `private` y una clase es `internal`.

> ✅ **Buena práctica**: Escribe siempre el modificador, aunque coincida con el de por defecto (el `.editorconfig` del módulo lo pide). Y empieza por el más restrictivo: lo que es `private` se puede cambiar sin miedo; lo que es `public` puede estar usándolo cualquiera.

> 📝 **Nota del Profesor**: `internal` tiene sentido con la solución de tres proyectos. En la sala de cine del E07, `Asiento.Reservado` tiene `internal set`: la sala (en la misma biblioteca) puede reservar un asiento, pero la consola (en otro proyecto) no puede saltarse la sala.

---

## 5.4. Propiedades

### 5.4.1. El problema: campos públicos o métodos *get* y *set*

Hay dos formas «clásicas» de exponer un dato, y las dos tienen problemas:

```csharp
// 1. Campo público: cómodo, pero sin ningún control
public decimal Saldo;
cuenta.Saldo = -500;          // nada lo impide

// 2. Métodos get y set: controlado, pero incómodo de usar
private decimal _saldo;
public decimal GetSaldo() { return _saldo; }
public void SetSaldo(decimal valor) { /* validar */ _saldo = valor; }
cuenta.SetSaldo(cuenta.GetSaldo() + 50);
```

Una **propiedad** une lo mejor de las dos: **se usa como un campo**, pero **por dentro son métodos** (`get` y `set`) que pueden validar, calcular o avisar.

```csharp
cuenta.Titular = "Ana";               // llama al set
Console.WriteLine(cuenta.Titular);    // llama al get
```

### 5.4.2. Propiedades automáticas

Si no necesitas lógica, el compilador crea el campo por ti:

```csharp
public string Nombre { get; set; }
public int Edad { get; set; } = 18;          // con valor inicial
```

Es tan corta como un campo público, pero si mañana necesitas validar, la conviertes en una propiedad con lógica **sin cambiar el código que la usa**. Por eso en C# los datos públicos se exponen **siempre** con propiedades, nunca con campos.

### 5.4.3. Propiedades con lógica

Cuando el `set` tiene que validar o transformar, se escribe el cuerpo y se guarda el valor en un **campo de respaldo** privado:

```csharp
private string _titular = "";

public string Titular
{
    get => _titular;
    set
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("El titular no puede estar vacío.", nameof(Titular));
        }

        _titular = value.Trim();
    }
}
```

Dentro del `set`, **`value`** es el valor que se está asignando.

Desde C# 14, la palabra clave **`field`** se refiere al campo de respaldo que crea el compilador, así que no hace falta declararlo:

```csharp
public string Titular
{
    get;
    set => field = string.IsNullOrWhiteSpace(value)
        ? throw new ArgumentException("El titular no puede estar vacío.", nameof(Titular))
        : value.Trim();
} = "";
```

Verás las dos formas; en el módulo se usa la del campo privado, que funciona en cualquier versión.

> ⚠️ **Cuidado**: Si en el `get` escribes `get => Titular;` en lugar de `get => _titular;`, la propiedad se llama a sí misma sin fin y el programa termina con un **`StackOverflowException`**. Es un error muy habitual al empezar.

### 5.4.4. Solo lectura, `private set` e `init`

No todas las propiedades se deben poder cambiar desde fuera:

| Declaración | Se asigna en | Desde fuera | Ejemplo |
|-------------|--------------|-------------|---------|
| `{ get; set; }` | Cualquier sitio | Lectura y escritura | `Telefono` de un contacto |
| `{ get; private set; }` | Cualquier método de la clase | Solo lectura | `Saldo`: cambia con `Ingresar`, no a mano |
| `{ get; }` | Solo en el constructor | Solo lectura | `Numero` de la cuenta: no cambia nunca |
| `{ get; init; }` | El constructor o un **inicializador de objeto** | Solo lectura después de crear | `FechaApertura` |

Un **inicializador de objeto** asigna propiedades justo después del constructor:

```csharp
var cuenta = new CuentaBancaria("Ana") { FechaApertura = new DateOnly(2020, 1, 15) };
// cuenta.FechaApertura = …;   // después ya no: no compila
```

> 💡 **Tip del Examinador**: «¿Qué diferencia hay entre `{ get; }`, `{ get; private set; }` y `{ get; init; }`?» Las tres se leen desde fuera. `{ get; }` solo se asigna en el constructor; `private set`, en cualquier método de la clase; `init`, en el constructor o al crear el objeto con un inicializador.

### 5.4.5. Propiedades calculadas

Una propiedad no tiene por qué guardar nada: puede **calcular** su valor cada vez:

```csharp
public decimal Total => Precio * Unidades;
public bool EstaVacia => Cantidad == 0;
public string NombreCompleto => $"{Nombre} {Apellidos}";
```

### 5.4.6. `required`

**`required`** (C# 11) obliga a quien crea el objeto a dar valor a una propiedad en el inicializador:

```csharp
public class Contacto
{
    public required string Nombre { get; init; }
    public string? Telefono { get; init; }
}

var ana = new Contacto { Nombre = "Ana", Telefono = "600 111 222" };
// var nadie = new Contacto { Telefono = "…" };   // error CS9035: falta Nombre
```

Es útil para clases de datos sin constructor. Si hay que **validar** el valor, sigue siendo mejor un constructor o un `init` con lógica.

> 🔁 **Transferencia**: Kotlin, Swift y Python (con `@property`) tienen propiedades parecidas; en Java se usan los métodos `getX` y `setX`. Las clases de .NET usan propiedades en todas partes (`lista.Count`, `texto.Length`, `DateTime.Now`), y en las interfaces gráficas de la UD3 todo lo que se ajusta de un componente también será una propiedad.

---

## 5.5. Constructores

### 5.5.1. Validar al construir

El constructor es el lugar para garantizar que **no puede existir un objeto en un estado incorrecto**:

```csharp
public CuentaBancaria(string titular, decimal saldoInicial = 0)
{
    Titular = titular;                                         // el set de Titular ya valida
    ArgumentOutOfRangeException.ThrowIfNegative(saldoInicial); // lanza si es negativo
    Saldo = saldoInicial;
}
```

.NET trae métodos de ayuda para las validaciones más comunes: `ArgumentNullException.ThrowIfNull`, `ArgumentException.ThrowIfNullOrWhiteSpace`, `ArgumentOutOfRangeException.ThrowIfNegative`, `ThrowIfNegativeOrZero`, `ThrowIfLessThan`, `ThrowIfGreaterThan`…

Si una clase no tiene ningún constructor, el compilador crea uno vacío sin parámetros.

### 5.5.2. Varios constructores

Un constructor puede llamar a otro de la misma clase con **`: this(…)`**, para no repetir código:

```csharp
public Producto(string nombre, decimal precio, int stock)
{
    Nombre = nombre;
    Precio = precio;
    _stock = stock;
}

public Producto(string nombre, decimal precio)
    : this(nombre, precio, 0)
{
}
```

Muchas veces basta con un parámetro opcional (`int stock = 0`) y un solo constructor.

### 5.5.3. Constructores primarios

Desde C# 12, los parámetros del constructor se pueden escribir **junto al nombre de la clase**. Están disponibles en toda la clase, y se usan sobre todo para inicializar propiedades y campos:

```csharp
public class Tarea(string titulo)
{
    public string Titulo { get; } = titulo.Trim();
    public bool Completada { get; set; }
}
```

Son cómodos para clases sencillas y para recibir dependencias (un repositorio, un servicio). Cuando hay validaciones complejas, el constructor clásico se lee mejor.

---

## 5.6. Métodos y `ToString`

Los métodos de instancia operan sobre el estado del objeto:

```csharp
public decimal Ingresar(decimal importe)
{
    ArgumentOutOfRangeException.ThrowIfNegativeOrZero(importe);
    Mover("Ingreso", importe);
    return Saldo;
}

// Único sitio en que cambia el saldo: así cada cambio queda anotado
private void Mover(string concepto, decimal importe)
{
    Saldo += importe;
    _movimientos.Add(new Movimiento(concepto, importe, Saldo));
}
```

Todos los objetos tienen un método **`ToString()`**, heredado de `object`, que devuelve el nombre de la clase. Se **sobrescribe** (`override`, tema 6) para dar una representación útil. Se usa automáticamente al meter el objeto en un texto interpolado:

```csharp
public override string ToString()
{
    return $"{Numero} · {Titular} · {Saldo:N2} €";
}

Console.WriteLine($"🏦 {cuenta}");   // 🏦 ES-0001 · Ana López · 150,00 €
```

> 📝 **Nota del Profesor**: El depurador de Visual Studio también usa `ToString()`: al inspeccionar un objeto (tema 12) muestra su resultado. Un buen `ToString` te ahorra desplegar cada objeto para saber cuál es.

---

## 5.7. Miembros estáticos, `const` y `readonly`

Un miembro **`static`** pertenece a la **clase**, no a cada objeto. Se usa con el nombre de la clase:

```csharp
public class CuentaBancaria
{
    public const string Prefijo = "ES-";           // constante: implícitamente estática
    private static int _cuentasAbiertas;            // un único contador para todas las cuentas

    public static int CuentasAbiertas => _cuentasAbiertas;
    // …
}

Console.WriteLine(CuentaBancaria.CuentasAbiertas);
```

Una **clase estática** (`public static class CalculadoraNota`) solo tiene miembros estáticos y no se puede instanciar. Es la forma de agrupar funciones que no necesitan estado, como `Math` o `Console`.

| Declaración | Se fija | Puede ser de cualquier tipo | Ejemplo |
|-------------|---------|------------------------------|---------|
| `const` | Al compilar | No: solo números, `bool`, `char`, `string` | `const double Iva = 0.21;` |
| `static readonly` | Al cargar la clase | Sí | `static readonly JsonSerializerOptions _opciones = new(…);` |
| `readonly` (campo de instancia) | En el constructor de cada objeto | Sí | `private readonly List<Movimiento> _movimientos = [];` |

> ⚠️ **Cuidado**: Un campo `readonly` de tipo lista impide **sustituir** la lista por otra, pero **no** impide añadir o quitar elementos: `_movimientos.Add(…)` sigue funcionando. Para que **desde fuera** no se pueda modificar, expón la lista como `IReadOnlyList<T>` (tema 8).

---

## 5.8. `record`: datos con igualdad por valor

Muchas clases solo **llevan datos**: un movimiento bancario, una factura importada, el resumen de un curso. Para ellas, C# 9 añadió los **`record`**:

```csharp
public record Movimiento(string Concepto, decimal Importe, decimal SaldoResultante);
```

Con una línea, el compilador genera:

- Un constructor con los tres parámetros y tres propiedades `{ get; init; }`.
- **Igualdad por valor**: dos `Movimiento` son iguales si tienen los mismos valores (en una clase normal, `==` compara si son **el mismo objeto**).
- Un `ToString()` que muestra los valores: `Movimiento { Concepto = Ingreso, Importe = 50, SaldoResultante = 150 }`.
- La **deconstrucción** y la expresión **`with`**, que crea una copia con algún cambio.

```csharp
var a = new Movimiento("Ingreso", 50, 150);
var b = new Movimiento("Ingreso", 50, 150);

Console.WriteLine(a == b);              // True: mismos valores
var c = a with { Importe = 60 };        // copia con un cambio; a no cambia
var (concepto, importe, _) = a;         // deconstrucción
```

Un `record` puede tener también métodos y propiedades calculadas:

```csharp
public record Alumno(string Nombre, string Curso, List<double> Notas)
{
    public double Media => Notas.Count == 0 ? 0 : Notas.Average();
}
```

> 💡 **Tip del Examinador**: «Dos objetos con los mismos datos, ¿son iguales con `==`?» Si son de una **clase**, no (salvo que se sobrescriba la igualdad): `==` compara referencias. Si son de un **`record`**, sí: compara los valores.

---

## 5.9. `class`, `struct` o `record`

| | `class` | `record` (`record class`) | `struct` |
|---|---------|---------------------------|----------|
| Tipo | Referencia | Referencia | Valor |
| `==` compara | Referencias (si es el mismo objeto) | Valores | Valores (con `record struct`) |
| Pensado para | Objetos con identidad y comportamiento que cambian | Datos que no cambian | Valores pequeños (un punto, un color) |
| Ejemplo del módulo | `CuentaBancaria`, `SalaCine`, `GestorClub` | `Movimiento`, `Factura`, `ResumenCurso` | `DateTime`, `TimeSpan` (de .NET) |

Regla práctica: empieza por **`class`**; usa **`record`** para datos que no cambian y se comparan por valor; deja **`struct`** para casos muy concretos (lo usarás poco).

---

## 5.10. Enumeraciones

Una **enumeración** (`enum`) define un conjunto cerrado de valores con nombre:

```csharp
public enum EstadoReparacion
{
    Pendiente,
    EnReparacion,
    Reparado,
}

var estado = EstadoReparacion.Pendiente;
if (estado != EstadoReparacion.Reparado)
{
    Console.WriteLine($"Estado: {estado}");    // Estado: Pendiente
}
```

Mejor que un `string` («pendiente», «Pendiente», «pendente»…) o un número mágico (0, 1, 2): el compilador comprueba los valores y el IDE los autocompleta. Por dentro, cada valor es un entero (0, 1, 2…).

---

## 5.11. Organizar el código

- **Un tipo público por fichero**, con el mismo nombre que el tipo: `CuentaBancaria.cs`. C# no lo exige, pero es la convención.
- El **espacio de nombres** sigue las carpetas: `Banco.Logica`, `Banco.Logica.Modelos`.
- Las **clases parciales** (`partial`) reparten una clase en varios ficheros. Todas las partes se declaran con `partial` y el compilador las une. No las usarás para tu código, pero las verás en el código que generan algunas herramientas: una parte la escribe el programador y otra la genera la herramienta.

```csharp
// Factura.cs
public partial class Factura
{
    public decimal Importe { get; set; }
}

// Factura.Calculos.cs: la misma clase, en otro fichero
public partial class Factura
{
    public decimal ConIva() => Importe * 1.21m;
}
```

> 📝 **Nota del Profesor**: Cuando en la UD3 analices el código que genera el editor visual (RA1 e), te encontrarás clases parciales, constructores, propiedades y eventos. Todo eso es C# de este tema y de los siguientes: entenderlo aquí es lo que te permitirá modificarlo allí con seguridad.

---

## 5.12. Errores frecuentes

| Error | Síntoma | Solución |
|-------|---------|----------|
| El `get` devuelve la propia propiedad | `StackOverflowException` | Devuelve el campo de respaldo (`_titular`) |
| Propiedad `public … { get; set; }` para algo que no debe cambiarse desde fuera | Cualquiera pone `Saldo = 1000` | `private set`, `init` o solo `get` |
| Validar fuera de la clase (en la consola) | Otro programa que use la clase (las pruebas, otra consola o la interfaz de la UD3) puede saltarse la validación | Validar en el constructor y en los `set` |
| La clase y su espacio de nombres se llaman igual (`Agenda.Logica.Agenda`) | Error `CS0118`: «Agenda es un espacio de nombres pero se usa como un tipo» | Cambia el nombre de uno de los dos (`Contactos.Logica.Agenda`) |
| Exponer una `List<T>` privada tal cual | Desde fuera se puede hacer `.Clear()` | Exponerla como `IReadOnlyList<T>` |
| Incrementar un contador estático antes de validar | Los objetos que no llegan a crearse gastan número | Validar primero |

---

## 5.13. Ejemplo integrador: un producto con stock

```csharp
namespace Tienda.Logica;

/// <summary>Producto de la tienda con su precio y su stock.</summary>
public class Producto
{
    private static int _siguienteCodigo = 1;
    private int _stock;

    public Producto(string nombre, decimal precio, int stockInicial = 0)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nombre);
        ArgumentOutOfRangeException.ThrowIfNegative(stockInicial);
        Nombre = nombre.Trim();
        Precio = precio;
        _stock = stockInicial;
        Codigo = $"P{_siguienteCodigo++:D3}";
    }

    public string Codigo { get; }

    public string Nombre { get; }

    public decimal Precio
    {
        get;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
            field = value;
        }
    }

    public int Stock => _stock;

    public bool Agotado => _stock == 0;

    public decimal ValorEnAlmacen => Precio * _stock;

    public void Reponer(int unidades)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(unidades);
        _stock += unidades;
    }

    public bool Vender(int unidades)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(unidades);
        if (unidades > _stock)
        {
            return false;
        }

        _stock -= unidades;
        return true;
    }

    public override string ToString()
    {
        return $"{Codigo} {Nombre} · {Precio:N2} € · {(Agotado ? "agotado" : $"{Stock} uds")}";
    }
}
```

```csharp
var monitor = new Producto("Monitor", 189.99m, 2);
Console.WriteLine(monitor);                              // P001 Monitor · 189,99 € · 2 uds
Console.WriteLine(monitor.Vender(3));                    // False: no hay bastante
monitor.Vender(2);
Console.WriteLine(monitor);                              // P001 Monitor · 189,99 € · agotado
monitor.Precio = 0;                                      // ArgumentOutOfRangeException
```

| Concepto | Dónde |
|----------|-------|
| Campo estático y código consecutivo después de validar | `_siguienteCodigo` |
| Propiedad de solo lectura asignada en el constructor | `Codigo`, `Nombre` |
| Propiedad con validación y `field` (C# 14) | `Precio` |
| Propiedad de solo lectura sobre un campo privado | `Stock` |
| Propiedades calculadas | `Agotado`, `ValorEnAlmacen` |
| Métodos que mantienen el objeto en un estado correcto | `Reponer`, `Vender` |
| `ToString` sobrescrito | Al final |

---

## Resumen

- Una **clase** agrupa estado (campos y propiedades) y comportamiento (métodos), y controla el acceso a su estado: **encapsulación**.
- Los **modificadores de acceso** (`public`, `private`, `protected`, `internal`) deciden quién ve cada miembro. Por defecto, un miembro es `private`.
- Las **propiedades** se usan como campos pero son métodos `get`/`set`: pueden **validar**, **calcular** o restringir la escritura (`private set`, solo `get`, `init`). En C#, los datos públicos se exponen siempre con propiedades.
- **`value`** es el valor que llega al `set`; **`field`** (C# 14) es el campo de respaldo automático.
- El **constructor** garantiza que el objeto nace en un estado correcto. `: this(…)` encadena constructores; los **constructores primarios** (C# 12) simplifican las clases sencillas.
- **`ToString`** se sobrescribe para mostrar el objeto.
- Lo **`static`** es de la clase; `const` se fija al compilar; `readonly`, al construir.
- Un **`record`** es una clase de datos con **igualdad por valor**, `ToString` automático y `with`.
- Las **enumeraciones** dan nombre a un conjunto cerrado de valores.
- Un tipo público por fichero; las **clases parciales** reparten una clase en varios ficheros.

## Ejercicios de reflexión

1. Toma una clase que hicieras en primer curso con métodos `getX` y `setX` y reescríbela con propiedades. ¿Qué propiedades serían `{ get; set; }`, cuáles `private set` y cuáles calculadas?
2. ¿Por qué se dice que una propiedad automática es «gratis» frente a un campo público? Piensa en qué pasa con el código que la usa cuando hay que añadir una validación.
3. Crea un `record Punto(int X, int Y)` y una `class PuntoClase` equivalente. Compara `==`, `Equals` y `ToString` en los dos. ¿Cuál usarías como clave de un diccionario? ¿Por qué?
4. En el ejemplo integrador, ¿por qué `Vender` devuelve `bool` y `Reponer` lanza una excepción con unidades negativas? ¿Qué criterio hay detrás?
5. Abre cualquier clase de .NET con F12 (por ejemplo, `List<T>`) y busca tres propiedades: ¿tienen `set`? ¿Por qué crees que `Count` no lo tiene?

---

[⬅️ Volver a la unidad](./README.md)
