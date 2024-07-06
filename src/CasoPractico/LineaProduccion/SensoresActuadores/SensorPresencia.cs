namespace SensoresActuadores
{
    // Clase abstracta Sensor
    public class SensorPresencia
    {
        public bool Presencia { get; private set; }

        public void Detectar()
        {
            Presencia = true;
        }

        public void Resetear()
        {
            Presencia = false;
        }
    }
}