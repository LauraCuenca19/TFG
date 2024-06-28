using ActividadesResueltas.AR5_POLIMORFISMOESTATICO;

namespace Ejemplos.C5_POLIMORFISMO
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

        // Constructor que inicializa el sensor con tipo "Temperatura"
        public SensorTemperatura(string dispositivoID, string fabricante, string unidadMedida) : base(dispositivoID, fabricante, unidadMedida)
        {
            // Inicializa la temperatura a 0.0
            temperatura = 0.0;
        }

        public void ObtenerValor()
        {
            Console.WriteLine("Llamada al método de la clase SensorTemperatura:");
            Random rand = new Random();
            // Genera un valor aleatorio entre 10 y 30
            Medida = Math.Round(10 + rand.NextDouble() * 20, 2);
            Temperatura = Medida;
        }
    }
}