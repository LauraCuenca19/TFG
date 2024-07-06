namespace Actuadores
{
    // Clase derivada de Actuador para representar una resistencia calefactora
    public class ResistenciaCalefactora : Actuador
    {
        // Constructror
        public ResistenciaCalefactora(string id) : base(id){}

        // Método para simular la acción del actuador
        public override void RealizarAccion()
        {
            if (Encendido) Console.WriteLine($"Resistencia {Id} calentando.");
        }
    }
}

