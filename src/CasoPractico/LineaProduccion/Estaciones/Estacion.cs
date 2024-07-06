using SensoresActuadores;
using ComponentesLineaProduccion;

namespace Estaciones
{
    public abstract class Estacion
    {
        public SensorPresencia Sensor { get; private set; }
        public ActuadorTopes Topes { get; private set; }
        public int TiempoMantenimiento { get; set; }
        public int TiempoCiclo { get; set; }

        public Estacion(int tiempoMantenimiento)
        {
            TiempoMantenimiento = tiempoMantenimiento;
            TiempoCiclo = 0;
            Sensor = new SensorPresencia();
            Topes = new ActuadorTopes();
        }

        protected void DetectarPalet()
        {
            Sensor.Detectar();
            Topes.SubirTopes();
        }

        protected void OperacionTerminada()
        {
            Topes.BajarTopes();
            Sensor.Resetear();
        }

        public virtual void RealizarOperacion(Palet palet)
        {
            Console.WriteLine("Palet " + palet.Id);
            DetectarPalet();
        }

        public virtual void RealizarOperacion(Palet palet, int tiempoFijo)
        {
            Console.WriteLine("Palet " + palet.Id);
            DetectarPalet();
        }

        public abstract void RealizarMantenimiento();
    }
}