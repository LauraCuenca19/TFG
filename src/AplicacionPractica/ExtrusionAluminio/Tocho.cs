namespace ExtrusionAluminio
{
    // Clase Tocho para representar el material inicial
    class Tocho
    {
        public double Longitud { get; private set; }
        public string Aleacion { get; private set; }

        public Tocho(string aleacion)
        {
            Random rand = new Random();
            Longitud = Math.Round(1.5 + rand.NextDouble() * 1.5, 2);
            Aleacion = aleacion;
        }
    }
}