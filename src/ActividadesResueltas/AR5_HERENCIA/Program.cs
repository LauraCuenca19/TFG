namespace ActividadesResueltas.AR5_HERENCIA
{
    class Program
    {
        static void Main()
        {
            // Crear dos sensores de temperatura
            SensorTemperatura sensor1 = new SensorTemperatura("sT1", "Fabricante A", "°C");
            SensorTemperatura sensor2 = new SensorTemperatura("sT2", "Fabricante B", "°C");

            // Activar los sensores
            sensor1.Activar();
            sensor2.Activar();

            // Calibrar los sensores
            sensor1.Calibrar();
            sensor2.Calibrar();

            // Medir la temperatura con cada sensor
            sensor1.MedirTemperatura();
            sensor2.MedirTemperatura();

            // Intentar actualizar la temperatura fuera de rango
            sensor1.Temperatura = 105.0;

            // Desactivar los sensores
            sensor1.Desactivar();
            sensor2.Desactivar();

            // Intentar actualizar la temperatura con sensor desactivado
            sensor1.Temperatura = 50.0;
        }
    }
}