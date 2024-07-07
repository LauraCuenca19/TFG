namespace Sensores
{
    public class SensorDeMovimiento : Sensor
    {
        private bool estado;

        public bool Estado
        {
            get { return estado; }
            private set { estado = value; }
        }

        public SensorDeMovimiento (string id, string ubicacion) : base(id, ubicacion)
        {
            estado = false;
        }

        public override void LeerValor()
        {
            DetectarMovimiento();
        }

        private void DetectarMovimiento()
        {
            // Implementación de la detección de movimiento
            // Aquí puedes simular el cambio de estado
            int random = new Random().Next(0, 2); // Simulación de detección de movimiento
            if (random == 1)
            {
                Estado = true;
                Console.WriteLine($"Movimiento detectado: {Estado} en {Ubicacion}.");
            }
            else Console.WriteLine($"Movimiento detectado: {Estado} en {Ubicacion}.");
        }
    }
}