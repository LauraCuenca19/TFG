namespace Sensores
{
    // Clase derivada de Sensor para representar un sensor de presión
    public class SensorPresion : Sensor
    {
        // Constructor
        public SensorPresion(string id) : base(id, "atm") { }

        // Método para simular la lectura del sensor
        public override void LeerValor(double min, double max)
        {
            if (Encendido)
            {
                Valor = Math.Round(min + new Random().NextDouble() * (max-min), 2);
                Console.WriteLine($"Sensor de Presión {Id}: {Valor} {Unidad}");
            }
            else
            {
                Console.WriteLine($"Sensor de Presión {Id} está apagado.");
            }
        }
    }
}