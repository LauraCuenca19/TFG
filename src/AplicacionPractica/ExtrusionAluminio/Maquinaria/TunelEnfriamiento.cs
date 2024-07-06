using Sensores;
using Actuadores;
using Materiales;

namespace Maquinaria
{
    // Clase derivada de Maquina para representar un túnel de enfriamiento
    public class TunelEnfriamiento : Maquina
    {
        public SensorTemperatura SensorTempEntrada { get; set; } // objeto de SensorTemperatura
        public SensorTemperatura SensorTempSalida { get; set; } // objeto de SensorTemperatura
        public Ventilador Ventilador { get; set; } // objeto de Ventilador
        public double MinTemp { get; set; } // temperatura mínima al inicio del túnel
        public double MaxTemp { get; set; } // temperatura máxima al inicio del túnel

        // Constructor
        public TunelEnfriamiento(string id, SensorTemperatura sensorTempEntrada, SensorTemperatura sensorTempSalida, Ventilador ventilador) : base(id)
        {
            SensorTempEntrada = sensorTempEntrada;
            SensorTempSalida = sensorTempSalida;
            Ventilador = ventilador;
        }

        // Metodo para simular la operación
        public override void RealizarOperacion(Tocho tocho, Perfil perfil)
        {
            Encender();
            System.Threading.Thread.Sleep(1000);
            Ventilador.Encender();
            System.Threading.Thread.Sleep(1000);
            SensorTempEntrada.Encender();
            System.Threading.Thread.Sleep(1000);
            SensorTempSalida.Encender();
            System.Threading.Thread.Sleep(1000);

            SensorTempEntrada.LeerValor(MinTemp, MaxTemp); // lectura del sensor al principio del túnel
            System.Threading.Thread.Sleep(1000);
            Ventilador.RealizarAccion();
            System.Threading.Thread.Sleep(1000);
            SensorTempSalida.LeerValor(25,35); // lectura del sensor al final del túnel
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine($"Enfriando tocho {tocho.Id} desde {SensorTempEntrada.Valor} {SensorTempEntrada.Unidad} hasta {SensorTempSalida.Valor} {SensorTempSalida.Unidad}");

            // Asignación de la temperatura medida al tocho
            tocho.Temperatura = SensorTempSalida.Valor;

            Ventilador.Apagar();
            System.Threading.Thread.Sleep(1000);
            SensorTempEntrada.Apagar();
            System.Threading.Thread.Sleep(1000);
            SensorTempSalida.Apagar();
            System.Threading.Thread.Sleep(1000);
            Apagar();
        }
    }
}
