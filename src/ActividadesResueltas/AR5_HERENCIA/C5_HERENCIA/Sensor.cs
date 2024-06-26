namespace Ejemplos.C5_HERENCIA
{
    public class Sensor : DispositivoElectronico
    {   
        // Atributos
        private bool calibrado; // almacena el estado de calibración
        public readonly string unidadMedida; // almacena las unidades de medida

        // Propiedad (solo lectura) para el estado de calibración
        public bool Calibrado 
        { 
            get { return calibrado; }
        }

        // Constructor
        public Sensor(string dispositivoID, string fabricante, string unidadMedida) : base(dispositivoID, fabricante)
        {
            this.unidadMedida = unidadMedida;
            calibrado = false;
        }

        // Método para calibrar el sensor
        public void Calibrar()
        {
            if (Estado) calibrado = true;  // Uso de propiedad heredada Estado
            else calibrado = false;
            Console.WriteLine($"Sensor calibrado: {calibrado}");
        }

        // Método público para obtener un valor simulado de medida
        public double ObtenerValor()
        {
            Random rand = new Random(); // Crea una instancia de la clase Random para generar valores aleatorios
            // Genera un valor aleatorio entre 0 y 100
            double valor = Math.Round(rand.NextDouble() * 100, 2);  // Redondea el valor a 2 decimales
            Console.WriteLine($"Valor medido: {valor}{unidadMedida}"); // Mensaje de confirmación
            return valor;
        }
    }
}