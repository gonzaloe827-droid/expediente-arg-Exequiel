
namespace H3.Strategy;

// CONTRATO DE LA ESTRATEGIA

public interface IMetodoPago
{
    void Pagar(decimal monto);
}

// ESTRATEGIA 1 - PAGO EN EFECTIVO

public class PagoEfectivo : IMetodoPago
{
    public void Pagar(decimal monto)
    {
        Console.WriteLine($"Pago de reserva realizado en efectivo: {monto:0.00} Bs");
    }
}

// ESTRATEGIA 2 - PAGO CON TARJETA

public class PagoTarjeta : IMetodoPago
{
    public void Pagar(decimal monto)
    {
        Console.WriteLine($"Pago de reserva realizado con tarjeta: {monto:0.00} Bs");
    }
}

// ESTRATEGIA 3 - PAGO CON QR

public class PagoQR : IMetodoPago
{
    public void Pagar(decimal monto)
    {
        Console.WriteLine($"Pago de reserva realizado con QR: {monto:0.00} Bs");
    }
}

// GESTIÓN DE PAGOS

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

// DEMOSTRACIÓN

public static class Demo
{
    public static void Correr()
    {
        Console.WriteLine("        PRÁCTICA 2 - STRATEGY");
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
