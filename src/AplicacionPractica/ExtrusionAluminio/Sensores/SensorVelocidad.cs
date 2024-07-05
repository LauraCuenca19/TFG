namespace Sensores
{
    // Sensor de Velocidad
    public class SensorVelocidad : Sensor
    {
        public SensorVelocidad(string id) : base(id, "m/s") { }

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
