namespace Sensores
{
    // Clase abstracta para representar a los sensores de las máquinas del proceso 
    public abstract class Sensor
    {
        public string Id { get; set; } // id del sensor
        public double Valor { get; protected set; } // medida del sensor
        public string Unidad { get; protected set; } // unidad de medida
        public bool Encendido { get; private set; } // estado del sensor (encendido: true / apagado: false)

        // Constructor
        public Sensor(string id, string unidad)
        {
            Id = id;
            Unidad = unidad;
            Encendido = false;
        }
        
        // Método para encender el sensor
        public void Encender()
        {
            Encendido = true;
            Console.WriteLine($"Sensor {Id} encendido.");
        }

        // Método para apagar el sensor
        public void Apagar()
        {
            Encendido = false;
            Console.WriteLine($"Sensor {Id} apagado.");
        }

        // Método abstracto para simular la lectura del sensor
        public abstract void LeerValor(double min, double max);
    }
}