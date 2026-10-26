# E10 · Paso 1 del proyecto del curso: el modelo del dominio

**Tipo:** autocorrección (paso 1 del proyecto del curso, formativo)

Programa el **modelo del dominio** de tu aplicación, la que diseñaste en el proyecto de la UD1: las clases que representan sus datos y sus reglas, sin ninguna interfaz gráfica. En la UD3 le pondrás encima la interfaz gráfica sin cambiarlo.

**CE:** — (formativo; prepara el RA1 y el paso 2 del proyecto) · **Dificultad:** ★★★ · **Tiempo estimado:** 8 h · **Temas:** todos

## Punto de partida

- Tu proyecto de la UD1: el *user flow*, las pantallas del prototipo y las entidades de tu temática.
- `README.md`: la plantilla de entrega de este paso. Rellénala a medida que avanzas.
- El ejemplo resuelto del profesor (un club deportivo con socios, pistas y reservas) se publicará como modelo. **No lo copies**: tu dominio es otro.

## Requisitos

Una solución `<TuDominio>.slnx` con tres proyectos, como en el resto de la unidad: `<TuDominio>.Logica`, `<TuDominio>.Consola` y `<TuDominio>.Pruebas`.

### El modelo (`.Logica`)

1. **Entidades**: al menos las **dos entidades relacionadas** de tu proyecto de la UD1 (por ejemplo, socios y reservas). Cada una:
   - valida sus datos en el constructor o en sus propiedades, con excepciones (un objeto no puede existir en un estado incorrecto);
   - expone sus datos con propiedades (solo lectura, `private set`, `init`… según corresponda);
   - es una `class` si cambia y un `record` si es un dato que no cambia. Justifícalo en el README.
2. Al menos una **enumeración** y una **excepción propia** con sentido en tu dominio.
3. Un **gestor** (o un repositorio por entidad y un gestor encima) con las operaciones de tu *user flow*: alta, modificación y baja de la entidad principal, y las operaciones que relacionan las dos entidades (reservar, prestar, pedir…), con sus **reglas de negocio** (sin duplicados, sin solapamientos, límites…).
4. **Consultas LINQ** que necesitarán tus pantallas e informes: un listado con búsqueda o filtro, al menos una consulta agrupada con totales (por mes, por categoría…) y al menos otra con ordenación.
5. **Eventos** en el gestor para cada cambio (alta, baja, modificación), con datos propios que hereden de `EventArgs`.
6. **Persistencia** en un fichero JSON con métodos **asíncronos** (`GuardarAsync` y `CargarAsync`), en una clase aparte del gestor.
7. Comentarios XML en todos los miembros públicos. Ningún `Console.` en `.Logica`.

### La demostración (`.Consola`)

Un programa sin interacción que crea datos de ejemplo, se suscribe a los eventos, prueba cada operación (también las que deben fallar, capturando la excepción), muestra las consultas y guarda y vuelve a cargar los datos.

### Las pruebas (`.Pruebas`)

Una prueba por cada regla de negocio y por cada consulta, incluidos los casos límite (con `[Theory]` cuando haya varios), y una prueba que guarde, cargue y compare.

## Comprueba tu solución

- [ ] Compila sin avisos y todas las pruebas pasan.
- [ ] Las entidades y operaciones coinciden con tu *user flow* de la UD1. Si has tenido que cambiar algo, está explicado en el README.
- [ ] No se puede crear ningún objeto con datos incorrectos: compruébalo con pruebas.
- [ ] Las colecciones internas no se pueden modificar desde fuera (`IReadOnlyList<T>`, copias).
- [ ] Hay al menos una consulta agrupada que servirá para un informe (UD5).
- [ ] Los datos se guardan y se cargan, y los identificadores siguen numerando bien después de cargar.
- [ ] El README de entrega está completo.

> **Para qué te servirá:** este modelo será la base del paso 2 del proyecto (UD3): la aplicación usará sus colecciones, sus validaciones, sus eventos y su persistencia sin cambiarlo.
