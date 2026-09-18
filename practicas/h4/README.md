
# C4 - Sistema de Reservas de un Hostal

## Nivel 1 - Contexto

En este nivel se muestra el sistema de reservas del hostal y las personas y sistemas externos que tienen relación con el aquí se puede ver quién utiliza el sistema y para qué lo utiliza ademas de los servicios externos que ayudan al funcionamiento del sistema.

```mermaid
C4Context

title Nivel 1 - Contexto del Sistema de Reservas de un Hostal

Person(cliente, "Cliente", "Consulta habitaciones y realiza reservas")
Person(recepcionista, "Recepcionista", "Registra huéspedes y gestiona reservas")
Person(administrador, "Administrador", "Gestiona habitaciones, usuarios y tarifas")
Person(limpieza, "Personal de limpieza", "Consulta y actualiza el estado de las habitaciones")

System(sistema, "Sistema de Reservas de un Hostal", "Permite gestionar habitaciones, reservas, huéspedes y pagos")

System_Ext(pagos, "Pasarela de pagos", "Procesa los pagos de las reservas")
System_Ext(notificaciones, "Servicio de notificaciones", "Envía avisos y comprobantes a los clientes")

Rel(cliente, sistema, "Realiza y consulta reservas")
Rel(recepcionista, sistema, "Gestiona reservas y huéspedes")
Rel(administrador, sistema, "Gestiona el sistema")
Rel(limpieza, sistema, "Actualiza el estado de habitaciones")

Rel(sistema, pagos, "Procesa pagos")
Rel(sistema, notificaciones, "Envía avisos y comprobantes")
```

## Nivel 2 - Contenedores

En este nivel se muestran las partes principales que están dentro del sistema de reservas del hostal aqui se puede ver dónde se encuentra la logica del sistema donde se guardan los datos como se gestionan los pagos y cómo se envían los avisos


```mermaid
C4Container

title Nivel 2 - Contenedores del Sistema de Reservas del Hostal

Person(cliente, "Cliente")
Person(recepcionista, "Recepcionista")
Person(administrador, "Administrador")
Person(limpieza, "Personal de limpieza")

System_Boundary(sistema, "Sistema de Reservas del Hostal") {

    Container(reservas, "Gestión de Reservas", "Aplicación", "Permite registrar, consultar y cancelar reservas")

    Container(habitaciones, "Gestión de Habitaciones", "Aplicación", "Permite consultar disponibilidad y estado de las habitaciones")

    Container(usuarios, "Gestión de Usuarios", "Aplicación", "Gestiona los usuarios y sus roles")

    Container(pagos, "Gestión de Pagos", "Aplicación", "Registra pagos y genera comprobantes")

    ContainerDb(baseDatos, "Base de Datos", "MySQL", "Guarda usuarios, habitaciones, reservas y pagos")

    Container(notificaciones, "Servicio de Notificaciones", "Aplicación", "Envía avisos y comprobantes")
}

System_Ext(pasarela, "Pasarela de pagos", "Procesa los pagos")

Rel(cliente, reservas, "Realiza y consulta reservas")
Rel(recepcionista, reservas, "Gestiona reservas")
Rel(recepcionista, usuarios, "Registra huéspedes")
Rel(administrador, usuarios, "Gestiona usuarios")
Rel(administrador, habitaciones, "Gestiona habitaciones")
Rel(administrador, reservas, "Gestiona reservas")
Rel(limpieza, habitaciones, "Actualiza el estado")

Rel(reservas, baseDatos, "Guarda y consulta datos")
Rel(habitaciones, baseDatos, "Guarda y consulta datos")
Rel(usuarios, baseDatos, "Guarda y consulta datos")
Rel(pagos, baseDatos, "Guarda pagos")
Rel(notificaciones, reservas, "Recibe información de reservas")

Rel(pagos, pasarela, "Procesa pagos")
```


