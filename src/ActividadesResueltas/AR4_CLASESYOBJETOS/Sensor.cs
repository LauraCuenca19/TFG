public class Sensor
{
    // Atributos privados
    private bool estado; // Almacena el estado del sensor: activado (true) o desactivado (false)
    private string tipoSensor; // Almacena el tipo de sensor
    
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
    public Sensor(string tipo)
    {
        TipoSensor = tipo;
        Calibrado = false;
        estado = false;
        Console.WriteLine($"Sensor {tipo} creado.");
    }

    // Método público para activar el sensor
    public void Activar()
    {
        estado = true; // Cambia el estado del sensor a activado
        Console.WriteLine("Sensor activado."); // Mensaje de confirmación
    }

    // Método público para desactivar el sensor
    public void Desactivar()
    {
        estado = false; // Cambia el estado del sensor a desactivado
        Console.WriteLine("Sensor desactivado."); // Mensaje de confirmación
    }

    // Método para calibrar el sensor
    public void Calibrar()
    {
        if (estado) Calibrado = true;
        else Calibrado = false;
        Console.WriteLine($"Sensor calibrado: {Calibrado}"); // Mensaje de confirmación
    }

    // Método público para obtener un valor simulado de medida
    public double ObtenerValor()
    {
        Random rand = new Random(); // Crea una instancia de la clase Random para generar valores aleatorios
        // Genera un valor aleatorio entre 0 y 100
        double valor = Math.Round(rand.NextDouble() * 100, 2);  // Redondea el valor a 2 decimales
        return valor;
    }
}