namespace H3.Final;

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


public class Cliente : Usuario, IObservadorReserva
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

    public void Actualizar(string mensaje)
    {
        Console.WriteLine($"[CLIENTE] {mensaje}");
    }
}


public class Recepcionista : Usuario, IObservadorReserva
{
    public void registrarHuesped()
    {
        Console.WriteLine("Recepcionista registra huésped");
    }

    public void gestionarReserva()
    {
        Console.WriteLine("Recepcionista gestiona reservas");
    }

    public void Actualizar(string mensaje)
    {
        Console.WriteLine($"[RECEPCIONISTA] {mensaje}");
    }
}


public class Administrador : Usuario, IObservadorReserva
{
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

    public void Actualizar(string mensaje)
    {
        Console.WriteLine($"[ADMINISTRADOR] {mensaje}");
    }
}

public interface IObservadorReserva
{
    void Actualizar(string mensaje);
}

public interface ICalculoTarifa
{
    decimal Calcular(bool privada);
}

public class TarifaHabitacionSimple : ICalculoTarifa
{
    private decimal precioCompartida = 100;
    private decimal precioPrivada = 300;

    public decimal Calcular(bool privada)
    {
        if (privada)
            return precioPrivada;

        return precioCompartida;
    }
}

public class TarifaHabitacionDoble : ICalculoTarifa
{
    private decimal precioCompartida = 160;
    private decimal precioPrivada = 450;

    public decimal Calcular(bool privada)
    {
        if (privada)
            return precioPrivada;

        return precioCompartida;
    }
}


public class TarifaHabitacionMatrimonial : ICalculoTarifa
{
    private decimal precioCompartida = 160;
    private decimal precioPrivada = 450;

    public decimal Calcular(bool privada)
    {
        if (privada)
            return precioPrivada;

        return precioCompartida;
    }
}


public class TarifaHabitacionTriple : ICalculoTarifa
{
    private decimal precioCompartida = 240;
    private decimal precioPrivada = 600;

    public decimal Calcular(bool privada)
    {
        if (privada)
            return precioPrivada;

        return precioCompartida;
    }
}

public class TarifaHabitacionCuadruple : ICalculoTarifa
{
    private decimal precioCompartida = 320;
    private decimal precioPrivada = 800;

    public decimal Calcular(bool privada)
    {
        if (privada)
            return precioPrivada;

        return precioCompartida;
    }
}


public class GestionTarifas
{
    public decimal CalcularTarifa(
        ICalculoTarifa estrategia,
        bool privada)
    {
        return estrategia.Calcular(privada);
    }
}

public abstract class Habitacion
{
    public bool privada { get; set; }

    public void consultarDisponibilidad()
    {
        Console.WriteLine(
            "Habitación disponible");
    }
}

public class HabitacionSimple : Habitacion { }

public class HabitacionDoble : Habitacion { }

public class HabitacionMatrimonial : Habitacion { }

public class HabitacionTriple : Habitacion { }

public class HabitacionCuadruple : Habitacion { }

public class GestionHabitaciones
{
    public void registrarHabitacion()
    {
        Console.WriteLine(
            "Registrando habitación");
    }

    public void consultarDisponibilidad()
    {
        Console.WriteLine(
            "Consultando disponibilidad");
    }

    public void cambiarEstado()
    {
        Console.WriteLine(
            "Cambiando estado de habitación");
    }
}

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
        Console.WriteLine(
            "[MYSQL] Reserva guardada");
    }

    public void eliminarReserva()
    {
        Console.WriteLine(
            "[MYSQL] Reserva eliminada");
    }

    public void buscarReserva()
    {
        Console.WriteLine(
            "[MYSQL] Reserva encontrada");
    }
}

public class GestionReservas
{
    private IReservaRepository repository;

    private GestionTarifas gestionTarifas;

    private IObservadorReserva? observador1;

    private IObservadorReserva? observador2;

    private IObservadorReserva? observador3;


    public GestionReservas(
        IReservaRepository repository,
        GestionTarifas gestionTarifas)
    {
        this.repository = repository;

        this.gestionTarifas = gestionTarifas;
    }

    
    public void Suscribir(
        IObservadorReserva observador)
    {
        if (observador1 == null)
            observador1 = observador;

        else if (observador2 == null)
            observador2 = observador;

        else
            observador3 = observador;
    }


    public void registrarReserva(
        string cliente,
        string habitacion,
        bool privada,
        ICalculoTarifa estrategia)
    {
        Console.WriteLine();

        Console.WriteLine(
            "Registrando reserva...");

        Console.WriteLine(
            $"Cliente: {cliente}");

        Console.WriteLine(
            $"Habitación: {habitacion}");

        Console.WriteLine(
            $"Modalidad: {(privada ? "Privada" : "Compartida")}");


        decimal precio =
            gestionTarifas.CalcularTarifa(
                estrategia,
                privada);


        Console.WriteLine(
            $"Tarifa: {precio:0.00} Bs");


        repository.guardarReserva();


        Notificar(
            $"Nueva reserva registrada para {cliente}.");
    }


    private void Notificar(
        string mensaje)
    {
        if (observador1 != null)
            observador1.Actualizar(mensaje);

        if (observador2 != null)
            observador2.Actualizar(mensaje);

        if (observador3 != null)
            observador3.Actualizar(mensaje);
    }


    public void cancelarReserva()
    {
        Console.WriteLine(
            "Cancelando reserva...");

        repository.eliminarReserva();
    }


    public void consultarReserva()
    {
        Console.WriteLine(
            "Consultando reserva...");

        repository.buscarReserva();
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
        Console.WriteLine(
            "[PAGO] Pago procesado correctamente");
    }
}


public class GestionPagos
{
    private IProcesadorPago procesador;


    public GestionPagos(
        IProcesadorPago procesador)
    {
        this.procesador = procesador;
    }


    public void registrarPago()
    {
        Console.WriteLine(
            "Registrando pago...");

        procesador.procesarPago();
    }


    public void generarComprobante()
    {
        Console.WriteLine(
            "Generando comprobante");
    }
}


public static class Demo
{
    public static void Correr()
    {

        Console.WriteLine(
            " SISTEMA DE RESERVAS DEL HOSTAL");

        var cliente =
            new Cliente();

        var recepcionista =
            new Recepcionista();

        var administrador =
            new Administrador();

        var gestionTarifas =
            new GestionTarifas();

        var tarifaSimple =
            new TarifaHabitacionSimple();

        var tarifaDoble =
            new TarifaHabitacionDoble();

        var tarifaMatrimonial =
            new TarifaHabitacionMatrimonial();

        var tarifaTriple =
            new TarifaHabitacionTriple();

        var tarifaCuadruple =
            new TarifaHabitacionCuadruple();


        var repositorio =
            new BaseDatosMySQL();


        var gestionReservas =
            new GestionReservas(
                repositorio,
                gestionTarifas);


        gestionReservas.Suscribir(
            cliente);

        gestionReservas.Suscribir(
            recepcionista);

        gestionReservas.Suscribir(
            administrador);


        gestionReservas.registrarReserva(
            "Lucas",
            "Habitacion Triple",
            true,
            tarifaMatrimonial);


        Console.WriteLine();

        var habitacion =
            new HabitacionMatrimonial();

        habitacion.privada = false;


        var gestionHabitaciones =
            new GestionHabitaciones();


        gestionHabitaciones.registrarHabitacion();

        gestionHabitaciones.consultarDisponibilidad();

        Console.WriteLine();

        var servicioPago =
            new ServicioPago();


        var gestionPagos =
            new GestionPagos(
                servicioPago);


        gestionPagos.registrarPago();

        gestionPagos.generarComprobante();

        Console.WriteLine();

        Console.WriteLine(
            "PROGRAMA FINALIZADO");
    }
}
