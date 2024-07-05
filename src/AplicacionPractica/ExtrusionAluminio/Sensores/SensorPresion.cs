namespace Sensores
{
    // Sensor de Presión
    public class SensorPresion : Sensor
    {
        public SensorPresion(string id) : base(id, "atm") { }

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