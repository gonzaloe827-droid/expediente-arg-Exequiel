
# Práctica 3 builder

## Objeto complejo

viendo el tema que elegi reservas de un hostal elegí la reserva porque tiene varios datos que se pueden construir paso a paso.

## Pasos del Builder

1. ConCliente
2. ConHabitacion
3. ConFechaEntrada
4. ConFechaSalida
5. ConRecordatorio

## Guardian

El método Build valida que el cliente no este vacio y que la fecha de salida sea posterior a la fecha de entrada.

## Resultado

La reserva se construye paso a paso y solo se devuelve cuando pasa las dos validaciones.
