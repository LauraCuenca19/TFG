namespace Sensores
{
    // Clase derivada de Sensor para representar un sensor de temperatura
    public class SensorTemperatura : Sensor
    {
        // Constructor
        public SensorTemperatura(string id) : base(id, "°C") { }

        // Método para simular la lectura del sensor
        public override void LeerValor(double min, double max)
        {
            // Si el sensor está encendido
            if (Encendido)
            {
                // Generar valor aleatorio entre min y max
                Valor = Math.Round(min + new Random().NextDouble() * (max-min), 2);
                Console.WriteLine($"Sensor de Temperatura {Id}: {Valor} {Unidad}");
            }
            // Si el sensor está apagado
            else
            {
                Console.WriteLine($"Sensor de Temperatura {Id} está apagado.");
            }
        }
    }
}   
