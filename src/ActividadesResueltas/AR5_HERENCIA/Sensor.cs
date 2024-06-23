public class Sensor : DispositivoElectronico
{
    // Atributo privado
    private string tipoSensor; // Almacena el tipo de sensor

    // Atributo para almacenar unidad de medida
    public readonly string unidades;
    
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
    public void Calibrar()
    {
        if (Estado) Calibrado = true;  // Uso de propiedad heredada Estado
        else Calibrado = false;
        Console.WriteLine($"Sensor calibrado: {Calibrado}");
    }

    // Método público para obtener un valor simulado de medida
    public double ObtenerValor()
    {
        Random rand = new Random();
        // Genera un valor aleatorio entre 0 y 100
        double valor = Math.Round(rand.NextDouble() * 100, 2);
        return valor;
    }
}