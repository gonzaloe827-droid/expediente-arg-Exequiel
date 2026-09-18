
# ADR-001 - Separación del sistema en contenedores

## Estado

Aceptado

## Contexto

El sistema de reservas del hostal tiene diferentes funciones como gestionar reservas, habitaciones, usuarios y pagos.

Si todas estas funciones estuvieran juntas en una sola parte del sistema, sería más difícil realizar cambios y mantener el proyecto.

Por eso se decidió separar el sistema en diferentes contenedores, donde cada uno tiene una función específica.

## Decisión

Se decidió dividir el sistema en los siguientes contenedores:

- Gestión de Reservas
- Gestión de Habitaciones
- Gestión de Usuarios
- Gestión de Pagos
- Servicio de Notificaciones
- Base de Datos

Cada contenedor tendrá una responsabilidad diferente y se comunicará con los demás cuando sea necesario.

## Consecuencias

### Positivas

- El sistema queda más ordenado.
- Es más fácil encontrar cada función.
- Los cambios en una parte afectan menos a las otras.
- Se puede mantener cada contenedor de forma más sencilla.

### Negativas

- Hay más partes que organizar.
- Los contenedores necesitan comunicarse entre ellos.
- El diseño inicial puede tomar un poco más de tiempo.

## Alternativas consideradas

### Una sola aplicación

Se podría colocar toda la lógica del sistema en una sola parte.

No se eligió porque sería más difícil mantener y modificar el sistema cuando aumenten las funciones.

### Separar solamente la base de datos

También se podría mantener toda la lógica junta y solamente separar la base de datos.

No se eligió porque las diferentes funciones del sistema seguirían estando mezcladas.

## Relación con el diseño

Esta decisión se refleja principalmente en el Nivel 2 - Contenedores del modelo C4, donde se muestran las diferentes partes del sistema y la función de cada una.
