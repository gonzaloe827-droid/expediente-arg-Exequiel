
namespace H3.Observer;


// CONTRATO DEL OBSERVER

public interface IObservadorReserva
{
    void Actualizar(string mensaje);
}

// SUJETO

public class GestionReservas
{
    private readonly List<IObservadorReserva> observadores =
        new List<IObservadorReserva>();

    public void Suscribir(IObservadorReserva observador)
    {
        observadores.Add(observador);
    }

    public void registrarReserva(string cliente, string habitacion)
    {
        Console.WriteLine("HOSTAL          Registrando nueva reserva...");
        Console.WriteLine($"Cliente: {cliente}");
        Console.WriteLine($"Habitación: {habitacion}");

        Notificar(
            $"Nueva reserva registrada para {cliente} en la {habitacion}."
        );
    }

    private void Notificar(string mensaje)
    {
        foreach (var observador in observadores)
        {
            observador.Actualizar(mensaje);
        }
    }

    public void cancelarReserva()
    {
        Console.WriteLine("HOSTAL Reserva cancelada.");
    }

    public void consultarReserva()
    {
        Console.WriteLine("[HOSTAL] Consultando reserva.");
    }
}

// OBSERVADOR 1

public class Cliente : IObservadorReserva
{
    public void Actualizar(string mensaje)
    {
        Console.WriteLine($"[CLIENTE] {mensaje}");
    }
}

// OBSERVADOR 2

public class Recepcionista : IObservadorReserva
{
    public void Actualizar(string mensaje)
    {
        Console.WriteLine($"[RECEPCIONISTA] {mensaje}");
    }
}


public static class Demo
{
    public static void Correr()
    {
        Console.WriteLine("         OBSERVER");

        Console.WriteLine();

        var gestionReservas = new GestionReservas();

        var cliente = new Cliente();
        var recepcionista = new Recepcionista();

        gestionReservas.Suscribir(cliente);
        gestionReservas.Suscribir(recepcionista);

        gestionReservas.registrarReserva(
            "Marco",
            "Habitación Doble"
        );

        Console.WriteLine();

        Console.WriteLine(
            "GestionReservas avisa a los observadores cuando se registra una reserva."
        );

        Console.WriteLine(
            "El Cliente y la Recepcionista reciben la notificación."
        );
    }
}
