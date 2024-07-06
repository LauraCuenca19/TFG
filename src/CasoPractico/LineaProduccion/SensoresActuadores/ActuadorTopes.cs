namespace SensoresActuadores
{
    public class ActuadorTopes
    {
        public bool topesSubidos;

        public ActuadorTopes()
        {
            topesSubidos = false;
        }

        public void SubirTopes()
        {
            topesSubidos = true;
            Console.WriteLine("Topes subidos.");
        }

        public void BajarTopes()
        {
            topesSubidos = false;
            Console.WriteLine("Topes bajados.");
        }
    }
}

