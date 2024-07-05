using Materiales;

namespace Actuadores
{
    public class ResistenciaCalefactora : Actuador
    {

        public ResistenciaCalefactora(string id) : base(id)
        {

        }

        public override void RealizarAccion(Tocho tocho)
        {
            if (Encendido)
            {
                Console.WriteLine($"Resistencia {Id} activa.");
            }
        }
    }
}

