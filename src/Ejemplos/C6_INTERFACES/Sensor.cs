public abstract class Sensor : DispositivoElectronico
{
    // Atributo privado
    private string tipoSensor; // Almacena el tipo de sensor
    public readonly string unidades; // Almacena unidad de medida
    private DateTime instanteMedida; // Almacena el día y la hora

    // Propiedad para almacenar la medida
    public double Medida { get; set; }
    
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
    
    // Propiedad para el estado de calibración con set privado
    public bool Calibrado { get; private set; }

    // Constructor
    public Sensor(string tipo, string fabricante, string unidadMedida) : base("Sensor", fabricante)
    {
        TipoSensor = tipo;
        Calibrado = false;
        unidades = unidadMedida;
    }

    // Método para calibrar el sensor
    public virtual void Calibrar()
    {
        if (Estado) Calibrado = true;  // Uso de propiedad heredada Estado
        else Calibrado = false;
    }

    // Método público para obtener un valor simulado de medida
    public virtual double ObtenerValor()
    {
        Console.WriteLine("Llamada al método de la clase Sensor (clase base):");
        Random rand = new Random(); // Crea una instancia de la clase Random para generar valores aleatorios
        // Genera un valor aleatorio entre 0 y 100
        double valor = Math.Round(rand.NextDouble() * 100, 2);  // Redondea el valor a 2 decimales
        return valor;
    }

    // Método sobrecargado Medir
    // Método para realizar medición continua durante un tiempo
    public void Medir(int duracion)
    {
        if (!Estado)
        {
            Console.WriteLine("No se pueden tomar medidas continuas porque el sensor está apagado.");
            return;
        }
        else if (!Calibrado)
        {
            Console.WriteLine("No se pueden tomar medidas continuas porque el sensor no está calibrado.");
            return;
        }
        Console.WriteLine($"Tomando medidas continuas del sensor durante {duracion} segundos:");
        for (int i = 0; i < duracion; i++)
        {
            Medida = ObtenerValor();
            instanteMedida = DateTime.Now;
            Console.WriteLine($"{instanteMedida} - Medida {i + 1}: {Medida}{unidades}");
            System.Threading.Thread.Sleep(1000); // Simula una espera de 1 segundo entre medidas
        }
    }

    // Método para tomar x medidas, una cada cierto tiempo
    public void Medir(int numMedidas, int frecuencia)
    {
        if (!Estado)
        {
            Console.WriteLine("No se pueden tomar medidas continuas porque el sensor está apagado.");
            return;
        }
        else if (!Calibrado)
        {
            Console.WriteLine("No se pueden tomar medidas continuas porque el sensor no está calibrado.");
            return;
        }
        Console.WriteLine($"Tomando {numMedidas} medidas, una cada {frecuencia} segundos:");
        for (int i = 0; i < numMedidas; i++)
        {
            Medida = ObtenerValor();
            instanteMedida = DateTime.Now;
            Console.WriteLine($"{instanteMedida} - Medida {i + 1}: {Medida}{unidades}");
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
            Console.WriteLine("No se pueden tomar la medida porque el sensor no está calibrado.");
            return;
        }
        Medida = ObtenerValor();
        instanteMedida = DateTime.Now;
        Console.WriteLine($"{instanteMedida} - Medida puntual del sensor: {Medida}°C");
    }

    // Sobrescritura del método ToString
    public override string ToString()
    {
        return base.ToString() + $", TipoSensor: {TipoSensor}, Calibrado:{Calibrado}";
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