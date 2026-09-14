
namespace Practicas.C8;

public class ConfiguracionSistema
{
    private static ConfiguracionSistema? instancia;

    private ConfiguracionSistema()
    {
    }

    public static ConfiguracionSistema Instancia
    {
        get
        {
            if (instancia == null)
            {
                instancia = new ConfiguracionSistema();
            }

            return instancia;
        }
    }

    public string NombreHostal { get; set; } = "Hostal Nuevo Amanecer ";
    public string Moneda { get; set; } = "Bs ";
}

public static class Demo
{
    public static void Correr()
    {
        var configuracion1 = ConfiguracionSistema.Instancia;
        var configuracion2 = ConfiguracionSistema.Instancia;

        configuracion1.NombreHostal = "Hostal Nuevo Amanecer ";
        configuracion1.Moneda = "Bs ";

        Console.WriteLine(" PRACTICA Sincleton ");
        Console.WriteLine();

        Console.WriteLine($"Hostal: {configuracion1.NombreHostal}");
        Console.WriteLine($"Moneda: {configuracion1.Moneda}");

        Console.WriteLine();

        if (ReferenceEquals(configuracion1, configuracion2))
        {
            Console.WriteLine("Las dos variables usan la misma configuracion.");
            Console.WriteLine("Singleton funcionando correctamente.");
        }
        else
        {
            Console.WriteLine("Son configuraciones diferentes");
        }
    }
}
