using Materiales;

namespace Actuadores
{
    public class Ventilador : Actuador
    {

        public Ventilador(string id) : base(id)
        {

        }

        public override void RealizarAccion(Tocho tocho)
        {
            if (Encendido)
            {
                Console.WriteLine($"Ventilador {Id} activo.");
            }
        }
    }
}

