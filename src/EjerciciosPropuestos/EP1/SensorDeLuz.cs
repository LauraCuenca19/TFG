namespace Sensores
{
    public class SensorDeLuz : Sensor
    {
        private double intensidadLuz;

        public double IntensidadLuz
        {
            get { return intensidadLuz; }
            private set { intensidadLuz = value; }
        }

        public SensorDeLuz (string id, string ubicacion) : base(id, ubicacion)
        {
            intensidadLuz = 0;
        }

        public override void LeerValor()
        {
            MedirIntensidad();
        }

        private void MedirIntensidad()
        {
            // Implementación de la medición de la intensidad de luz
            // Aquí puedes simular la medición de intensidad
            IntensidadLuz = Math.Round((double)new Random().NextDouble() * 100,2); // Simulación de la intensidad de luz
            Console.WriteLine($"Intensidad de luz medida: {IntensidadLuz} en {Ubicacion}");
        }
    }
}