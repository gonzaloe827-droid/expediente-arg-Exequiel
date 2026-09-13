
namespace H3.ConBuilder;

// OBJETO COMPLEJO RESERVA

public class Reserva
{
    public string Cliente { get; set; } = "";
    public string Habitacion { get; set; } = "";
    public DateTime FechaEntrada { get; set; }
    public DateTime FechaSalida { get; set; }
    public bool Recordatorio { get; set; }

    public void Mostrar()
    {
        Console.WriteLine("        RESERVA CREADA");

        Console.WriteLine($"Cliente: {Cliente}");
        Console.WriteLine($"Habitación: {Habitacion}");
        Console.WriteLine($"Entrada: {FechaEntrada:dd/MM/yyyy}");
        Console.WriteLine($"Salida: {FechaSalida:dd/MM/yyyy}");
        Console.WriteLine($"Recordatorio: {(Recordatorio ? "Sí" : "No")}");
    }
}

// BUILDER

public class ReservaBuilder
{
    private readonly Reserva reserva = new Reserva();

    public ReservaBuilder ConCliente(string cliente)
    {
        reserva.Cliente = cliente;
        return this;
    }

    public ReservaBuilder ConHabitacion(string habitacion)
    {
        reserva.Habitacion = habitacion;
        return this;
    }

    public ReservaBuilder ConFechaEntrada(DateTime fecha)
    {
        reserva.FechaEntrada = fecha;
        return this;
    }

    public ReservaBuilder ConFechaSalida(DateTime fecha)
    {
        reserva.FechaSalida = fecha;
        return this;
    }

    public ReservaBuilder ConRecordatorio(bool recordatorio)
    {
        reserva.Recordatorio = recordatorio;
        return this;
    }

    // GUARDIAN

    public Reserva Build()
    {
        // VALIDACIÓN 1
        if (string.IsNullOrWhiteSpace(reserva.Cliente))
        {
            throw new Exception("El cliente es obligatorio.");
        }

        // VALIDACIÓN 2
        if (reserva.FechaSalida <= reserva.FechaEntrada)
        {
            throw new Exception(
                "La fecha de salida debe ser posterior a la fecha de entrada.");
        }

        return reserva;
    }
}


public static class Demo
{
    public static void Correr()
    {
        Console.WriteLine("       PRÁCTICA 3 - BUILDER");

        Console.WriteLine();

        var reserva = new ReservaBuilder()
            .ConCliente("GONZALO")
            .ConHabitacion("Habitación Doble")
            .ConFechaEntrada(new DateTime(2026, 9, 15))
            .ConFechaSalida(new DateTime(2026, 9, 18))
            .ConRecordatorio(true)
            .Build();

        reserva.Mostrar();

        Console.WriteLine();
        Console.WriteLine("Reserva construida correctamente.");
    }
}
