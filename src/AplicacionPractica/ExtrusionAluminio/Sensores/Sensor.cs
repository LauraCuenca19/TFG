namespace Sensores
{
    // Clase abstracta Sensor
    public abstract class Sensor
    {
        public string Id { get; set; }
        public double Valor { get; protected set; }
        public string Unidad { get; protected set; }
        public bool Encendido { get; private set; }

        public Sensor(string id, string unidad)
        {
            Id = id;
            Unidad = unidad;
            Encendido = false;
        }

        public void Encender()
        {
            Encendido = true;
            Console.WriteLine($"Sensor {Id} encendido.");
        }

        public void Apagar()
        {
            Encendido = false;
            Console.WriteLine($"Sensor {Id} apagado.");
        }

        public abstract void LeerValor(double min, double max);
    }
}