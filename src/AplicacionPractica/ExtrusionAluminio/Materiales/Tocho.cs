namespace Materiales
{
    // Clase Tocho para representar el material inicial
    public class Tocho
    {
        public string Id { get; set; } // id del tocho
        public double Longitud { get; private set; } // longitud del tocho
        public string Aleacion { get; private set; } // aleacion del tocho
        public double Temperatura { get; set; } // temperatura del tocho

        // Constructor
        public Tocho(string aleacion, string id)
        {
            Random rand = new Random();
            // Generar longitud aleatoria para el tocho
            Longitud = Math.Round(1.5 + rand.NextDouble() * 1.5, 2);
            Aleacion = aleacion;
            Id = id;
            Temperatura = 25;
        }
    }
}