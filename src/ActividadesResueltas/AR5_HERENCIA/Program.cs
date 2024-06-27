namespace ActividadesResueltas.AR5_HERENCIA
{
    class Program
    {
        static void Main()
        {
            // Crear dos sensores
            SensorTemperatura sensor1 = new SensorTemperatura("sT1", "Fabricante A", "°C");
            SensorHumedad sensor2 = new SensorHumedad("sH1", "Fabricante B", "%");

            // Activar los sensores
            sensor1.Activar();
            sensor2.Activar();

            // Calibrar los sensores
            sensor1.Calibrar();
            sensor2.Calibrar();

            // Medir con cada sensor
            sensor1.MedirTemperatura();
            sensor2.MedirHumedad();

            // Intentar actualizar la temperatura fuera de rango
            sensor1.Temperatura = 105.0;

            // Desactivar los sensores
            sensor1.Desactivar();
            sensor2.Desactivar();

            // Intentar actualizar la humedad con sensor desactivado
            sensor2.Humedad = 50.0;
        }
    }
}