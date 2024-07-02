using System;
namespace LineaProduccion
{
    public class EstacionAutomatica : Estacion
    {
        public EstacionAutomatica(int tiempoCiclo, int tiempoMantenimiento): base(tiempoMantenimiento)
        {
            TiempoCiclo = tiempoCiclo;
        }

        public override void RealizarOperacion()
        {
            Console.WriteLine($"Estación automática realizando operación en {TiempoCiclo} segundos.");
            System.Threading.Thread.Sleep(2000);
        }

        public override void RealizarMantenimiento()
        {
            Console.WriteLine($"Realizando mantenimiento en estación automática en {TiempoMantenimiento} segundos.");
            System.Threading.Thread.Sleep(2500);
        }
    }
}