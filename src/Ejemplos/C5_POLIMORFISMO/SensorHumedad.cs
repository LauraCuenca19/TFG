using ActividadesResueltas.AR5_POLIMORFISMOESTATICO;

namespace Ejemplos.C5_POLIMORFISMO
{
    public class SensorHumedad : Sensor
    {
        // Atributo privado para almacenar nivel de humedad
        private double humedad; 

        // Propiedad pública para nivelHumedad con validación en el setter
        public double Humedad
        {
            get { return humedad; } // Devuelve el nivel de humedad actual
            set
            {
                // Validación para asegurar que el sensor esté activado
                if (!Estado)
                {
                    Console.WriteLine("Error: El sensor no está encendido. No se puede actualizar el nivel de humedad.");
                }
                // Validación para asegurar que el sensor esté calibrado
                else if (!Calibrado)
                {
                    Console.WriteLine("Error: El sensor no está calibrado. No se puede actualizar el nivel de humedad.");
                }
                // Validación para asegurar que el valor de humedad esté en el rango válido (0 a 100)
                else if (value < 0 || value > 100)
                {
                    Console.WriteLine("Error: Valor de humedad fuera de rango válido (0 a 100).");
                }
                else
                {
                    humedad = value; // Actualiza el nivel de humedad
                    Console.WriteLine("Nivel de humedad actualizado."); // Mensaje de confirmación
                }
            }
        }

        // Constructor: inicializa el nivel de humedad a 0.0
        public SensorHumedad(string dispositivoID, string fabricante, string unidadMedida) : base(dispositivoID, fabricante, unidadMedida)
        {
            humedad = 0.0; // El nivel de humedad inicia en 0.0
        }

        public void ObtenerValor()
        {
            Console.WriteLine("Llamada al método de la clase SensorHumedad:");
            Random rand = new Random();
            // Genera un valor aleatorio entre 45 y 85
            Medida = Math.Round(45 + rand.NextDouble() * 40, 2);
            Humedad = Medida;
        }
    }
}