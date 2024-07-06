using System;

namespace Estaciones
{
    public class EstacionManual : Estacion
    {
        public int TiempoCicloMinimo { get; set; }
        public int TiempoCicloMaximo { get; set; }

        public EstacionManual(int tiempoCicloMinimo, int tiempoCicloMaximo, int tiempoMantenimiento) : base(tiempoMantenimiento)
        {
            TiempoCicloMinimo = tiempoCicloMinimo;
            TiempoCicloMaximo = tiempoCicloMaximo;
            TiempoMantenimiento = tiempoMantenimiento;
            TiempoCiclo = 0;
        }

        public override void RealizarOperacion(Palet palet)
        {
            base.RealizarOperacion(palet);
            Random random = new Random();
            // Generar un entero aleatorio entre valorMinimo (incluido) y valorMaximo (incluido)
            TiempoCiclo = random.Next(TiempoCicloMinimo, TiempoCicloMaximo+1);
            Console.WriteLine($"Estación manual realizando operación en {TiempoCiclo} segundos.");
            System.Threading.Thread.Sleep(2000);
            OperacionTerminada();
        }

        public override void RealizarOperacion(Palet palet, int tiempoFijo)
        {
            base.RealizarOperacion(palet);
            Console.WriteLine($"Estación manual realizando operación en {tiempoFijo} segundos.");
            System.Threading.Thread.Sleep(2000);
            OperacionTerminada();
        }

        public override void RealizarMantenimiento()
        {
            Console.WriteLine($"Realizando mantenimiento en estación manual en {TiempoMantenimiento} segundos.");
            System.Threading.Thread.Sleep(2500);
        }
    }
}