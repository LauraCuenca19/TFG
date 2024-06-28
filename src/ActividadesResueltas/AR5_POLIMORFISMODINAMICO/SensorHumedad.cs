namespace ActividadesResueltas.AR5_POLIMORFISMODINAMICO
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

        public override void ObtenerValor()
        {
            Console.WriteLine("Llamada al método de la clase SensorHumedad:");
            Random rand = new Random();
            // Genera un valor aleatorio entre 45 y 85
            Medida = Math.Round(45 + rand.NextDouble() * 40, 2);
            Humedad = Medida;
        }

        // Método Calibrar sobrescrito
        public override void Calibrar()
        {
            base.Calibrar(); // Llamada al método de la clase base
            if (Calibrado)
            {
                Console.WriteLine("Calibrando sensor de humedad...");
                // Lógica de calibración específica sensor de humedad
                double[] lecturas = new double[3];
                double suma = 0.0;

                // Simula la lectura de 3 valores de humedad
                for (int i = 0; i < 3; i++)
                {
                    ObtenerValor();
                    lecturas[i] = Humedad;
                    Console.WriteLine($"Lectura {i + 1}: {lecturas[i]:F2}{unidadMedida}");
                    suma += lecturas[i];
                    System.Threading.Thread.Sleep(3000); // Espera de 3 segundos entre lecturas
                }

                double promedio = suma / lecturas.Length;
                Console.WriteLine($"Promedio de lecturas: {promedio:F2}{unidadMedida}");

                Random rand = new Random(); 
                double valorReferencia = Math.Round(45 + rand.NextDouble() * 40, 2); // Simulamos tener un valor de referencia
                double factorCalibracion = valorReferencia / promedio; // Calculamos el factor a partir del valor de referencia
                Console.WriteLine($"Factor de calibración: {factorCalibracion}");

                // Simula el ajuste del sensor aplicando el factor de calibración
                humedad = promedio * factorCalibracion;
                Console.WriteLine($"Sensor calibrado. Nueva humedad ajustada: {humedad}{unidadMedida}");

                Console.WriteLine("Proceso de calibración terminado.");
            }
        }

        // Método ToString sobrescrito
        public override string ToString()
        {
            return base.ToString() + $", Humedad actual: {humedad}{unidadMedida}";
        }
    }
}