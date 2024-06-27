using Ejemplos.C5_HERENCIA;

namespace Ejemplos.C5_POLIMORFISMO
{
    class Program
    {
        static void Main()
        {
            // Crear un array de sensores
            Sensor[] sensores = new Sensor[2];
            
            // Crear dos sensores: uno de temperatura y uno de humedad
            SensorTemperatura sensor1 = new SensorTemperatura("sT1", "Fabricante A", "°C");
            SensorHumedad sensor2 = new SensorHumedad("sH1", "Fabricante B", "%");

            // Inicializar el array con instancias de SensorTemperatura y SensorHumedad
            sensores[0] = sensor1;
            sensores[1] = sensor2;

            // Demostrar el concepto de shadowing (ocultación de métodos)
            // Llamada al método ObtenerValor() usando upcasting (el tipo base Sensor)
            Console.WriteLine("Llamadas al método ObtenerValor() usando upcasting:");
            Console.WriteLine("SensorTemperatura:");
            double valorSensorTemperatura = sensores[0].ObtenerValor();
            Console.WriteLine("SensorHumedad:");
            double valorSensorHumedad = sensores[1].ObtenerValor();
            

            // Llamada al método ObtenerValor() usando downcasting (el tipo derivado específico)
            Console.WriteLine("\nLlamadas al método ObtenerValor() usando downcasting:");
            valorSensorTemperatura = ((SensorTemperatura)sensores[0]).ObtenerValor();
            Console.WriteLine($"Valor medido por SensorTemperatura: {valorSensorTemperatura}{sensores[0].unidadMedida}");
            valorSensorHumedad = ((SensorHumedad)sensores[1]).ObtenerValor();
            Console.WriteLine($"Valor medido por SensorHumedad: {valorSensorHumedad}{sensores[1].unidadMedida}");
        }
    }
}