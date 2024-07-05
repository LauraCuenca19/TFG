namespace Sensores
{
    // Clase abstracta Sensor
    public class SensorTemperatura : Sensor
    {
        public SensorTemperatura(string id) : base(id, "°C") { }

        public override void LeerValor(double min, double max)
        {
            if (Encendido)
            {
                Valor = Math.Round(min + new Random().NextDouble() * (max-min), 2);
                Console.WriteLine($"Sensor de Temperatura {Id}: {Valor} {Unidad}");
            }
            else
            {
                Console.WriteLine($"Sensor de Temperatura {Id} está apagado.");
            }
        }
    }
}   
