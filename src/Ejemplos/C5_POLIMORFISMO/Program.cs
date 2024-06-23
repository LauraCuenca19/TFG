class Program
{
    static void Main()
    {
        // Creación objeto de la clase base Sensor
        Sensor sensor = new Sensor("Temperatura","Honeywell","°C");

        // Creación objeto de la clase derivada SensorTemperatura
        SensorTemperatura sensorTemp = new SensorTemperatura("Honeywell","°C");

        Medir(sensor); // Medida con objeto de la clase base
        Medir(sensorTemp); // Medida con objeto de la clase derivada
    }

    // Polimorfismo
    static void Medir(Sensor sensor)
    {
        double valor = sensor.ObtenerValor();  // Llamada al método ObtenerValor
        Console.WriteLine($"Medida del sensor: {valor}{sensor.unidades}");
    }
}