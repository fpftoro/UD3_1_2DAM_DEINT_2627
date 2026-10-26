# K07 · Invernadero

**Tipo:** kata opcional (autocorrección)

Un invernadero tiene un sensor de temperatura. Cuando la temperatura pasa de un umbral, hay que avisar (para abrir las ventanas o encender la ventilación), pero **solo una vez**, no con cada lectura; y cuando vuelve a la normalidad, otra vez. Varios servicios pueden escuchar los avisos a la vez.

**CE:** — (opcional; practica el RA1: eventos y escuchadores) · **Dificultad:** ★☆☆ · **Tiempo estimado:** 1 h · **Tema:** 9

## Cómo se trabaja un kata

1. Abre la solución `Invernadero.slnx`. Las pruebas están escritas por pasos, en `Invernadero.Pruebas`, y todas menos la primera llevan `Skip = "…"` en su atributo, así que no se ejecutan.
2. **Rojo:** ejecuta las pruebas y comprueba que la primera falla.
3. **Verde:** escribe en `Invernadero.Logica` el código **más sencillo** que la haga pasar, aunque sea una trampa. Ya lo mejorarás.
4. **Refactoriza:** si el código queda feo o repetido, límpialo sin que ninguna prueba falle.
5. Quita el `Skip` de la prueba siguiente y repite desde el paso 2. Al final, ninguna prueba debe llevar `Skip`.

No modifiques las pruebas, salvo para quitar el `Skip`. Puedes añadir pruebas tuyas.

## Punto de partida

La solución `Invernadero.slnx` tiene dos proyectos:

- `Invernadero.Logica`: `SensorTemperatura` y `RegistroAlertas` con las firmas, los eventos declarados y la documentación, sin implementar, y `TemperaturaEventArgs`, que ya está hecha.
- `Invernadero.Pruebas`: las pruebas de `SensorTemperaturaPruebas.cs`, agrupadas en cinco pasos.

## Requisitos

### `SensorTemperatura`

| Miembro | Comportamiento |
|---------|----------------|
| `SensorTemperatura(double umbral)` | Crea el sensor sin lecturas |
| `double Umbral` | La temperatura máxima normal |
| `double? Ultima` | La última temperatura registrada, o `null` si no hay ninguna |
| `bool Alerta` | Si la última temperatura es **mayor** que el umbral (justo en el umbral no es alerta) |
| `void Registrar(double temperatura)` | Guarda la lectura y lanza el evento que corresponda |
| `event EventHandler<TemperaturaEventArgs>? UmbralSuperado` | Al **pasar** de no estar en alerta a estarlo. No se repite mientras siga en alerta |
| `event EventHandler<TemperaturaEventArgs>? TemperaturaNormalizada` | Al **volver** de una alerta a una temperatura normal |

Los dos eventos se lanzan con `?.Invoke(this, …)`: el emisor es el sensor y, sin oyentes, no falla.

### `RegistroAlertas`

Un **suscriptor**: `Vigilar(sensor)` se suscribe a los dos eventos de un sensor y `DejarDeVigilar(sensor)` se da de baja. Cada aviso añade una línea a `Entradas`:

```text
Alerta: 31,5 °C (umbral 30 °C)
Normal: 28 °C
```

Los números van con coma decimal sea cual sea el idioma del equipo (usa `CultureInfo("es-ES")`).

## Comprueba tu solución

1. Todas las pruebas en verde y **ninguna** con `Skip` (`dotnet test --solution Invernadero.slnx`).
2. Haz a mano el recorrido con un umbral de 30 y estas lecturas, y comprueba que las pruebas dicen lo mismo: 28 (nada), 31 (`UmbralSuperado`), 33 (nada), 30 (`TemperaturaNormalizada`), 29 (nada), 35 (`UmbralSuperado`).
3. ¿Qué pasaría si `RegistroAlertas` se suscribiera con una lambda en lugar de un método? Intenta escribir `DejarDeVigilar` así y explica el problema.
4. ¿Por qué los eventos se declaran con `event` y no como propiedades públicas de tipo `EventHandler<…>` (tema 9, apartado 9.5.5)?

> **Desafío (sin pruebas):** añade una **histéresis**: el sensor solo vuelve a la normalidad cuando la temperatura baja al menos 1 °C del umbral, para que no avise veinte veces si la temperatura baila alrededor de 30.
