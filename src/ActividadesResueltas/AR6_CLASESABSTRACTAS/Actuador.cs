using Ejemplos.C6_CLASESABSTRACTAS;

namespace ActividadesResueltas.AR6_CLASESABSTRACTAS
{
    public abstract class Actuador : DispositivoElectronico
    {
        // Atributo privado para el estado de emergencia
        private bool estadoEmergencia;

        // Constructor
        public Actuador(string dispositivoID, string fabricante) : base(dispositivoID, fabricante)
        {
            estadoEmergencia = false;
        }

        // Métodos abstractos
        public override abstract void Activar();
        public override abstract void Desactivar();

        public void ParadaEmergencia()
        {
            if (estadoEmergencia) Desactivar();
            Console.WriteLine("Parada de emergencia.");
        }

        // Sobrescritura del método ToString de la clase Object
        public override string ToString()
        {
            return base.ToString() + $", Estado de Emergencia: {estadoEmergencia}";
        }
    }
}
