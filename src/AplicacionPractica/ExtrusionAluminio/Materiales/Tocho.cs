namespace Materiales
{
    // Clase Tocho para representar el material inicial
    public class Tocho
    {
        public string Id { get; set; }
        public double Longitud { get; private set; }
        public string Aleacion { get; private set; }
        public double Temperatura { get; set; }

        public Tocho(string aleacion, string id)
        {
            Random rand = new Random();
            Longitud = Math.Round(1.5 + rand.NextDouble() * 1.5, 2);
            Aleacion = aleacion;
            Id = id;
            Temperatura = 0;
        }
    }
}