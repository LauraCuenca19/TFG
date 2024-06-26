namespace ActividadesResueltas.AR4_CLASESYOBJETOS
{
    class Program
    {
        static void Main()
        {
            // Crear tres sensores
            Sensor sensor1 = new Sensor("Temperatura","s1");
            Sensor sensor2 = new Sensor("Humedad","s2");
            Sensor sensor3 = new Sensor("Presión","s3");

            // Asignación de un tipo válido al sensor
            sensor3.TipoSensor = "Temperatura";

            // Activar los sensores
            sensor1.Activar();
            sensor2.Activar();
            sensor3.Activar();

            // Obtener y mostrar una medida de cada sensor
            Console.WriteLine($"El sensor de {sensor1.TipoSensor} marca {sensor1.ObtenerValor()}°C");
            Console.WriteLine($"El sensor de {sensor2.TipoSensor} marca {sensor2.ObtenerValor()}%");
            Console.WriteLine($"El segundo sensor de {sensor3.TipoSensor} marca {sensor3.ObtenerValor()}°C");

            // Calibrar los sensores
            sensor1.Calibrar();
            sensor2.Calibrar();
            sensor3.Calibrar();

            // Desactivar los sensores
            sensor1.Desactivar();
            sensor2.Desactivar();
            sensor3.Desactivar();
        }
    }
}