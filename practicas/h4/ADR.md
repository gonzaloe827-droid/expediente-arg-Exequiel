
# ADR-001 - Separación del sistema en contenedores

## Estado

Aceptado

## Contexto

El sistema de reservas del hostal tiene diferentes funciones como gestionar reservas, habitaciones, usuarios y pagos.

Si todas estas funciones estuvieran juntas en una sola parte del sistema, sería más difícil realizar cambios y mantener el proyecto.

Por eso se decidió separar el sistema en diferentes contenedores, donde cada uno tiene una función específica.


