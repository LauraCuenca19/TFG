using Sensores;
using Actuadores;
using Materiales;

namespace Maquinaria
{
    // Clase Horno que hereda de Maquina
    public class Horno : Maquina
    {
        public SensorTemperatura SensorTemp { get; set; }
        public ResistenciaCalefactora Resistencia { get; set; }

        public double MinTemp { get; set; }
        public double MaxTemp { get; set; }

        public Horno(string id, SensorTemperatura sensorTemp, ResistenciaCalefactora resistencia) : base(id)
        {
            SensorTemp = sensorTemp;
            Resistencia = resistencia;
        }

        public override void RealizarOperacion(Tocho tocho, Perfil perfil)
        {
            Encender();
            System.Threading.Thread.Sleep(1000);
            Resistencia.Encender();
            System.Threading.Thread.Sleep(1000);
            SensorTemp.Encender();
            System.Threading.Thread.Sleep(1000);
            
            Resistencia.RealizarAccion();
            System.Threading.Thread.Sleep(1000);
            SensorTemp.LeerValor(MinTemp, MaxTemp);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine($"Calentando tocho {tocho.Id} a {SensorTemp.Valor} {SensorTemp.Unidad}");
            
            // Simulación de operación
            tocho.Temperatura = SensorTemp.Valor;

            Resistencia.Apagar();
            System.Threading.Thread.Sleep(1000);
            SensorTemp.Apagar();
            System.Threading.Thread.Sleep(1000);
            Apagar();
        }
    }
}
