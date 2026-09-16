
// parcial 2 
namespace Parcial2.Gimnasio
{
    public interface IProcesadorPago
    {
        void ProcesarPago(decimal monto, string cliente);
    }

    public class PasarelaExterna
    {
        public void ChargeCard(int amountCents, string currencyIso, string customerToken)
        {
            Console.WriteLine(
                $"Cobro externo: {amountCents} centavos {currencyIso} para {customerToken}"
            );
        }
    }

    public class PagoAdapter : IProcesadorPago
    {
        private PasarelaExterna pasarela;

        public PagoAdapter(PasarelaExterna pasarela)
        {
            this.pasarela = pasarela;
        }

        public void ProcesarPago(decimal monto, string cliente)
        {
            int montoCentavos = (int)(monto * 100);
            string token = "TOKEN-" + cliente.ToUpper();

            pasarela.ChargeCard(
                montoCentavos,
                "BOB",
                token
            );
        }
    }

    public class GestorDeMembresias
    {
        private IProcesadorPago procesador;

        public GestorDeMembresias(IProcesadorPago procesador)
        {
            this.procesador = procesador;
        }

        public void CobrarMembresia(string socio, decimal monto)
        {
            Console.WriteLine(
                $"Cobrando membresía de {socio}: {monto:0.00} Bs"
            );

            procesador.ProcesarPago(monto, socio);
        }
    }

    public static class Demo
    {
        public static void Correr()
        {

            var pasarela = new PasarelaExterna();

            var adapter = new PagoAdapter(pasarela);

            var gestor = new GestorDeMembresias(adapter);

            gestor.CobrarMembresia("Marco", 150);
        }
    }

  // Solucion: Gonzalo Exequiel Bautista


  
}
