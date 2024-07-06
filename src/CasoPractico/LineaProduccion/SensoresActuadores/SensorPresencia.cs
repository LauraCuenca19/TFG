namespace SensoresActuadores
{
    // Clase abstracta Sensor
    public class SensorPresencia
    {
        private bool presencia;

        public SensorPresencia()
        {
            presencia = false;
        }

        public void Detectar()
        {
            presencia = true;
        }

        public void Resetear()
        {
            presencia = false;
        }
    }
}