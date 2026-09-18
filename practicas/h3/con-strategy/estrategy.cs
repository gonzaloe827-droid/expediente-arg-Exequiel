
namespace H3.Strategy;

// CONTRATO DE LA ESTRATEGIA

public interface IEstrategiaPrecio
{
    decimal CalcularPrecio();
}


public class PrecioPrivado : IEstrategiaPrecio
{
    public decimal CalcularPrecio()
    {
        return 200;
    }
}


public class PrecioCompartido : IEstrategiaPrecio
{
    public decimal CalcularPrecio()
    {
        return 100;
    }
}


public class PrecioTemporadaPrivado : IEstrategiaPrecio
{
    public decimal CalcularPrecio()
    {
        return 200 * 1.30m;
    }
}


public class PrecioTemporadaCompartido : IEstrategiaPrecio
{
    public decimal CalcularPrecio()
    {
        return 100 * 1.30m;
    }
}


public class Habitacion
{
    private IEstrategiaPrecio estrategia;

    public Habitacion(IEstrategiaPrecio estrategia)
    {
        this.estrategia = estrategia;
    }

    public decimal calcularPrecio()
    {
        return estrategia.CalcularPrecio();
    }
}


public static class Demo
{
    public static void Correr()
    {
        Console.WriteLine("        PRÁCTICA 2 - STRATEGY");
        Console.WriteLine();

        var habitacionPrivada =
            new Habitacion(new PrecioPrivado());

        var habitacionCompartida =
            new Habitacion(new PrecioCompartido());

        var habitacionTemporadaPrivado =
            new Habitacion(new PrecioTemporadaPrivado());

        var habitacionTemporadaCompartido =
            new Habitacion(new PrecioTemporadaCompartido());

        Console.WriteLine(
            $"Habitación privada: {habitacionPrivada.calcularPrecio():0.00} Bs"
        );

        Console.WriteLine(
            $"Habitación compartida: {habitacionCompartida.calcularPrecio():0.00} Bs"
        );

        Console.WriteLine(
            $"Habitación privada en temporada: {habitacionTemporadaPrivado.calcularPrecio():0.00} Bs"
        );

        Console.WriteLine(
            $"Habitación compartida en temporada: {habitacionTemporadaCompartido.calcularPrecio():0.00} Bs"
        );
    }
}
