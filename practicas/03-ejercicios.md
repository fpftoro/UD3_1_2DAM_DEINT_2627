# Ejercicios: Programación en C#

- [Ejercicios: Programación en C#](#ejercicios-programación-en-c)
  - [Cómo están hechos](#cómo-están-hechos)
  - [Ejercicios de autocorrección](#ejercicios-de-autocorrección)
  - [Para seguir practicando: katas opcionales](#para-seguir-practicando-katas-opcionales)

Cada ejercicio está en su propia carpeta, con el enunciado en `ENUNCIADO.md` y, desde el E02, una solución de Visual Studio de partida. Todos son de **autocorrección**: sirven para practicar y no llevan nota. Cada enunciado termina con un apartado **Comprueba tu solución**. Cuando el profesor publique las soluciones, compara la tuya con ellas.

Esta unidad prepara el **RA1**, que se evalúa en la UD3: lo que practicas aquí (clases, propiedades, métodos y eventos) es lo que usarás para construir las interfaces gráficas de la UD3.

---

## Cómo están hechos

Todos usan la misma **solución de tres proyectos** que se explica en el [tema 1](../01-entorno-net-visual-studio.md):

| Proyecto | Qué contiene |
|----------|--------------|
| `<Nombre>.Logica` | Las clases del ejercicio. **Nunca** lee ni escribe en la consola |
| `<Nombre>.Consola` | Un programa que usa la lógica y muestra el resultado |
| `<Nombre>.Pruebas` | Pruebas xUnit que comprueban la lógica |

Desde el E02, las clases traen las firmas y los comentarios de documentación, pero los métodos lanzan `NotImplementedException`, y **las pruebas ya están escritas**: empiezan en rojo y tu trabajo es ponerlas en verde sin modificarlas. Puedes añadir pruebas propias.

Abre el fichero `.slnx` de cada carpeta en Visual Studio. Para ejecutar desde la terminal: `dotnet run --project <Nombre>.Consola` y `dotnet test --solution <Nombre>.slnx`.

---

## Ejercicios de autocorrección

| # | Ejercicio | Temas | Dificultad | Descripción |
|---|-----------|-------|:----------:|-------------|
| 1 | [Calculadora de la nota final](./ejercicios/E01-NotaFinal/ENUNCIADO.md) | 1, 3, 4 | ★☆☆ | Tu primera solución de tres proyectos, creada desde cero, con `TryParse`, constantes, una expresión `switch` y tus primeras pruebas |
| 2 | [Cuenta bancaria](./ejercicios/E02-CuentaBancaria/ENUNCIADO.md) | 5, 7 | ★★☆ | Propiedades con validación, `private set`, `init`, un `record` para el extracto y una excepción propia |
| 3 | [Almacenamiento en la nube](./ejercicios/E03-Nube/ENUNCIADO.md) | 6, 7 | ★★☆ | Clase abstracta, tres clases hijas, una interfaz que solo implementan algunas y polimorfismo |
| 4 | [Agenda de contactos](./ejercicios/E04-Agenda/ENUNCIADO.md) | 8 | ★★☆ | Un repositorio genérico con restricciones sobre un `Dictionary`, igualdad y orden propios |
| 5 | [Lista de tareas que avisa](./ejercicios/E05-Tareas/ENUNCIADO.md) | 9 | ★★☆ | Eventos propios: declarar, lanzar, suscribirse, darse de baja y reenviar avisos |
| 6 | [Consultas sobre alumnos y notas](./ejercicios/E06-Notas/ENUNCIADO.md) | 10 | ★★☆ | Alumnos leídos de un JSON y siete consultas LINQ: filtrar, ordenar, agrupar y agregar |
| 7 | [Reserva de asientos de un cine](./ejercicios/E07-Cine/ENUNCIADO.md) | 3–9 | ★★★ | Una matriz de asientos con reservas en grupo y eventos, y un menú de consola |
| 8 | [Importación lenta de facturas](./ejercicios/E08-Facturas/ENUNCIADO.md) | 11 | ★★★ | `async`/`await`, progreso, cancelación, errores y `Task.WhenAll` |
| 9 | [El taller tiene fallos](./ejercicios/E09-Taller/ENUNCIADO.md) | 12 | ★★☆ | Seis fallos que hay que reproducir con pruebas, localizar con el depurador y corregir |
| 10 | [Paso 1 del proyecto: el modelo del dominio](./ejercicios/E10-ModeloDominio/ENUNCIADO.md) | Todos | ★★★ | El modelo de tu propia aplicación (la de la UD1): entidades, reglas, consultas, eventos, JSON y pruebas |

---

## Para seguir practicando: katas opcionales

Si quieres practicar más, la carpeta `katas/` tiene ocho **katas** opcionales: ejercicios pequeños (de 30 minutos a 2 horas) que se hacen escribiendo una prueba cada vez. No llevan nota ni cuentan entre los ejercicios de la unidad. Empieza por el [índice de katas](./katas/README.md): explica cómo se trabajan y qué tema practica cada uno.
