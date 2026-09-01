# h1 sistema de reservas de un hostal 

nombre: Gonzalo Exequiel Bautista 
variante 3 

## 1: Actores 

### 1. Cliente o huesped 
Consulta habitaciones disponibles
Realiza reservas
Cancela reservas
Consulta sus reservas

### 2. Recepcionista 
Registra huéspedes
Gestiona reservas
Consulta la disponibilidad de habitaciones

### 3. Administrador
Administra habitaciones
Administra usuarios
Gestiona tarifas
Consulta información del hostal

### 4. Personal de limpieza
Consulta el estado de las habitaciones
Actualiza el estado de las habitaciones después de la limpieza

## 2:Inventarios de modulos 

### 1. Gestión de habitaciones
Responsabilidad: 
Administrar las habitaciones y su disponibilidad.

### 2. Gestión de reservas
Responsabilidad:
Crear, modificar, cancelar y consultar reservas.

### 3. Gestión de huéspedes
Responsabilidad:
Registrar y administrar la información de los huéspedes.

### 4. entrada y salida del huesped 
Responsabilidad:
Gestionar la entrada y salida de los huéspedes.

### 5. Gestión de pagos

Responsabilidad:
Registrar y controlar los pagos de las reservas.

## 3: diagrama de clases UML 

Primer borrador del diagrama de clases 
![Diagrama UML](diagramahostal.png)

## 4: Atributos de calidad criticos 

### 1. Seguridad

La seguridad es un atributo crítico porque el sistema manejará
información personal de los huéspedes, reservas y pagos. Se deben controlar
los accesos según el tipo de usuario para evitar modificaciones o accesos
no autorizados a la información.

### 2. Disponibilidad

La disponibilidad es crítica porque el sistema será utilizado
para consultar habitaciones y gestionar reservas durante las operaciones
del hostal. Una interrupción del sistema podría impedir registrar reservas,
consultar disponibilidad y realizar correctamente la atención al huésped.

# Práctica 1 SOLID 

## Responsabilidad Única

### Problema

En mi diseño inicial, la clase `Reserva` tenía varias funciones, como crear, cancelar y confirmar una reserva, además de hacer el check-in y check-out. Vi que estaba haciendo demasiadas cosas.

### Solución

Para aplicar SRP, separé esas funciones en diferentes clases. Dejé `Reserva` para guardar los datos de la reserva, `GestorDeReservas` para crear, cancelar y confirmar reservas, y `GestorDeEstadia` para realizar el check-in y check-out.

### Resultado

Con este cambio, cada clase tiene una responsabilidad más clara. Así, si necesito cambiar algo de las reservas, modifico `GestorDeReservas`, y si cambia el proceso de check-in o check-out, modifico `GestorDeEstadia`.

## Diagrama de la práctica SRP

![Diagrama SRP](practica-srp-hostal.png.png)

# Práctica 2 SOLID 

## Principio Abierto/Cerrado

### Problema

En el sistema pueden existir diferentes tipos de habitaciones. Si se utilizara un switch para identificar cada tipo, sería necesario modificar el código cada vez que aparezca un nuevo tipo.

### Solución

Creé la interfaz `TipoHabitacion`, que contiene el método `calcularPrecio()`. Luego cada tipo de habitación implementa esta interfaz.

### Resultado

El sistema puede trabajar con diferentes tipos de habitaciones sin modificar las clases existentes. Si aparece un nuevo tipo, solamente se crea una nueva clase que implemente `TipoHabitacion`.

## Diagrama OCP

![Diagrama OCP](practica2.png.png)
