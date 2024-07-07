namespace Ejemplos.C5_POLIMORFISMODINAMICO
{
    public class Program
    {
        public static void Main()
        {
            // Crear un array de sensores
            Sensor[] sensores = new Sensor[2];

            // Crear una instancia de Sensor
            Sensor sensor1 = new Sensor("Sensor1", "Honeywell","°C");
            // Crear una instancia de SensorTemperatura
            SensorTemperatura sensor2 = new SensorTemperatura("SensorTemperatura1","Honeywell","°C");

            // Inicializar el array con instancias de Sensor y SensorTemperatura
            sensores[0] = sensor1;
            sensores[1] = sensor2;

            for (int i = 0; i < sensores.Length; i++)
            {
                Console.WriteLine($"\nOperaciones sobre el dispositivo: {sensores[i].DispositivoID}");
                sensores[i].Activar();
                sensores[i].Calibrar();
                sensores[i].Medir(); // Llamada al método correspondiente
            }
        }
    }
}