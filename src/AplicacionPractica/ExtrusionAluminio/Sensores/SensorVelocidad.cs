namespace Sensores
{
    // Clase derivada de Sensor para representar un sensor de velocidad
    public class SensorVelocidad : Sensor
    {
        // Constructor
        public SensorVelocidad(string id) : base(id, "m/s") { }

        // Método para simular la lectura del sensor
        public override void LeerValor(double min, double max)
        {
            if (Encendido)
            {
                Valor = Math.Round(min + new Random().NextDouble() * (max-min), 2);
                Console.WriteLine($"Sensor de Velocidad {Id}: {Valor} {Unidad}");
            }
            else
            {
                Console.WriteLine($"Sensor de Velocidad {Id} está apagado.");
            }
        }
    }
}
