
# Práctica 2 Factory 

## RF5: Avisos

El sistema necesita enviar avisos por diferentes canales como WhatsApp, correo y SMS.

## Contrato

Se creó la interfaz IAviso con el método Enviar

## Fábrica

Se creó FabricaAviso para crear los diferentes tipos de avisos

## Productos

- AvisoWhatsApp
- AvisoCorreo
- AvisoSms

## Lugar único

Si llega un nuevo canal de aviso por ejemplo como telegram que tambien es un tipo de canal como whatsapp se agrega su producto y su fábrica correspondiente sin modificar el código que utiliza los avisos.
