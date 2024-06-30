namespace EP1
{
    public class ControladorDeLuces
    {
        private string estado;
        private Luz luz;

        public string Estado
        {
            get { return estado; }
            private set { estado = value; }
        }

        public ControladorDeLuces(Luz luz)
        {
            this.luz = luz;
            Estado = "Apagado";
        }

        public void EncenderLuces()
        {
            luz.CambiarIntensidad(100);
            Estado = "Encendido";
            Console.WriteLine("Luces encendidas.");
        }

        public void ApagarLuces()
        {
            luz.CambiarIntensidad(0);
            Estado = "Apagado";
            Console.WriteLine("Luces apagadas.");
        }

        public void AjustarIntensidad(float intensidad)
        {
            luz.CambiarIntensidad(intensidad);
            Estado = "Ajustado";
            Console.WriteLine($"Intensidad de luces ajustada a: {intensidad}");
        }
    }
}