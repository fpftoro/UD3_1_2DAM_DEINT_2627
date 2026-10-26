# Cuestionario: Programación en C#

- [Cuestionario: Programación en C#](#cuestionario-programación-en-c)
  - [El entorno y el lenguaje](#el-entorno-y-el-lenguaje)
  - [Clases, propiedades y herencia](#clases-propiedades-y-herencia)
  - [Excepciones y nulabilidad](#excepciones-y-nulabilidad)
  - [Colecciones y LINQ](#colecciones-y-linq)
  - [Delegados y eventos](#delegados-y-eventos)
  - [Programación asíncrona](#programación-asíncrona)
  - [Depurar, documentar y probar](#depurar-documentar-y-probar)

Responde con tus palabras, justificando cada respuesta. Cuando se pida investigar, cita las fuentes consultadas. Cuando se pida comprobar algo, indica cómo lo has comprobado (un programa de consola, el depurador, una prueba) y qué resultado has obtenido.

Esta unidad prepara el RA1, que se evalúa en la UD3: el cuestionario es formativo.

---

## El entorno y el lenguaje

1. **Compilar a código intermedio:** Explica qué ventajas tiene que C# se compile a IL y no directamente a código máquina. Compáralo con otro lenguaje que conozcas (que compile a código intermedio o a código máquina) y piensa en qué afecta a quien distribuye una aplicación de escritorio.

2. **.NET Framework y .NET:** Investiga las diferencias entre .NET Framework 4.8 y la versión LTS vigente de .NET. ¿Por qué crees que muchas empresas siguen manteniendo aplicaciones en .NET Framework? ¿Qué te encontrarías si buscas en Internet un ejemplo de C# de hace diez años?

3. **Separar la lógica:** La unidad insiste en que la biblioteca de lógica no use nunca la consola. Explica tres problemas concretos que tendrías en la UD3 si no lo respetaras. ¿Cómo verías lo que pasa dentro de la lógica sin escribir en la consola?

4. **Valor y referencia:** Escribe un programa que demuestre la diferencia entre pasar a un método un `struct` y una `class`, y explica el resultado. Después, explica por qué `string`, que es un tipo de referencia, se comporta como si fuera de valor.

5. **La cultura:** Un compañero ha hecho un programa que funciona en su portátil, pero falla en el ordenador del aula al leer «7,5». Explica las posibles causas y cómo harías el programa robusto para usuarios de distintos países. ¿Qué cultura usarías para leer un fichero de configuración y por qué?

---

## Clases, propiedades y herencia

6. **Propiedades frente a métodos *get* y *set*:** Explica qué ventajas tienen las propiedades de C# frente a los métodos `GetX` y `SetX` y frente a los campos públicos. Pon un ejemplo de una propiedad que empiece siendo automática y que más tarde necesite validación: ¿qué código hay que cambiar en el resto del programa?

7. **Elegir la declaración:** Para una clase `Socio` de un club, decide para cada dato (número de socio, nombre, correo, fecha de alta, si está activo, cuota mensual, edad calculada a partir de la fecha de nacimiento) si sería `{ get; set; }`, `{ get; private set; }`, `{ get; }`, `{ get; init; }` o una propiedad calculada. Justifica cada elección.

8. **`class` o `record`:** Explica con un ejemplo propio qué diferencia hay entre comparar dos objetos de una clase y dos objetos de un `record` con `==`. ¿Qué tipos de un proyecto de gestión harías `record` y cuáles `class`? Justifícalo.

9. **Métodos no virtuales:** En C#, los métodos no se pueden sobrescribir salvo que la base los declare `virtual`. Investiga por qué los diseñadores de C# tomaron esa decisión y compárala con otro lenguaje que conozcas. ¿Qué riesgo tiene escribir en una clase hija un método con el mismo nombre sin `override`?

10. **Herencia o composición:** Busca en la documentación de Microsoft la jerarquía de `Stream` o la de `Exception` y explica qué ganan esas clases con la herencia. Después, describe un caso de tu proyecto del curso en el que usarías composición en lugar de herencia.

---

## Excepciones y nulabilidad

11. **Excepción o resultado:** En la unidad, `Agenda.Anadir` devuelve una enumeración, `SalaCine.Reservar` devuelve `bool` y `CuentaBancaria.Retirar` lanza una excepción. Explica el criterio que hay detrás de cada decisión. Aplica ese criterio a tres operaciones de tu proyecto del curso.

12. **El error de los mil millones:** Investiga la historia de la frase «el error de los mil millones de dólares» de Tony Hoare. ¿Qué problema resuelven los tipos de referencia que admiten `null` de C#? ¿Lo resuelven del todo? Pon un ejemplo en el que el compilador no pueda avisarte.

---

## Colecciones y LINQ

13. **Elegir colección:** Para cada caso, elige la colección más adecuada y justifícalo: los socios de un club buscados por su número; los últimos diez documentos abiertos; las etiquetas de una tarea; las peticiones de impresión pendientes; el historial de «deshacer» de un editor; una lista de tareas que tiene que avisar cuando se añade o se quita una.

14. **Igualdad y hash:** Explica, como si se lo contaras a un compañero, por qué hay que sobrescribir `GetHashCode` cuando se sobrescribe `Equals`. Demuéstralo con un programa en el que un `HashSet` guarde «duplicados» por no hacerlo.

15. **Bucles o LINQ:** Toma tres consultas del ejercicio E06 y escríbelas también con bucles. Compara la longitud, la claridad y la facilidad para cambiar cada versión. ¿Hay algún caso en el que preferirías el bucle?

16. **Ejecución diferida:** Explica con un ejemplo propio qué es la ejecución diferida de LINQ, qué ventaja tiene y qué error puede provocar. ¿Por qué los métodos de las soluciones de la unidad terminan sus consultas con `ToList()`?

---

## Delegados y eventos

17. **Eventos en distintas tecnologías:** Compara cómo se asocia una acción a un evento en C# (`+=`), en Android (`setOnClickListener`), en JavaFX (`setOnAction`) y en una página web (`addEventListener`). ¿Qué tienen en común? ¿Qué papel tiene el patrón publicador-suscriptor en todas ellas?

18. **Desacoplamiento:** Explica por qué `System.Timers.Timer` puede usarse en cualquier programa sin saber nada de él. Relaciónalo con el evento `TareaAnadida` del E05: ¿qué tendrías que cambiar en `AgendaTareas` para añadir un tercer suscriptor que guarde un registro en un fichero?

19. **Fugas de memoria:** Explica cómo una suscripción a un evento puede impedir que se libere la memoria de un objeto. Describe un caso realista y cómo lo evitarías.

---

## Programación asíncrona

20. **Esperar bloqueado:** Explica, sin usar código, qué hace un programa que lee un fichero grande de forma síncrona mientras espera, y qué cambia al usar `await`. Busca en tu experiencia como usuario una aplicación que se haya «quedado colgada» y razona qué estaba haciendo mal.

21. **Cancelación cooperativa:** ¿Por qué se dice que la cancelación en .NET es «cooperativa»? ¿Qué pasa si un método recibe un `CancellationToken` pero no lo comprueba ni lo pasa a lo que espera? Relaciónalo con la heurística de Nielsen «control y libertad del usuario» de la UD1.

---

## Depurar, documentar y probar

22. **Depurar con un objetivo:** Describe paso a paso cómo localizaste con el depurador uno de los fallos del E09: dónde pusiste el punto de interrupción, qué ventana usaste y qué valor te dio la pista. ¿Lo habrías encontrado igual de rápido con `Console.WriteLine`?

23. **Qué probar:** Para el método `Reservar` del E10 (o el equivalente de tu dominio), escribe la lista de casos que probarías: normales, límite y de error. ¿Cuál crees que es el más fácil de olvidar y por qué?

24. **Documentar para otros:** Elige una clase pública de tu E10 y documéntala con comentarios XML completos. Después, pide a un compañero que la use solo con lo que le muestra IntelliSense y anota qué le ha faltado saber.
