
namespace SistemaReservasHostal;

// USUARIO Y ROLES

public class Usuario
{
    public void iniciarSesion()
    {
        Console.WriteLine("Usuario inició sesión");
    }

    public void cerrarSesion()
    {
        Console.WriteLine("Usuario cerró sesión");
    }
}

public class Cliente : Usuario
{
    public void consultarReserva()
    {
        Console.WriteLine("Cliente consulta sus reservas");
    }

    public void realizarReserva()
    {
        Console.WriteLine("Cliente realiza una reserva");
    }

    public void cancelarReserva()
    {
        Console.WriteLine("Cliente cancela una reserva");
    }
}

public class Recepcionista : Usuario, IRegistrador, IGestorReservas
{
    public void registrarHuesped()
    {
        Console.WriteLine("Recepcionista registra huésped");
    }

    public void gestionarReserva()
    {
        Console.WriteLine("Recepcionista gestiona reservas");
    }
}

public class Administrador : Usuario,
    IGestorReservas,
    IGestorHabitaciones,
    IGestorUsuarios,
    IGestorTarifas
{
    public void gestionarReserva()
    {
        Console.WriteLine("Administrador gestiona reservas");
    }

    public void gestionarHabitaciones()
    {
        Console.WriteLine("Administrador gestiona habitaciones");
    }

    public void gestionarUsuarios()
    {
        Console.WriteLine("Administrador gestiona usuarios");
    }

    public void gestionarTarifas()
    {
        Console.WriteLine("Administrador gestiona tarifas");
    }
}


// INTERFACES DE ROLES

public interface IRegistrador
{
    void registrarHuesped();
}

public interface IGestorReservas
{
    void gestionarReserva();
}

public interface IGestorHabitaciones
{
    void gestionarHabitaciones();
}

public interface IGestorUsuarios
{
    void gestionarUsuarios();
}

public interface IGestorTarifas
{
    void gestionarTarifas();
}


// GESTIÓN DE RESERVAS

public class GestionReservas
{
    private readonly IReservaRepository repository;

    public GestionReservas(IReservaRepository repository)
    {
        this.repository = repository;
    }

    public void registrarReserva()
    {
        Console.WriteLine("Registrando reserva...");
        repository.guardarReserva();
    }

    public void cancelarReserva()
    {
        Console.WriteLine("Cancelando reserva...");
        repository.eliminarReserva();
    }

    public void consultarReserva()
    {
        Console.WriteLine("Consultando reserva...");
        repository.buscarReserva();
    }
}

// REPOSITORIO

public interface IReservaRepository
{
    void guardarReserva();
    void eliminarReserva();
    void buscarReserva();
}

public class BaseDatosMySQL : IReservaRepository
{
    public void guardarReserva()
    {
        Console.WriteLine("[MYSQL] Reserva guardada");
    }

    public void eliminarReserva()
    {
        Console.WriteLine("[MYSQL] Reserva eliminada");
    }

    public void buscarReserva()
    {
        Console.WriteLine("[MYSQL] Reserva encontrada");
    }
}

public class RepositorioReservaPrueba : IReservaRepository
{
    public void guardarReserva()
    {
        Console.WriteLine("[PRUEBA] Reserva guardada");
    }

    public void eliminarReserva()
    {
        Console.WriteLine("[PRUEBA] Reserva eliminada");
    }

    public void buscarReserva()
    {
        Console.WriteLine("[PRUEBA] Reserva encontrada");
    }
}


// HABITACIONES

public abstract class Habitacion
{
    public bool privada { get; set; }

    public virtual void consultarDisponibilidad()
    {
        Console.WriteLine("Consultando disponibilidad");
    }

    public abstract decimal calcularPrecio();
}

public class HabitacionSimple : Habitacion
{
    public override decimal calcularPrecio()
    {
        return 100;
    }
}

public class HabitacionDoble : Habitacion
{
    public override decimal calcularPrecio()
    {
        return 150;
    }
}

public class HabitacionMatrimonial : Habitacion
{
    public override decimal calcularPrecio()
    {
        return 160;
    }
}

public class HabitacionTriple : Habitacion
{
    public override decimal calcularPrecio()
    {
        return 200;
    }
}

public class HabitacionCuadruple : Habitacion
{
    public override decimal calcularPrecio()
    {
        return 250;
    }
}

// GESTIÓN DE HABITACIONES

public class GestionHabitaciones
{
    public void registrarHabitacion()
    {
        Console.WriteLine("Registrando habitación");
    }

    public void consultarDisponibilidad()
    {
        Console.WriteLine("Consultando disponibilidad");
    }

    public void cambiarEstado()
    {
        Console.WriteLine("Cambiando estado de habitación");
    }
}

// GESTIÓN DE PAGOS

public class GestionPagos
{
    private readonly IProcesadorPago procesador;

    public GestionPagos(IProcesadorPago procesador)
    {
        this.procesador = procesador;
    }

    public void registrarPago()
    {
        Console.WriteLine("Registrando pago...");
        procesador.procesarPago();
    }

    public void consultarPago()
    {
        Console.WriteLine("Consultando pago");
    }

    public void generarComprobante()
    {
        Console.WriteLine("Generando comprobante");
    }
}

public interface IProcesadorPago
{
    void procesarPago();
}

public class ServicioPago : IProcesadorPago
{
    public void procesarPago()
    {
        Console.WriteLine("[PAGO] Pago procesado correctamente");
    }
}



public static class Demo
{
    public static void Correr()
    {
        Console.WriteLine("   SISTEMA DE RESERVAS DEL HOSTAL");

        Console.WriteLine();
        Console.WriteLine("CLIENTE");

        var cliente = new Cliente();

        cliente.iniciarSesion();
        cliente.realizarReserva();
        cliente.consultarReserva();

        Console.WriteLine();
        Console.WriteLine("RESERVA");

        var repositorio = new BaseDatosMySQL();
        var gestionReservas = new GestionReservas(repositorio);

        gestionReservas.registrarReserva();
        gestionReservas.consultarReserva();

        Console.WriteLine();
        Console.WriteLine("HABITACIÓN");

        var habitacion = new HabitacionDoble();

        Console.WriteLine("Tipo: Habitación Doble");
        Console.WriteLine($"Precio: {habitacion.calcularPrecio()} Bs");

        Console.WriteLine();
        Console.WriteLine("PAGO");
        var servicioPago = new ServicioPago();
        var gestionPagos = new GestionPagos(servicioPago);

        gestionPagos.registrarPago();
        gestionPagos.generarComprobante();

        Console.WriteLine();
        Console.WriteLine("       PROGRAMA FINALIZADO");
    }
}
