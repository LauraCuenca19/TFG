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
    public SensorTemperatura(string fabricante, string unidadMedida) : base("Temperatura", fabricante, unidadMedida)
    {
        // Inicializa la temperatura a 0.0
        temperatura = 0.0;
    }

    // Método sobrescrito para obtener un valor simulado de medida
    public override double ObtenerValor()
    {
        Console.WriteLine("Llamada al método de la clase SensorTemperatura (clase hija):");
        Random rand = new Random();
        // Genera un valor aleatorio entre 20 y 30
        double valor = Math.Round(20 + rand.NextDouble() * 10, 2);
        return valor;
    }

    // Sobrescritura del método ToString
    public override string ToString()
    {
        return base.ToString() + $", Temperatura: {Temperatura}{unidades}";
    }

    // Método Calibrar sobrescrito
    public override void Calibrar()
    {
        base.Calibrar(); // Llamada al método Calibrar de clase base
        if (Calibrado)
        {   
            Console.WriteLine("Ejecutar Calibrar de la clase SensorTemperatura (clase hija).");    
            Console.WriteLine("Calibrando sensor de temperatura...");
            // Lógica de calibración específica sensor de temperatura
            double[] lecturas = new double[5];

            // Simula la lectura de 5 valores de temperatura
            for (int i = 0; i < lecturas.Length; i++)
            {
                lecturas[i] = ObtenerValor();
                Console.WriteLine($"Lectura {i + 1}: {lecturas[i]:F2}°C");
                System.Threading.Thread.Sleep(500); // Simulación tiempo entre lecturas
            }

            // Calcula la media de las lecturas
            double suma = 0;
            foreach (double lectura in lecturas)
            {
                suma += lectura;
            }
            double promedio = suma / lecturas.Length;
            Console.WriteLine($"Promedio de lecturas: {promedio:F2}°C");

            // Lógica de ajuste del sensor
            Console.WriteLine("Ajustando sensor de temperatura...");
            System.Threading.Thread.Sleep(2000); // Simulación tiempo de ajuste
            temperatura = Math.Round(promedio,2);
            Console.WriteLine("Sensor de temperatura ajustado y calibrado.");
        }
        else
        {
            Console.WriteLine("Error de calibración.");
        }
    }
}