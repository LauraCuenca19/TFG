namespace Materiales
{
    // Clase Perfil para representar un perfil generado
    public class Perfil
    {
        public string Id { get; } // id del perfil
        public string Forma { get; set; } // forma de la matriz
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
