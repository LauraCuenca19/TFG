namespace Actuadores
{
    public abstract class Actuador
    {
        public string Id { get; set; } // id del actuador
        public bool Encendido { get; private set; } // estado del actuador

        // Constructor
        public Actuador(string id)
        {
            Id = id;
            Encendido = false;
        }

        // Método para encender el actuador
        public void Encender()
        {
            Encendido = true;
            Console.WriteLine($"Actuador {Id} encendido.");
        }

        // Método para apagar el actuador
        public void Apagar()
        {
            Encendido = false;
            Console.WriteLine($"Actuador {Id} apagado.");
        }

        // Método abstracto para simular la acción del actuador
        public abstract void RealizarAccion();
    }
}
