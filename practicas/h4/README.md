
# H4 - Arquitectura del Sistema de Reservas del Hostal

## Nivel 1 — Contexto

En este nivel mostramos el sistema de reservas del hostal desde una vista general aquí se pueden ver las personas que utilizan el sistema y los sistemas externos que tienen relación con él.

```mermaid
flowchart TB

cliente["👤 Cliente<br>(realiza y consulta reservas)"]

recepcionista["👤 Recepcionista<br>(gestiona reservas y huéspedes)"]

administrador["👤 Administrador<br>(gestiona habitaciones, usuarios y tarifas)"]

sistema["🏨 SISTEMA DE RESERVAS DEL HOSTAL<br>Gestiona habitaciones, reservas, huéspedes y pagos"]

pasarela["💳 Pasarela de pagos<br>(externa)"]

notificaciones["📧 Servicio de notificaciones<br>(externo)"]


cliente -->|"realiza y consulta reservas"| sistema

recepcionista -->|"gestiona reservas y huéspedes"| sistema

administrador -->|"gestiona el sistema"| sistema

sistema -->|"procesa pagos"| pasarela

sistema -->|"envía avisos y comprobantes"| notificaciones
```
## Nivel 2 - Contenedores

En este nivel se muestran las partes principales que están dentro del sistema de reservas del hostal aqui se puede ver dónde se encuentra la logica del sistema donde se guardan los datos como se gestionan los pagos y cómo se envían los avisos


```mermaid
flowchart TB
 subgraph sistema["🏨 SISTEMA DE RESERVAS DEL HOSTAL"]
        reservas["📋 Gestión de Reservas<br>(registra y consulta reservas)<br>🔔 Observer"]
        tarifas["💰 Gestión de Tarifas<br>(calcula precios)<br>🔄 Strategy"]
        habitaciones["🛏️ Gestión de Habitaciones<br>(registra y consulta habitaciones)"]
        usuarios["👥 Gestión de Usuarios<br>(gestiona usuarios y roles)"]
        pagos["💳 Gestión de Pagos<br>(registra pagos y comprobantes)"]
        bd[("🗄️ Base de Datos<br>MySQL")]
  end
    cliente["👤 Cliente<br>(realiza y consulta reservas)"] -- realiza reservas --> reservas
    recepcionista["👤 Recepcionista<br>(gestiona reservas y huéspedes)"] -- gestiona reservas --> reservas
    administrador["👤 Administrador<br>(gestiona usuarios y tarifas)"] -- administra usuarios --> usuarios
    administrador -- gestiona tarifas --> tarifas
    reservas -- consulta tarifa --> tarifas
    reservas -- guarda y consulta --> bd
    habitaciones -- guarda información --> bd
    usuarios -- guarda información --> bd
    pagos -- guarda información --> bd
    reservas -- solicita pago --> pagos
    pagos -- procesa pago --> pasarela["💳 Pasarela de pagos<br>(sistema externo)"]
```
