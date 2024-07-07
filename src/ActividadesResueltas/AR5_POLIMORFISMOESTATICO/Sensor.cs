namespace ActividadesResueltas.AR5_POLIMORFISMOESTATICO
{
    public class Sensor : DispositivoElectronico
    {   
        // Atributos
        private bool calibrado; // estado de calibración
        public readonly string unidadMedida; // unidades de medida
        private DateTime instanteMedida; // día y la hora

        // Propiedad (solo lectura) para el estado de calibración
        public bool Calibrado 
        { 
            get { return calibrado; }
        }

        // Propiedad para almacenar la medida
        public double Medida { get; set; }
    
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
        public void ObtenerValor()
        {
            Random rand = new Random();
            Medida = Math.Round(rand.NextDouble() * 100, 2);
        }

        // Método sobrecargado Medir
        // Método para realizar medición continua durante un tiempo
        public void Medir(int duracion)
        {
            if (!Estado)
            {
                Console.WriteLine("No se pueden tomar medidas porque el sensor está apagado.");
                return;
            }
            else if (!Calibrado)
            {
                Console.WriteLine("No se pueden tomar las medidas porque el sensor no está calibrado.");
                return;
            }
            Console.WriteLine($"Tomando medidas durante {duracion} segundos:");
            for (int i = 0; i < duracion; i++)
            {
                ObtenerValor();
                instanteMedida = DateTime.Now;
                Console.WriteLine($"{instanteMedida} - Medida {i + 1}: {Medida}{unidadMedida}");
                System.Threading.Thread.Sleep(1000); // Simula una espera de 1s
            }
        }

        // Método para tomar x medidas, una cada cierto tiempo
        public void Medir(int numMedidas, int frecuencia)
        {
            if (!Estado)
            {
                Console.WriteLine("No se pueden tomar medidas porque el sensor está apagado.");
                return;
            }
            else if (!Calibrado)
            {
                Console.WriteLine("No se pueden tomar las medidas porque el sensor no está calibrado.");
                return;
            }
            Console.WriteLine($"Tomando {numMedidas} medidas, una cada {frecuencia} segundos:");
            for (int i = 0; i < numMedidas; i++)
            {
                ObtenerValor();
                instanteMedida = DateTime.Now;
                Console.WriteLine($"{instanteMedida} - Medida {i + 1}: {Medida}{unidadMedida}");
                System.Threading.Thread.Sleep(frecuencia * 1000);
            }
        }

        // Método para realizar medición puntual
        public void Medir()
        {
            if (!Estado)
            {
                Console.WriteLine("No se puede tomar la medida porque el sensor está apagado.");
                return;
            }
            else if (!Calibrado)
            {
                Console.WriteLine("No se puede tomar la medida porque el sensor no está calibrado.");
                return;
            }
            ObtenerValor();
            instanteMedida = DateTime.Now;
            Console.WriteLine($"{instanteMedida} - Medida puntual del sensor: {Medida}{unidadMedida}");
        }
    }
}