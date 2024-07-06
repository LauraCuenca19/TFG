using Sensores;
using Actuadores;
using Materiales;

namespace Maquinaria
{
// Clase Túnel de Enfriamiento
    public class TunelEnfriamiento : Maquina
    {
        public SensorTemperatura SensorTempEntrada { get; set; }
        public SensorTemperatura SensorTempSalida { get; set; }
        public Ventilador Ventilador { get; set; }
        
        public double MinTemp { get; set; }
        public double MaxTemp { get; set; }

        public TunelEnfriamiento(string id, SensorTemperatura sensorTempEntrada, SensorTemperatura sensorTempSalida, Ventilador ventilador) : base(id)
        {
            SensorTempEntrada = sensorTempEntrada;
            SensorTempSalida = sensorTempSalida;
            Ventilador = ventilador;
        }

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

            SensorTempEntrada.LeerValor(MinTemp, MaxTemp);
            System.Threading.Thread.Sleep(1000);
            Ventilador.RealizarAccion();
            System.Threading.Thread.Sleep(1000);
            SensorTempSalida.LeerValor(25,35);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine($"Enfriando tocho {tocho.Id} desde {SensorTempEntrada.Valor} {SensorTempEntrada.Unidad} hasta {SensorTempSalida.Valor} {SensorTempSalida.Unidad}");

            // Simulación de operación
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
