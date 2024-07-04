namespace Actuadores
{
    public class Luz
    {
        private string id;
        private string ubicacion;
        private double intensidad;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public double Intensidad
        {
            get { return intensidad; }
            private set { intensidad = value; }
        }

        public string Ubicacion 
        { 
            get { return ubicacion; }
            private set { ubicacion = value; }
         }

        public Luz(string id, string ubicacion)
        {
            this.id = id;
            this.ubicacion = ubicacion;
            this.intensidad = 0;
        }

        public void CambiarIntensidad(double intensidad)
        {
            Intensidad = intensidad;
            Console.WriteLine($"Intensidad de la luz {Id} cambiada a: {Intensidad}");
        }
    }
}