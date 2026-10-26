# E09 · El taller tiene fallos

**Tipo:** autocorrección

El programa del taller mecánico **tiene seis fallos**. Encuéntralos y corrígelos como en un equipo profesional: para cada uno, primero escribe una **prueba que lo reproduzca** (en rojo), después busca la causa con el **depurador** y por último corrígela hasta que la prueba pase (en verde).

**CE:** — (formativo; prepara el RA1 y las pruebas de las UD4 y UD6) · **Dificultad:** ★★☆ · **Tiempo estimado:** 2 h · **Tema:** 12

## Punto de partida

- `GestionTaller.Logica`: `Coche` y `EstadoReparacion` están bien. **Todos los fallos están en `Taller.cs`.** Los comentarios XML dicen lo que **debe** hacer cada método: son la referencia.
- `GestionTaller.Consola/Program.cs`: no lo modifiques.
- `GestionTaller.Pruebas/TallerPruebas.cs`: siete pruebas que pasan. Ninguna detecta los fallos.

## Lo que cuentan los usuarios

1. «El programa se cierra nada más arrancar, con un error de que no encuentra el coche 1234 bcd.»
2. «Se puede dar de alta dos veces el mismo coche si escribes la matrícula en minúsculas.»
3. «El contador de pendientes no cuenta los coches que ya están en reparación.»
4. «Las facturas salen sin IVA.»
5. «No hay forma de sacar del taller el último coche que ha entrado.»
6. «Algunas facturas salen con un céntimo menos de lo que sale con la calculadora.» (Pista: 2,5 horas.)

## Requisitos

Para **cada** fallo, en este orden:

1. **Reprodúcelo con una prueba** en `TallerPruebas.cs`, llamada `FalloN_…` (por ejemplo, `Fallo4_CalcularFactura_IncluyeElIva`). Ejecútala: **debe fallar**. Si pasa, la prueba no reproduce el fallo.
2. **Localiza la causa con el depurador**: pon un punto de interrupción, ejecuta la prueba con «Depurar» desde el Explorador de pruebas, avanza con F10 y F11 y mira los valores en las ventanas **Locales** e **Inspección**. Para el fallo 1, lee la **pila de llamadas** de la excepción.
3. **Corrige la causa** en `Taller.cs` (no el síntoma en `Program.cs`).
4. Ejecuta **todas** las pruebas: la nueva debe pasar y las anteriores también.

Anota en un comentario encima de cada prueba nueva qué estaba mal y cómo lo has visto en el depurador.

## Comprueba tu solución

1. 13 pruebas (las 7 de partida y una por fallo), todas en verde.
2. `GestionTaller.Consola` muestra exactamente:

   ```text
   🚗 Entra 1234 BCD: True
   🚗 Entra 5678 FGH: True
   🚗 Entra 9012 JKL: True
   🚗 Entra 1234bcd otra vez: False
   🔧 Pendientes: 2
   🔎 Buscar 5678 fgh: 5678FGH · Renault · EnReparacion
   🧾 Factura de 1234BCD: 136,13 €
   🗑️ Sale 9012JKL (el último): True
   📋 Quedan 2 coches:
      1234BCD · Seat · Reparado
      5678FGH · Renault · EnReparacion
   ```

3. Vuelve a introducir uno de los fallos a propósito: ¿qué prueba se pone en rojo? Así funcionan las **pruebas de regresión**.

> **Para qué te servirá:** en todas las unidades, cuando algo no funcione: reprodúcelo, depúralo, corrígelo y deja una prueba que impida que vuelva.
