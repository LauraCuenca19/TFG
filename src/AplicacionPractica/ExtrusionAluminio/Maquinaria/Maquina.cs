using Materiales;

namespace Maquinaria
{
    // Clase base Maquina
    public abstract class Maquina
    {
        public string Id { get; set; }
        public string Estado { get; protected set; }

        public Maquina(string id)
        {
            Id = id;
            Estado = "Apagado";
        }

        public void Encender()
        {
            Estado = "Encendido";
            Console.WriteLine($"Máquina {Id} encendida.");
        }

        public void Apagar()
        {
            Estado = "Apagado";
            Console.WriteLine($"Máquina {Id} apagada.");
        }
        public abstract void RealizarOperacion(Tocho tocho, Perfil perfil);
    }
}