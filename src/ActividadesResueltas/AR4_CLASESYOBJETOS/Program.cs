class Program
{
    static void Main()
    {
        // Crear tres sensores
        Sensor sensorTemperatura = new Sensor("Temperatura");
        Sensor sensorHumedad = new Sensor("Humedad");
        Sensor sensorIndeterminado = new Sensor("Presión");

        // Asignación de un tipo válido al sensor
        sensorIndeterminado.TipoSensor = "Temperatura";

        // Activar los sensores
        sensorTemperatura.Activar();
        sensorHumedad.Activar();
        sensorIndeterminado.Activar();

        // Obtener y mostrar una medida de cada sensor
        Console.WriteLine($"El sensor de {sensorTemperatura.TipoSensor} marca {sensorTemperatura.ObtenerValor()}°C");
        Console.WriteLine($"El sensor de {sensorHumedad.TipoSensor} marca {sensorHumedad.ObtenerValor()}%");
        Console.WriteLine($"El segundo sensor de {sensorIndeterminado.TipoSensor} marca {sensorIndeterminado.ObtenerValor()}°C");

        // Calibrar los sensores
        sensorTemperatura.Calibrar();
        sensorHumedad.Calibrar();
        sensorIndeterminado.Calibrar();

        // Desactivar los sensores
        sensorTemperatura.Desactivar();
        sensorHumedad.Desactivar();
        sensorIndeterminado.Desactivar();
    }
}