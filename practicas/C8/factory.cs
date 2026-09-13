
namespace Practicas.C8;

// CONTRATO DEL AVISO

public interface IAviso
{
    void Enviar(string mensaje);
}

// WHATSAPP

public class AvisoWhatsApp : IAviso
{
    public void Enviar(string mensaje)
    {
        Console.WriteLine($"[WHATSAPP] Mensaje enviado: {mensaje}");
    }
}


// CORREO

public class AvisoCorreo : IAviso
{
    public void Enviar(string mensaje)
    {
        Console.WriteLine($"[CORREO] Correo enviado: {mensaje}");
    }
}


// SMS

public class AvisoSms : IAviso
{
    public void Enviar(string mensaje)
    {
        Console.WriteLine($"[SMS] Mensaje enviado: {mensaje}");
    }
}


// FÁBRICA

public abstract class FabricaAviso
{
    public abstract IAviso CrearAviso();
}

// FÁBRICA WHATSAPP

public class FabricaWhatsApp : FabricaAviso
{
    public override IAviso CrearAviso()
    {
        return new AvisoWhatsApp();
    }
}

// FÁBRICA CORREO

public class FabricaCorreo : FabricaAviso
{
    public override IAviso CrearAviso()
    {
        return new AvisoCorreo();
    }
}

// FÁBRICA SMS

public class FabricaSms : FabricaAviso
{
    public override IAviso CrearAviso()
    {
        return new AvisoSms();
    }
}

// DEMOSTRACIÓN

public static class DemoFactory
{
    public static void Correr()
    {
        Console.WriteLine("     PRÁCTICA 2 - FACTORY ");

        Console.WriteLine();

        FabricaAviso fabricaWhatsApp = new FabricaWhatsApp();
        IAviso avisoWhatsApp = fabricaWhatsApp.CrearAviso();
        avisoWhatsApp.Enviar("Su reserva fue confirmada.");

        FabricaAviso fabricaCorreo = new FabricaCorreo();
        IAviso avisoCorreo = fabricaCorreo.CrearAviso();
        avisoCorreo.Enviar("Su pago fue registrado.");

        FabricaAviso fabricaSms = new FabricaSms();
        IAviso avisoSms = fabricaSms.CrearAviso();
        avisoSms.Enviar("Su habitación está disponible.");

        Console.WriteLine();

        Console.WriteLine("Si llega un nuevo canal, se agrega una nueva fábrica.");
        Console.WriteLine("No es necesario modificar el código que usa los avisos.");
    }
}
