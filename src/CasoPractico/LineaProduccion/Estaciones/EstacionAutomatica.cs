using ComponentesLineaProduccion;

namespace Estaciones
{
    public class EstacionAutomatica : Estacion
    {
        public EstacionAutomatica(int tiempoCiclo, int tiempoMantenimiento): base(tiempoMantenimiento)
        {
            TiempoCiclo = tiempoCiclo;
        }

        public override void RealizarOperacion(Palet palet)
        {
            base.RealizarOperacion(palet);
            Console.WriteLine($"Estación automática realizando operación en {TiempoCiclo} segundos.");
            System.Threading.Thread.Sleep(2000);
            OperacionTerminada();
        }

        public override void RealizarMantenimiento()
        {
            Console.WriteLine($"Realizando mantenimiento en estación automática en {TiempoMantenimiento} segundos.");
            System.Threading.Thread.Sleep(2500);
        }
    }
}