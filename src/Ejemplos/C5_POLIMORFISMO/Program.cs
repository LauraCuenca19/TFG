using ActividadesResueltas.AR5_POLIMORFISMOESTATICO;

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
            for (int i = 0; i < sensores.Length; i++)
            {
                sensores[i].Activar();
                sensores[i].Calibrar();
                Console.WriteLine($"Valor medido por el sensor {sensores[i].DispositivoID}:");
                sensores[i].Medir();

            }
            
            // Llamada al método ObtenerValor() usando downcasting (el tipo derivado específico)
            Console.WriteLine("\nLlamadas al método ObtenerValor() usando downcasting:");
            ((SensorTemperatura)sensores[0]).ObtenerValor();
            Console.WriteLine($"Valor medido por el sensor {sensores[0].DispositivoID}: {sensores[0].Medida}{sensores[0].unidadMedida}");
            ((SensorHumedad)sensores[1]).ObtenerValor();
            Console.WriteLine($"Valor medido por el sensor {sensores[1].DispositivoID}: {sensores[1].Medida}{sensores[1].unidadMedida}");
        }
    }
}