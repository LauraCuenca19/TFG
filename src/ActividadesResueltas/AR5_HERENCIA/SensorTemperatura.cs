using Ejemplos.C5_HERENCIA;

namespace ActividadesResueltas.AR5_HERENCIA
{
    public class SensorTemperatura : Sensor
    {
        // Atributo privado para almacenar valor de temperatura
        private double temperatura;

        // Propiedad para la temperatura con validación en el setter
        public double Temperatura
        {
            get { return temperatura; }
            set
            {
                // Verifica si el sensor está encendido
                if (!Estado)
                {
                    Console.WriteLine("Error: El sensor no está encendido. No se puede actualizar la temperatura.");
                }
                else
                {
                    // Verifica si el sensor está calibrado
                    if (!Calibrado)
                    {
                        Console.WriteLine("Error: El sensor no está calibrado. No se puede actualizar la temperatura.");
                    }
                    // Verifica si el valor está dentro del rango permitido
                    else if (value < 0 || value > 100)
                    {
                        Console.WriteLine("Error: Valor de temperatura fuera de rango válido (0 a 100).");
                    }
                    else
                    {
                        // Actualiza el valor de la temperatura
                        temperatura = value;
                        Console.WriteLine("Temperatura actualizada.");
                    }
                }
            }
        }

        // Constructor
        public SensorTemperatura(string dispositivoID, string fabricante, string unidadMedida) : base(dispositivoID, fabricante, unidadMedida)
        {
            // Inicializa la temperatura a 0.0
            temperatura = 0.0;
        }

        // Método para medir y actualizar la temperatura del sensor
        public void MedirTemperatura()
        {
            Temperatura = ObtenerValor();
        }
    }
}