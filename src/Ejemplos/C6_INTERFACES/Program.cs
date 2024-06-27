namespace Ejemplos.C6_INTERFACES
{    
    class Program
    {
        public static void Main()
        {
            SensorTemperatura sensor = new SensorTemperatura("ST1","FabricanteA","°C");
            
            // Activar el sensor
            sensor.Activar();
            
            // Calibrar el sensor
            sensor.Calibrar();
            
            // Cambiar a modo automático
            sensor.ModoAutomatico();

            // Esperar un poco antes de finalizar
            System.Threading.Thread.Sleep(1000); // 5 segundos

            Console.WriteLine("Fin de la prueba.");
        }
    }
}