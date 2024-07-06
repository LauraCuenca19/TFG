namespace ActividadesResueltas.AR4_CLASESYOBJETOS
{
    public class Sensor
    {
        // Atributos privados
        private bool estado; // estado del sensor: activado (true) o desactivado (false)
        private bool calibrado; // estado de calibración del sensor: calibrado (true) o no calibrado (false)
        private string tipoSensor; // el tipo de sensor
        private string sensorID; // Almacena el id de sensor
        
        // Propiedad para el tipo de sensor con validación en el set
        public string TipoSensor
        {
            get { return tipoSensor; }
            set
            {
                // Comprobación para asegurar que el tipo de sensor es válido
                if (value == "Temperatura" || value == "Humedad")
                {
                    tipoSensor = value;
                }
                else
                {
                    Console.WriteLine("Tipo de sensor no válido. Debe ser 'Temperatura' o 'Humedad'.");
                    tipoSensor = "Por determinar";
                }
            }
        }

        // Propiedad (solo lectura) para acceder al id del sensor
        public string SensorID 
        {
            get { return sensorID; }
        }

        // Propiedad (solo lectura) para el estado de calibración
        public bool Calibrado 
        { 
            get { return calibrado; }
        }

        // Constructor
        public Sensor(string tipoSensor, string sensorID)
        {
            this.sensorID = sensorID;
            TipoSensor = tipoSensor;
            calibrado = false;
            estado = false;
            Console.WriteLine($"Sensor {TipoSensor} creado."); // Mensaje de confirmación
        }

        // Método público para activar el sensor
        public void Activar()
        {
            estado = true;
            Console.WriteLine("Sensor activado."); // Mensaje de confirmación
        }

        // Método público para desactivar el sensor
        public void Desactivar()
        {
            estado = false;
            Console.WriteLine("Sensor desactivado."); // Mensaje de confirmación
        }

        // Método público para calibrar el sensor
        public void Calibrar()
        {
            if (estado) calibrado = true; 
            else calibrado = false;
            Console.WriteLine($"Sensor calibrado: {Calibrado}"); // Mensaje de confirmación
        }

        // Método público para obtener un valor simulado de medida
        public double ObtenerValor()
        {
            Random rand = new Random(); // instancia de la clase Random para generar valores aleatorios
            // Genera un valor aleatorio entre 0 y 100
            double valor = Math.Round(rand.NextDouble() * 100, 2);  // Redondea el valor a 2 decimales
            return valor;
        }
    }
}