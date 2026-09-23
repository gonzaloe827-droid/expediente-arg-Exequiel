
// Refactor de Principio de responsabilidad única

// INTEGRADORA · VARIANTE A — Comedor Universitario "Sabor Andino"
// Esqueleto del sistema de pedidos del comedor. FUNCIONA, pero fue escrito de apuro:
// tiene 3 violaciones SOLID. Es la materia prima de tu parte 2.

namespace Integradora.Comedor;

public class GestorDePedidos {
    private readonly CalculadorPrecio calculador;
    private readonly BaseDeDatosComedor baseDeDatos;
    private readonly CorreoUniversitario correo;

    public GestorDePedidos(CalculadorPrecio calculador, BaseDeDatosComedor baseDeDatos, CorreoUniversitario correo)
    {
        this.calculador = calculador;
        this.baseDeDatos = baseDeDatos;
        this.correo = correo;
    }

    public void ProcesarPedido(string estudiante, string tipoMenu, int cantidad)
    {
        decimal precioBase = calculador.Calcular(tipoMenu);
        decimal total = precioBase * cantidad;

        baseDeDatos.GuardarPedido(estudiante, tipoMenu, cantidad, total);

        Console.WriteLine("----- VALE DE COMEDOR -----");
        Console.WriteLine($"{estudiante}: {cantidad} x menú {tipoMenu}");
        Console.WriteLine($"TOTAL: {total:0.00} Bs");

        correo.Enviar($"Pedido registrado: {cantidad} x {tipoMenu}, {estudiante}");
    }
}

public class CalculadorPrecio {
    public decimal Calcular(string tipoMenu)
    {
        switch (tipoMenu)
        {
            case "estandar":
                return 12;
            case "vegetariano":
                return 14;
            case "beca":
                return 5;
            default:
                return 12;
        }
    }
}

public class BaseDeDatosComedor {
    public void GuardarPedido(string estudiante, string menu, int cantidad, decimal total)
        => Console.WriteLine($"[BD] INSERT INTO pedidos VALUES ('{estudiante}', '{menu}', {cantidad}, {total})");
}

public class CorreoUniversitario {
    public void Enviar(string mensaje) => Console.WriteLine($"[CORREO] {mensaje}");
}

public static class Demo {
    public static void Correr()
    {
        var calculador = new CalculadorPrecio();
        var baseDeDatos = new BaseDeDatosComedor();
        var correo = new CorreoUniversitario();

        var gestor = new GestorDePedidos(calculador, baseDeDatos, correo);
        gestor.ProcesarPedido("Noelia", "vegetariano", 2);
    }
}
