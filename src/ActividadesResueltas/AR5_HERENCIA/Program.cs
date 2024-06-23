class Program
{
    static void Main()
    {
        // Crear dos sensores de temperatura
        SensorTemperatura sensor1 = new SensorTemperatura("Fabricante A", "°C");
        SensorTemperatura sensor2 = new SensorTemperatura("Fabricante B", "°C");

        // Activar los sensores
        sensor1.Activar();
        sensor2.Activar();

        // Calibrar los sensores
        sensor1.Calibrar();
        sensor2.Calibrar();

        // Medir la temperatura con cada sensor
        sensor1.MedirTemperatura();
        sensor2.MedirTemperatura();

        // Mostrar la temperatura de los sensores
        Console.WriteLine($"El sensor 1 marca: {sensor1.Temperatura}{sensor1.unidades}");
        Console.WriteLine($"El sensor 2 marca: {sensor2.Temperatura}{sensor1.unidades}");

        // Intentar actualizar la temperatura fuera de rango
        sensor1.Temperatura = 105.0;

        // Desactivar los sensores
        sensor1.Desactivar();
        sensor2.Desactivar();

        // Intentar actualizar la temperatura con sensor desactivado
        sensor1.Temperatura = 50.0;
    }
}