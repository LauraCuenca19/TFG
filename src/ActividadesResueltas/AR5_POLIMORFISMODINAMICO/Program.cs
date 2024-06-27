namespace ActividadesResueltas.AR5_POLIMORFISMODINAMICO
{
    class Program
    {
        static void Main()
        {
            // Crear un array de sensores
            Sensor[] sensores = new Sensor[3];

            // Crear una instancia de Sensor
            Sensor sensor1 = new Sensor("s1","FabricanteA","°C");
            // Crear una instancia de SensorTemperatura
            SensorTemperatura sensor2 = new SensorTemperatura("sT1","FabricanteB","°C");

            // Crear una instancia de SensorHumedad
            SensorHumedad sensor3 = new SensorHumedad("sH1","FabricanteC","%");

            // Inicializar el array con instancias de SensorTemperatura y SensorHumedad
            sensores[0] = sensor1;
            sensores[1] = sensor2;
            sensores[2] = sensor3;

            for (int i = 0; i < sensores.Length; i++)
            {
                Console.WriteLine($"\nOperaciones sobre el dispositivo: {sensores[i].DispositivoID}");
                sensores[i].Activar();
                sensores[i].Calibrar(); // Llamada al método correspondiente
                sensores[i].Medir(); // Llamada al método correspondiente

                // Imprimir detalles de cada sensor:
                Console.WriteLine("\nInformación del sensor:");
                Console.WriteLine(sensores[i].ToString());
            }
        }
    }
}