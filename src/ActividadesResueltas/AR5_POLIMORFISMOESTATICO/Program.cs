namespace ActividadesResueltas.AR5_POLIMORFISMOESTATICO
{
    class Program
    {
        static void Main()
        {
            Sensor sensor1 = new Sensor("s1", "Fabricante A", "°C");
            // Encender el sensor
            sensor1.Activar();
            // Intento de medición continua durante 5 segundos con sensor sin calibrar
            sensor1.Medir(5);
            // Calibrar sensor
            sensor1.Calibrar();
            // Medida puntual
            sensor1.Medir();
            // Toma de 3 medidas con 5 segundos de diferencia entre ellas.
            sensor1.Medir(3,5);
            // Apagar el sensor
            sensor1.Desactivar();
            // Intento de medición puntual con sensor apagado
            sensor1.Medir();
        }
    }
}