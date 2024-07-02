using System;

namespace LineaProduccion
{
    public abstract class Estacion
    {
        public int TiempoMantenimiento { get; set; }
        public int TiempoCiclo { get; set; }

        public Estacion(int tiempoMantenimiento)
        {
            TiempoMantenimiento = tiempoMantenimiento;
            TiempoCiclo = 0;
        }

        public abstract void RealizarOperacion();
        public abstract void RealizarMantenimiento();
    }
}