namespace Actuadores
{
    // Clase derivada de Actuador para representar un ventilador
    public class Ventilador : Actuador
    {
        // Constructror
        public Ventilador(string id) : base(id){}

        // Método para simular la acción del actuador
        public override void RealizarAccion()
        {
            if (Encendido) Console.WriteLine($"Ventilador {Id} en funcionamiento.");
        }
    }
}

