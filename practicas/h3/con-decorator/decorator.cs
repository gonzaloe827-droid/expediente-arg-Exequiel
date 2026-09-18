

namespace H3.Decorator;

// CONTRATO

public interface IReserva
{
    void Mostrar(string cliente);
}


public class ReservaBase : IReserva
{
    public void Mostrar(string cliente)
    {
        Console.WriteLine($"[RESERVA] Reserva registrada para {cliente}");
    }
}

// DECORADOR

public abstract class CapaDeReserva : IReserva
{
    protected readonly IReserva Interno;

    protected CapaDeReserva(IReserva interno)
    {
        Interno = interno;
    }

    public abstract void Mostrar(string cliente);
}

//capaa1
public class ConComprobante : CapaDeReserva
{
    public ConComprobante(IReserva interno) : base(interno) { }

    public override void Mostrar(string cliente)
    {
        Interno.Mostrar(cliente);
        Console.WriteLine("    se genera el comprobante de la reserva");
    }
}

// capa 2 

public class ConNotificacion : CapaDeReserva
{
    public ConNotificacion(IReserva interno) : base(interno) { }

    public override void Mostrar(string cliente)
    {
        Interno.Mostrar(cliente);
        Console.WriteLine("    se envía una notificación al cliente");
    }
}

public static class Demo
{
    public static void Correr()
    {

        IReserva completa =
            new ConNotificacion(
                new ConComprobante(
                    new ReservaBase()));

        completa.Mostrar("CRISTIAN");

        Console.WriteLine();

        IReserva sencilla =
            new ConNotificacion(
                new ReservaBase());

        sencilla.Mostrar("ARMANDO");

    }
}
