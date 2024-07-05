using Sensores;
using Actuadores;
using Materiales;

namespace Maquinaria
{
    // Clase Prensa que hereda de Maquina
    public class Prensa : Maquina
    {
        public SensorPresion SensorPres { get; set; }
        public SensorVelocidad SensorVel { get; set; }
        public double MinPresion { get; set; }
        public double MaxPresion { get; set; }
        public double MinVel { get; set; }
        public double MaxVel { get; set; }

        public Prensa(string id, SensorPresion sensorPres, SensorVelocidad sensorVel) : base(id)
        {
            SensorPres = sensorPres;
            SensorVel = sensorVel;
        }
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
            
            SensorPres.Apagar();
            System.Threading.Thread.Sleep(1000);
            SensorVel.Apagar();
            System.Threading.Thread.Sleep(1000);
            Apagar();
        }
    }
}
