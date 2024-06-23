class Program
{
    static void Main()
    {
        // Crear una instancia de Sensor
        Sensor sensor = new Sensor("Temperatura", "FabricanteA","°C");
        // Crear una instancia de SensorTemperatura
        SensorTemperatura sensorTemp = new SensorTemperatura("FabricanteB","°C");

        // Operaciones sobre el objeto de la clase Sensor
        Console.WriteLine("\nOperaciones sobre el objeto de la clase Sensor:");
        sensor.Activar();
        sensor.Calibrar(); // Llamada al método de la clase base

        // Operaciones sobre el objeto de la clase SensorTemperatura
        Console.WriteLine("\nOperaciones sobre el objeto de la clase SensorTemperatura:");
        sensorTemp.Activar();
        sensorTemp.Calibrar();  // Llamada al método de la clase hija
        
        // Imprimir detalles de los sensores
        Console.WriteLine("\nInformación de los dispositivos:");
        Console.WriteLine(sensor.ToString());
        Console.WriteLine(sensorTemp.ToString());
    }
}