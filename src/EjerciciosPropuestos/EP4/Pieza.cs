namespace EP4
{
    public class Pieza
    {
        public string Tipo { get; }
        public bool NecesitaSoldadura { get; }
        public bool NecesitaPintura { get; }
        public bool Soldada { get; set;}
        public bool Pintada { get; set;}


        public Pieza(string tipo, bool necesitaSoldadura, bool necesitaPintura)
        {
            Tipo = tipo;
            NecesitaSoldadura = necesitaSoldadura;
            NecesitaPintura = necesitaPintura;
            Soldada = false;
            Pintada = false;
        }

        public override string ToString()
        {
            return $"Estado de {Tipo}: soldada - {Soldada}, pintada - {Pintada}.";
        }
    }
}