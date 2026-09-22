
# Detecciones SOLID

**Gonzalo Exequiel Bautista**

## 1. Principio abierto/cerrado

**Dónde:** En la clase GestorDePedidos, dentro del método ProcesarPedido(), específicamente en el `switch` que revisa el tipo de menu

**Por qué:** El problema es que si más adelante queremos agregar otro tipo de menu tenemos que volver a modificar este método y agregar otro case. Esto hace que el código no sea fácil de anpliar sin modificar lo que ya existe

## 2. Principio de responsabilidad única

**Dónde:** En la clase GestorDePedidos, en el método ProcesarPedido()

**Por qué:** El método está haciendo varias cosas diferentes primero calcula el precio, después guarda el pedido en la base de datos también muestra el vale y finalmente manda un correo sería mejor separar estas tareas para que cada parte tenga una responsabilidad más clara

## 3. Principio de inversión de dependencias

**Dónde:** En GestorDePedidos, cuando se crean directamente BaseDeDatosComedor y CorreoUniversitario usando new

**Por qué:** GestorDePedidos depende directamente de esas clases si despues queremos cambiar la forma de guardar los pedidos o la forma de enviar los avisos tendríamos que modificar el gestor lo ideal sería que dependiera de una abstracción y no directamente de esas clases
