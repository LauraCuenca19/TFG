namespace Materiales
{
    // Clase Perfil para representar un perfil generado
    public class Perfil
    {
        public string Id { get; } // id del perfil
        public string Forma { get; set; } // forma
        public string Aleacion { get; } // aleacion utilizada

        // Constructor
        public Perfil(string id, string forma, string aleacion)
        {
            Id = id;
            Forma = forma;
            Aleacion = aleacion;
        }
    }
}
