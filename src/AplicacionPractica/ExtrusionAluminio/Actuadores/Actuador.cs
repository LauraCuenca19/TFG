using Materiales;

namespace Actuadores
{
    public abstract class Actuador
    {
        public string Id { get; set; }
        public bool Encendido { get; private set; }

        public Actuador(string id)
        {
            Id = id;
            Encendido = false;
        }

        public void Encender()
        {
            Encendido = true;
            Console.WriteLine($"Actuador {Id} encendido.");
        }

        public void Apagar()
        {
            Encendido = false;
            Console.WriteLine($"Actuador {Id} apagado.");
        }

        public abstract void RealizarAccion();
    }
}
