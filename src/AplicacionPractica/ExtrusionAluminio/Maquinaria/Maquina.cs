using Materiales;

namespace Maquinaria
{
    // Clase abstracta para representar a las máquinas del proceso 
    public abstract class Maquina
    {
        public string Id { get; set; } // id de la máquina
        public bool Estado { get; protected set; } // estado de la máquina

        // Constructor
        public Maquina(string id)
        {
            Id = id;
            Estado = false;
        }

        // Método para encender la máquina
        public void Encender()
        {
            Estado = true;
            Console.WriteLine($"Máquina {Id} encendida.");
        }

        // Método para apagar la máquina
        public void Apagar()
        {
            Estado = false;
            Console.WriteLine($"Máquina {Id} apagada.");
        }

        // Metodo abstracto para simular la operación
        public abstract void RealizarOperacion(Tocho tocho, Perfil perfil);
    }
}