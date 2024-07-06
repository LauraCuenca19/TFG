using Sensores;
using Actuadores;
using Materiales;

namespace Maquinaria
{
    // Clase derivada de Maquina para representar un horno
    public class Horno : Maquina
    {
        public SensorTemperatura SensorTemp { get; set; } // objeto de SensorTemperatura
        public ResistenciaCalefactora Resistencia { get; set; } // objeto de ResistenciaCalefactora
        public double MinTemp { get; set; } // temperatura mínima de operación
        public double MaxTemp { get; set; } // temperatura máxima de operación

        // Constructor
        public Horno(string id, SensorTemperatura sensorTemp, ResistenciaCalefactora resistencia) : base(id)
        {
            SensorTemp = sensorTemp;
            Resistencia = resistencia;
        }

        // Metodo para simular la operación
        public override void RealizarOperacion(Tocho tocho, Perfil perfil)
        {
            Encender(); // activar máquina
            System.Threading.Thread.Sleep(1000);
            SensorTemp.Encender(); // activar sensor de temperatura
            System.Threading.Thread.Sleep(1000);
            Resistencia.Encender(); // activar resistencia
            System.Threading.Thread.Sleep(1000);
            
            Resistencia.RealizarAccion(); // simulación de la acción de la resistencia
            System.Threading.Thread.Sleep(1000);
            SensorTemp.LeerValor(MinTemp, MaxTemp); // simulación de lectura del sensor
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine($"Calentando tocho {tocho.Id} a {SensorTemp.Valor} {SensorTemp.Unidad}");
            
            // Asignación de la temperatura medida al tocho
            tocho.Temperatura = SensorTemp.Valor;

            Resistencia.Apagar(); // apagar resistencia
            System.Threading.Thread.Sleep(1000);
            SensorTemp.Apagar(); // apagar sensor
            System.Threading.Thread.Sleep(1000);
            Apagar(); // apagar máquina
        }
    }
}
