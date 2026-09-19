
namespace H3.Strategy;

// CONTRATO DE LA ESTRATEGIA

public interface ICalculoTarifa
{
    decimal Calcular(bool privada);
}

public class TarifaHabitacionSimple : ICalculoTarifa
{
    public decimal Calcular(bool privada)
    {
        if (privada)
            return 300;

        return 100;
    }
}

public class TarifaHabitacionDoble : ICalculoTarifa
{
    public decimal Calcular(bool privada)
    {
        if (privada)
            return 450;

        return 160;
    }
}

public class TarifaHabitacionMatrimonial : ICalculoTarifa
{
    public decimal Calcular(bool privada)
    {
        if (privada)
            return 450;

        return 160;
    }
}


public class TarifaHabitacionTriple : ICalculoTarifa
{
    public decimal Calcular(bool privada)
    {
        if (privada)
            return 600;

        return 240;
    }
}

public class TarifaHabitacionCuadruple : ICalculoTarifa
{
    public decimal Calcular(bool privada)
    {
        if (privada)
            return 800;

        return 320;
    }
}

public class GestionTarifas
{
    private ICalculoTarifa estrategia;

    public GestionTarifas(ICalculoTarifa estrategia)
    {
        this.estrategia = estrategia;
    }

    public decimal CalcularTarifa(bool privada)
    {
        return estrategia.Calcular(privada);
    }
}

public static class Demo
{
    public static void Correr()
    {
        Console.WriteLine("         STRATEGY");
        Console.WriteLine();

        var habitacionSimple =
            new GestionTarifas(
                new TarifaHabitacionSimple());

        var habitacionDoble =
            new GestionTarifas(
                new TarifaHabitacionDoble());

        var habitacionMatrimonial =
            new GestionTarifas(
                new TarifaHabitacionMatrimonial());

        var habitacionTriple =
            new GestionTarifas(
                new TarifaHabitacionTriple());

        var habitacionCuadruple =
            new GestionTarifas(
                new TarifaHabitacionCuadruple());

        Console.WriteLine(
            $"Habitación simple privada: {habitacionSimple.CalcularTarifa(true):0.00} Bs");

        Console.WriteLine(
            $"Habitación simple compartida: {habitacionSimple.CalcularTarifa(false):0.00} Bs");

        Console.WriteLine(
            $"Habitación doble privada: {habitacionDoble.CalcularTarifa(true):0.00} Bs");

        Console.WriteLine(
            $"Habitación doble compartida: {habitacionDoble.CalcularTarifa(false):0.00} Bs");

        Console.WriteLine(
            $"Habitación matrimonial privada: {habitacionMatrimonial.CalcularTarifa(true):0.00} Bs");

        Console.WriteLine(
            $"Habitación matrimonial compartida: {habitacionMatrimonial.CalcularTarifa(false):0.00} Bs");

        Console.WriteLine(
            $"Habitación triple privada: {habitacionTriple.CalcularTarifa(true):0.00} Bs");

        Console.WriteLine(
            $"Habitación triple compartida: {habitacionTriple.CalcularTarifa(false):0.00} Bs");

        Console.WriteLine(
            $"Habitación cuádruple privada: {habitacionCuadruple.CalcularTarifa(true):0.00} Bs");

        Console.WriteLine(
            $"Habitación cuádruple compartida: {habitacionCuadruple.CalcularTarifa(false):0.00} Bs");
    }
}
