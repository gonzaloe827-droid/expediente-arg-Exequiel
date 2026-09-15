
# Parcial 2 

## Situacion 1 

### Patron observer

Yo elegiría observer porque cuando una membresía vence se necesita avisar a varias partes del gimnasio. ahora el módulo de socios tiene que avisar uno por uno a whatsap al registro de vencidos y a recepción 
el problema es que si después aparece otro módulo que también necesita recibir el aviso tenemos que volver a modificar el módulo de socios con Observer podemos hacer que el módulo avise una sola vez y que los demás reciban la notificación cuando estén registrados

## Situacion 2

Patro Strategy

Yo elegiría strategy porque en el gimnasio existen diferentes formas de calcular la tarifa dependiendo del horario por ejemplo en la mañana se cobra la tarifa normal en la noche aumenta un 20% y el fin de semana tiene un descuento del 30%
actualmente este cálculo está dentro de un if/else y además está repetido en el módulo de cotizaciones con Strategy podemos separar cada forma de cálculo y cambiar una regla sin tener que modificar todo el código

## Situacion 3

Patron Adapter

Yo elegiría Adapter porque el gimnasio necesita usar una pasarela de pago que funciona de una manera diferente a nuestro sistema a pasarela utiliza nombres en ingles trabaja con el monto en centavos y utiliza un token que nuestro sistema no maneja directamente
ademas nosotros no podemos modificar el código de la pasarela porque pertenece al proveedor con Adapter podemos hacer una conexión entre nuestro sistema y la pasarela sin tener que cambiar el codigo de la pasarela 


