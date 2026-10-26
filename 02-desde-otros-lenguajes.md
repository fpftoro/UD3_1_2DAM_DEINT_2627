# 2. Si vienes de otro lenguaje

[⬅️ Volver a la unidad](./README.md)

**CE que trabaja este tema:** prepara RA1 e, f.

## Índice

- [2.1. Para qué sirve este tema](#21-para-qué-sirve-este-tema)
- [2.2. Lo que ya sabes y sigue valiendo](#22-lo-que-ya-sabes-y-sigue-valiendo)
- [2.3. Lo que suele sorprender al llegar a C#](#23-lo-que-suele-sorprender-al-llegar-a-c)
- [2.4. Cómo aprender un lenguaje cuando ya sabes otro](#24-cómo-aprender-un-lenguaje-cuando-ya-sabes-otro)
- [2.5. Guías por lenguaje de origen](#25-guías-por-lenguaje-de-origen)
- [Resumen](#resumen)
- [Ejercicios de reflexión](#ejercicios-de-reflexión)

---

## 2.1. Para qué sirve este tema

Ya sabes programar. En primer curso aprendiste qué es una variable, un bucle, un método, una clase, la herencia o una excepción, con algún lenguaje orientado a objetos. Esta unidad **no** te vuelve a explicar esos conceptos: te enseña **cómo se expresan en C#**, qué tiene C# de particular y por qué eso importará en las unidades siguientes.

Los temas de la unidad parten siempre del **concepto**, no de otro lenguaje, porque cada persona viene de uno distinto. Pero si conoces bien un lenguaje concreto, te ayudará mucho ver C# **comparado con él**. Para eso están las **guías por lenguaje de origen** del apartado 2.5: son opcionales y puedes leerlas antes de empezar, en paralelo con los temas o como consulta.

---

## 2.2. Lo que ya sabes y sigue valiendo

Casi todo lo que aprendiste en primer curso se traslada directamente:

| Concepto que ya conoces | En C# | Tema |
|-------------------------|-------|------|
| Organizar el código en módulos o paquetes | `namespace` | 3 y 5 |
| Variables, tipos y operadores | `int`, `double`, `decimal`, `string`, `bool`, `var` | 3 |
| Condicionales y bucles | `if`, `switch`, `for`, `while`, `foreach` | 4 |
| Funciones o métodos | Métodos, parámetros opcionales y con nombre | 4 |
| Clases y objetos | `class`, `new` | 5 |
| Encapsulación | **Propiedades** (`get` y `set`) | 5 |
| Herencia e interfaces | `:`, `virtual`/`override`, `interface` | 6 |
| Gestión de errores | Excepciones: `try`/`catch`/`finally`, `throw` | 7 |
| Colecciones | `List<T>`, `Dictionary<TKey, TValue>`, `HashSet<T>` | 8 |
| Funciones como valores | Delegados y **lambdas** | 9 |
| Procesar colecciones (filtrar, ordenar, agrupar) | **LINQ** | 10 |
| Tareas que tardan | `async`/`await` | 11 |

> 📝 **Nota del Profesor**: Lee los temas fijándote en la tercera columna de la tabla de cada concepto: **qué tiene C# de particular**. Ahí está lo que tienes que aprender. Lo que ya sabes, repásalo deprisa.

---

## 2.3. Lo que suele sorprender al llegar a C#

Vengas del lenguaje que vengas, hay detalles de C# que suelen llamar la atención. Conviene tenerlos presentes desde el principio:

1. **Los métodos y las propiedades públicas empiezan en mayúscula** (`Console.WriteLine`, `lista.Count`, `cuenta.Saldo`). Es la convención de .NET y la sigue todo el código que leerás (tema 1).
2. **Las propiedades sustituyen a los métodos *get* y *set***. `cuenta.Saldo` parece un campo público, pero por debajo hay métodos que pueden validar o calcular (tema 5).
3. **Hay tipos de valor y tipos de referencia**, y tú puedes crear los dos (`struct` y `class`). No es lo mismo copiar un `int` o un `DateTime` que copiar un objeto de una clase (tema 3).
4. **`string` se compara con `==` por su contenido**, como un valor (tema 3).
5. **El compilador te avisa de los posibles `null`**. Una variable `string` no debería ser `null`; si puede serlo, se escribe `string?` (tema 7).
6. **Las excepciones no se declaran** en la firma de los métodos (tema 7).
7. **Los eventos son parte del lenguaje**: `tarea.CompletadaCambiada += MostrarPendientes;` suscribe un método a un evento sin escribir clases auxiliares (tema 9).
8. **LINQ** permite consultar cualquier colección con `Where`, `OrderBy` o `Select`, encadenados (tema 10).
9. **`async` y `await`** forman parte del lenguaje para que las tareas lentas no congelen la interfaz (tema 11).
10. **Un fichero puede tener varias clases y el nombre del fichero no tiene que coincidir con el de la clase**, aunque la convención es una clase pública por fichero con su mismo nombre (tema 5).

> 💡 **Tip del Examinador**: «Nombra tres características de C# que lo diferencian de otros lenguajes orientados a objetos.» Por ejemplo: las **propiedades**, los **eventos** como parte del lenguaje y **LINQ**. Son también las tres que más vas a usar en el resto del módulo.

---

## 2.4. Cómo aprender un lenguaje cuando ya sabes otro

A lo largo de tu vida profesional aprenderás muchos lenguajes y *frameworks*. Esta es una estrategia que funciona con todos:

1. **Busca las equivalencias**: «¿cómo se hace en este lenguaje lo que ya sé hacer?». Una tabla de equivalencias (como la de 2.2) te ahorra horas.
2. **Busca las diferencias que cambian el comportamiento**, no solo la sintaxis: ¿cómo se comparan los objetos?, ¿qué pasa con `null`?, ¿se copian o se comparten al pasarlos a un método?, ¿cómo se gestionan los errores?
3. **Aprende las convenciones del ecosistema**: nombres, estructura de carpetas, gestor de paquetes, herramienta de pruebas. Un código correcto pero «con acento de otro lenguaje» es más difícil de mantener para el equipo.
4. **Lee código real** del ecosistema (la documentación oficial y proyectos de código abierto) y fíjate en cómo resuelven cosas que tú resolverías de otra forma.
5. **Escribe un programa pequeño completo** cuanto antes, con sus pruebas. Es lo que harás en el E01.

> 🔁 **Transferencia**: Esta misma estrategia te servirá para cualquier lenguaje o tecnología nuevos que aprendas en el módulo, y en el futuro para Kotlin, Swift, TypeScript o el lenguaje que te pidan en una empresa.

> ⚠️ **Cuidado**: El error más habitual al cambiar de lenguaje es escribir el nuevo **como si fuera el antiguo**: métodos `getSaldo()` en lugar de propiedades, bucles para todo en lugar de LINQ, nombres en `camelCase` en los métodos… El programa funciona, pero cualquier programador de C# lo leerá con dificultad.

---

## 2.5. Guías por lenguaje de origen

Cada guía compara C# con un lenguaje concreto, bloque a bloque y en el mismo orden que los temas de la unidad, con código lado a lado y los errores típicos de quien viene de ese lenguaje.

| Si vienes de… | Guía |
|---------------|------|
| **Java** | [C# para quien viene de Java](./desde-otros-lenguajes/java.md) |

Más adelante se podrán añadir guías para otros lenguajes (Python, C++…). Si vienes de un lenguaje que no tiene guía, usa la tabla del apartado 2.2 y la lista del 2.3: recogen lo esencial.

---

## Resumen

- La unidad **no** vuelve a explicar los conceptos de programación: enseña **cómo se expresan en C#** y qué tienen de particular.
- Casi todo lo aprendido se traslada: variables, control de flujo, métodos, clases, herencia, interfaces, excepciones y colecciones.
- Lo que suele sorprender: **métodos y propiedades en `PascalCase`**, **propiedades** en lugar de *getters* y *setters*, **tipos de valor y de referencia**, `string` comparado por contenido, **avisos de `null`**, excepciones sin declarar, **eventos**, **LINQ** y **`async`/`await`**.
- Para aprender un lenguaje nuevo: equivalencias, diferencias de comportamiento, convenciones del ecosistema, código real y un programa pequeño completo.
- Las **guías por lenguaje de origen** comparan C# con un lenguaje concreto. De momento hay una para **Java**.

## Ejercicios de reflexión

1. Elige el lenguaje que mejor conoces y haz tu propia tabla de equivalencias con la del apartado 2.2: ¿qué conceptos se expresan de forma parecida en C# y cuáles de forma muy distinta?
2. De la lista del apartado 2.3, ¿qué punto te parece más raro viniendo de tu lenguaje? Búscalo en su tema y explica por qué crees que C# lo hace así.
3. Busca en GitHub un proyecto de código abierto en C# (por ejemplo, alguno de la organización `dotnet`) y anota tres cosas del estilo del código que no harías igual en tu lenguaje.
4. ¿Por qué crees que los temas de la unidad no usan un lenguaje concreto como referencia, y en cambio las guías sí?

---

[⬅️ Volver a la unidad](./README.md)
