namespace SensoresActuadores
{
    public class Actuador
    {
        public bool TopesSubidos { get; private set; }

        public void SubirTopes()
        {
            TopesSubidos = true;
            Console.WriteLine("Topes subidos.");
        }

        public void BajarTopes()
        {
            TopesSubidos = false;
            Console.WriteLine("Topes bajados.");
        }
    }
}

