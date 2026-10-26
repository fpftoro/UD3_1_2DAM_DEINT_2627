# E04 · Agenda de contactos

**Tipo:** autocorrección

Completa un **repositorio genérico** que guarda cualquier objeto con clave, sin duplicados y con capacidad limitada, y úsalo para una agenda de contactos que no admite nombres repetidos.

**CE:** — (formativo; prepara el RA1: clases, propiedades y métodos) · **Dificultad:** ★★☆ · **Tiempo estimado:** 2 h · **Tema:** 8

## Punto de partida

- `Contactos.Logica`: `IConClave` y `ResultadoAlta` ya están hechos. `Repositorio<T>`, `Contacto` y `Agenda` tienen las firmas y la documentación, sin implementar.
- `Contactos.Consola/Program.cs` y `Contactos.Pruebas/AgendaPruebas.cs`: **no los modifiques**.

## Requisitos

### `Repositorio<T> where T : class, IConClave`

1. Guarda los elementos en un `Dictionary<string, T>` privado cuya clave es `elemento.Clave` y que **no distingue mayúsculas**: créalo con `new(StringComparer.OrdinalIgnoreCase)`.
2. El constructor recibe la capacidad y lanza `ArgumentOutOfRangeException` si no es mayor que 0.
3. `Capacidad`, `Cantidad`, `EstaLleno`, `HuecosLibres` y `Todos` (los valores del diccionario).
4. `bool Anadir(T elemento)`: `false` si está lleno o si la clave ya existe (usa `TryAdd`).
5. `bool Existe(string clave)`, `T? Buscar(string clave)` (usa `GetValueOrDefault`, nunca `_elementos[clave]`) y `bool Eliminar(string clave)`.

¿Por qué hace falta la restricción `IConClave`? ¿Y `class`? Escríbelo en un comentario encima de la clase.

### `Contacto`

1. Constructor `(string nombre, string telefono)`: `ArgumentException` si el nombre está vacío; guarda los dos textos sin espacios en los extremos.
2. `Nombre` (solo lectura), `Telefono` (se puede cambiar) y `Clave`, que es el nombre.
3. **Igualdad**: dos contactos son iguales si tienen el mismo nombre **sin distinguir mayúsculas**, aunque el teléfono sea distinto. Implementa `IEquatable<Contacto>`, sobrescribe `Equals(object?)` y sobrescribe `GetHashCode` de forma **coherente** (usa `StringComparer.OrdinalIgnoreCase.GetHashCode(Nombre)`).
4. **Orden**: implementa `IComparable<Contacto>` para ordenar por nombre, sin distinguir mayúsculas y respetando los acentos (`string.Compare(…, StringComparison.CurrentCultureIgnoreCase)`).
5. `ToString()`: `Ana López · 600 111 222`.

### `Agenda`

1. Constructor primario `(int capacidad = 10)` que crea un `Repositorio<Contacto>`. La agenda **tiene** un repositorio: no hereda de él.
2. `Capacidad`, `Cantidad`, `EstaLlena` y `HuecosLibres`, delegando en el repositorio.
3. `ResultadoAlta Anadir(Contacto)`: `Duplicado` si el nombre ya existe, `AgendaLlena` si no cabe y `Anadido` si se ha añadido.
4. `Existe`, `BuscarTelefono` (el teléfono o `null`) y `Eliminar`, por nombre.
5. `List<Contacto> Listar()`: una **lista nueva** con los contactos en orden alfabético (`List<T>.Sort()`).

## Comprueba tu solución

1. Todas las pruebas en verde. La clase `RepositorioPruebas` usa el repositorio con un tipo `Producto` que no tiene nada que ver con los contactos: si pasa, tu clase es realmente genérica.
2. `Contactos.Consola` muestra exactamente:

   ```text
   ✅ Luis Pérez · 600 222 333: Anadido
   ✅ ana lópez · 600 111 222: Anadido
   ✅ Marta Ruiz · 611 444 555: Anadido
   ❌ ANA LÓPEZ · 699 999 999: Duplicado
   ✅ Óscar Gil · 622 777 888: Anadido
   ❌ Zoe Martín · 633 000 111: AgendaLlena
   📒 4 de 4 contactos · llena: True · huecos: 0
      ana lópez · 600 111 222
      Luis Pérez · 600 222 333
      Marta Ruiz · 611 444 555
      Óscar Gil · 622 777 888
   🔎 Teléfono de «ANA LÓPEZ»: 600 111 222
   🔎 Teléfono de «Pedro»: no existe
   🗑️ Eliminar «luis pérez»: True
   ➕ Añadir a Zoe otra vez: Anadido
   🧮 Contactos distintos en el HashSet: 1
   ```

3. Comenta tu `GetHashCode` y vuelve a ejecutar: ¿cuántos contactos distintos cuenta ahora el `HashSet`? ¿Por qué?
4. Intenta crear un `Repositorio<string>` y un `Repositorio<int>`. Lee el error de cada uno: ¿qué restricción incumple cada tipo?

> **Para qué te servirá:** el patrón «repositorio genérico + clase de dominio» se repetirá para cada entidad del proyecto del curso.
