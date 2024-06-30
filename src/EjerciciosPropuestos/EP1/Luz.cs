namespace EP1
{
    public class Luz
    {
        private string id;
        private float intensidad;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public float Intensidad
        {
            get { return intensidad; }
            private set { intensidad = value; }
        }

        public void CambiarIntensidad(float intensidad)
        {
            Intensidad = intensidad;
            Console.WriteLine($"Intensidad de la luz {Id} cambiada a: {Intensidad}");
        }
    }
}