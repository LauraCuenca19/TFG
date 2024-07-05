namespace Materiales
{
    // Clase Perfil para representar un perfil generado
    public class Perfil
    {
        public string Id { get; }
        public string Forma { get; set; }
        public string Aleacion { get; }

        public Perfil(string id, string forma, string aleacion)
        {
            Id = id;
            Forma = forma;
            Aleacion = aleacion;
        }
    }
}
