namespace Ejemplos.C5_POLIMORFISMOESTATICO
{
    class Program
    {
        static void Main()
        {
            Sensor sensor1 = new Sensor("s1", "Honeywell", "°C");
            // Encender el sensor
            sensor1.Activar();
            // Medición continua durante 3 segundos
            sensor1.Medir(3);
            // Toma de 5 medidas con 2 segundos de diferencia entre ellas.
            sensor1.Medir(5,2);
        }
    }
}