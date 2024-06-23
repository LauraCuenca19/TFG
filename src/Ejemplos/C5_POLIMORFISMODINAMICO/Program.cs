public class Program
{
    public static void Main()
    {
        // Crear una instancia de Sensor
        Sensor sensor = new Sensor("Temperatura", "Honeywell","°C");
        // Crear una instancia de SensorTemperatura
        SensorTemperatura sensorTemp = new SensorTemperatura("Honeywell","°C");

        // Operaciones sobre el objeto de la clase Sensor
        Console.WriteLine("\nOperaciones sobre el objeto de la clase Sensor:");
        sensor.Activar();
        sensor.Calibrar();
        sensor.Medir(); // Llamada al método de la clase base.

        // Operaciones sobre el objeto de la clase SensorTemperatura
        Console.WriteLine("\nOperaciones sobre el objeto de la clase SensorTemperatura:");
        sensorTemp.Activar();
        sensorTemp.Calibrar();
        sensorTemp.Medir(); // Llamada al método sobrescrito en la clase derivada
    }
}