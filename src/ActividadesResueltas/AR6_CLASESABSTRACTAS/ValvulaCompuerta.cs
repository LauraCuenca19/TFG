namespace ActividadesResueltas.AR6_CLASESABSTRACTAS
{
    public class ValvulaCompuerta : Actuador
    {
        // Propiedad para indicar si la válvula está abierta
        public bool Abierta { get; private set; }

        // Constructor
        public ValvulaCompuerta(string dispositivoID, string fabricante) : base(dispositivoID, fabricante)
        {
            Abierta = false;
        }

        // Método público para activar la válvula
        public override void Activar()
        {
            Estado = true;
            Abierta = true;
            Console.WriteLine("La válvula se ha abierto.");
        }

        // Método público para desactivar la válvula
        public override void Desactivar()
        {
            Estado = false;
            Abierta = false;
            Console.WriteLine("La válvula se ha cerrado.");
        }

        // Sobrescritura del método ToString
        public override string ToString()
        {
            return base.ToString() + $", Abierta: {Abierta}";
        }
    }
}