using Sensores;
using Materiales;

namespace Maquinaria
{
    // Clase derivada de Maquina para representar una prensa
    public class Prensa : Maquina
    {
        public SensorPresion SensorPres { get; set; } // objeto de SensorPresion
        public SensorVelocidad SensorVel { get; set; } // objeto de SensorVelocidad
        public double MinPresion { get; set; } // presión mínima de operación
        public double MaxPresion { get; set; } // presión máxima de operación
        public double MinVel { get; set; } // velocidad mínima de operación
        public double MaxVel { get; set; } // velocidad máxima de operación

        // Constructor
        public Prensa(string id, SensorPresion sensorPres, SensorVelocidad sensorVel) : base(id)
        {
            SensorPres = sensorPres;
            SensorVel = sensorVel;
        }

        // Metodo para simular la operación
        public override void RealizarOperacion(Tocho tocho, Perfil perfil)
        {
            Encender();
            System.Threading.Thread.Sleep(1000);
            SensorPres.Encender();
            System.Threading.Thread.Sleep(1000);
            SensorVel.Encender();
            System.Threading.Thread.Sleep(1000);

            SensorPres.LeerValor(MinPresion, MaxPresion);
            System.Threading.Thread.Sleep(1000);
            SensorVel.LeerValor(MinVel, MaxVel);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine($"Extruyendo tocho {tocho.Id} con presión {SensorPres.Valor} {SensorPres.Unidad} y velocidad {SensorVel.Valor} {SensorVel.Unidad}");
            Console.WriteLine($"Forma del perfil {perfil.Id}: {perfil.Forma}");
            
            SensorPres.Apagar();
            System.Threading.Thread.Sleep(1000);
            SensorVel.Apagar();
            System.Threading.Thread.Sleep(1000);
            Apagar();
        }
    }
}
