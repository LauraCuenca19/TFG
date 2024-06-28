namespace MonitorizacionControl
{
    public abstract class Sensor : DispositivoElectronico
    {   
        // Atributos
        private bool calibrado;
        public readonly string unidadMedida;
        private DateTime instanteMedida;

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

        // Método virtual para calibrar el sensor
        public virtual void Calibrar()
        {
            // Solo modifica el valor del atributo calibrado
            if (Estado) calibrado = true;
            else calibrado = false;
        }

        // Método público para obtener un valor simulado de medida
        public virtual void ObtenerValor()
        {
            Random rand = new Random();
            // Genera un valor aleatorio entre 0 y 100
            Medida = Math.Round(rand.NextDouble() * 100, 2);
        }

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
                System.Threading.Thread.Sleep(1000);
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
            Console.WriteLine($"{instanteMedida} - Medida puntual del sensor: {Medida}°C");
        }

        // Representación textual de la información del objeto
        public override string ToString()
        {
            return base.ToString() + $", Calibrado:{calibrado}, Unidad de medida: {unidadMedida}";
        }

        // Métodos abstractos para activar/desactivar el dispositivo
        public override void Activar()
        {
            Estado = true;
            Console.WriteLine("El sensor se ha activado.");
        }
        public override void Desactivar()
        {
            Estado = false;
            Console.WriteLine("El sensor se ha desactivado.");
        }
    }
}