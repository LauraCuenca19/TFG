namespace EP1
{
    public class SensorDeLuz : Sensor
    {
        private float intensidadLuz;

        public float IntensidadLuz
        {
            get { return intensidadLuz; }
            private set { intensidadLuz = value; }
        }

        public override void LeerValor()
        {
            MedirIntensidad();
        }

        private void MedirIntensidad()
        {
            // Implementación de la medición de la intensidad de luz
            // Aquí puedes simular la medición de intensidad
            IntensidadLuz = (float)new Random().NextDouble() * 100; // Simulación de la intensidad de luz
            Console.WriteLine($"Intensidad de luz medida: {IntensidadLuz}");
        }
    }
}