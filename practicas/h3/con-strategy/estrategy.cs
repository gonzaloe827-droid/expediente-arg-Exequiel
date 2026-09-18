
namespace H3.Strategy;

// CONTRATO DE LA ESTRATEGIA

public interface IMetodoPago
{
    void Pagar(decimal monto);
}


public class PagoEfectivo : IMetodoPago
{
    public void Pagar(decimal monto)
    {
        Console.WriteLine($"Pago de reserva realizado en efectivo: {monto:0.00} Bs");
    }
}


public class PagoTarjeta : IMetodoPago
{
    public void Pagar(decimal monto)
    {
        Console.WriteLine($"Pago de reserva realizado con tarjeta: {monto:0.00} Bs");
    }
}


public class PagoQR : IMetodoPago
{
    public void Pagar(decimal monto)
    {
        Console.WriteLine($"Pago de reserva realizado con QR: {monto:0.00} Bs");
    }
}


public class GestionPagos
{
    private IMetodoPago metodoPago;

    public GestionPagos(IMetodoPago metodoPago)
    {
        this.metodoPago = metodoPago;
    }

    public void RegistrarPago(decimal monto)
    {
        metodoPago.Pagar(monto);
    }
}


public static class Demo
{
    public static void Correr()
    {
        Console.WriteLine("        STRATEGY");
        Console.WriteLine();

        var pagoEfectivo =
            new GestionPagos(new PagoEfectivo());

        var pagoTarjeta =
            new GestionPagos(new PagoTarjeta());

        var pagoQR =
            new GestionPagos(new PagoQR());

        pagoEfectivo.RegistrarPago(150);

        pagoTarjeta.RegistrarPago(200);

        pagoQR.RegistrarPago(180);
    }
}
