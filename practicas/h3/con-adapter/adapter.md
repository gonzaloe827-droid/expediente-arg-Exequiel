
# Práctica 4  Adapter

## Sistema externo

Elegí una pasarela de pago externa porque el sistema de reservas necesita registrar pagos

## Contrato

En mi sistema definí el contrato IProcesadorPago con el método ProcesarPago()

## Adaptador

La pasarela externa utiliza PagarTransaccion(), por eso creé PagoAdapter para traducir la llamada.

## Resultado

El sistema del hostal usa su propio contrato y no necesita conocer directamente cómo funciona la pasarela externa.
