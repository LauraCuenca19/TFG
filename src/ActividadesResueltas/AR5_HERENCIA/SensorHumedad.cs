using Ejemplos.C5_HERENCIA;

namespace ActividadesResueltas.AR5_HERENCIA
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

        // Método para medir y actualizar el nivel de humedad del sensor
        public void MedirHumedad()
        {
            double valor = ObtenerValor();
            Humedad = valor;
        }
    }
}