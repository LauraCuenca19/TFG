namespace ExtrusionAluminio
{
    // Clase Perfil para representar un perfil generado
    class Perfil
    {
        public string Nombre { get; }
        public int TiempoProcesoTotal { get; set; } // Tiempo total de proceso en segundos
        public string FormaMatriz { get; }
        public string Aleacion { get; }
        public int PuntosCalidad { get; set; } // Puntuación de calidad del perfil
        public int TemperaturaHorno { get; }
        public string RitmoExtrusionPrensa { get; }
        public string FuerzaPrensa { get; }
        public int TiempoEnfriamiento { get; }

        public Perfil(string nombre, string formaMatriz, string aleacion, int temperaturaHorno, string ritmoExtrusionPrensa, string fuerzaPrensa, int tiempoEnfriamiento)
        {
            Nombre = nombre;
            FormaMatriz = formaMatriz;
            Aleacion = aleacion;
            TemperaturaHorno = temperaturaHorno;
            RitmoExtrusionPrensa = ritmoExtrusionPrensa;
            FuerzaPrensa = fuerzaPrensa;
            TiempoEnfriamiento = tiempoEnfriamiento;
            TiempoProcesoTotal = 0; // Inicializar tiempo total de proceso
            PuntosCalidad = 0; // Inicializar puntos de calidad
        }

        public void CalcularPuntosCalidad()
        {
            PuntosCalidad = 0; // Reiniciar puntuación

            int ritmo = 0;
            switch (RitmoExtrusionPrensa)
            {
                case "Lento":
                ritmo = 1;
                break;
                case "Medio":
                ritmo = 2;
                break;
                case "Rápido":
                ritmo = 3;
                break;
            }

            int fuerza = 0;
            switch (FuerzaPrensa)
            {
                case "Baja":
                fuerza = 1;
                break;
                case "Media":
                fuerza = 2;
                break;
                case "Alta":
                fuerza = 3;
                break;
            }

            // Evaluar según la aleación y los parámetros de proceso recibidos
            switch (Aleacion)
            {
                case "6061":
                    if (TemperaturaHorno >= 450 && TemperaturaHorno <= 500)
                        PuntosCalidad += 25; // Añadir puntos por temperatura óptima

                    if (fuerza >= 3) // Alta
                        PuntosCalidad += 15;
                    else if (fuerza == 2) // Media a Alta
                        PuntosCalidad += 25;
                    else if (fuerza <= 1) // Baja
                        PuntosCalidad += 0;

                    if (ritmo == 2) // Medio
                        PuntosCalidad += 25;
                    else if (ritmo < 2) // Lento
                        PuntosCalidad -= 10;    

                    if (TiempoEnfriamiento >= 300)
                        PuntosCalidad += 25; // Añadir puntos por tiempo de enfriamiento correcto

                    break;

                case "7075":
                    if (TemperaturaHorno >= 420 && TemperaturaHorno <= 470)
                        PuntosCalidad += 25;

                    if (fuerza >= 3) // Alta
                        PuntosCalidad += 25;
                    else if (fuerza == 1) // Baja
                        PuntosCalidad -= 10;    

                    if (ritmo == 2) // Medio
                        PuntosCalidad += 15;
                    else if (fuerza == 3) // Rápido
                        PuntosCalidad -= 10; 
                    else if (fuerza == 1) // Lento
                        PuntosCalidad += 25;  

                    if (TiempoEnfriamiento >= 240)
                        PuntosCalidad += 25;

                    break;

                case "2024":
                    if (TemperaturaHorno >= 400 && TemperaturaHorno <= 450)
                        PuntosCalidad += 25;

                    if (fuerza == 2) // Media
                        PuntosCalidad += 25;
                    if (fuerza == 3) // Alta
                    PuntosCalidad -= 10;

                    if (ritmo == 2) // Medio
                        PuntosCalidad += 25;
                    if (ritmo == 3) // Rápido
                        PuntosCalidad += 15;
                    if (ritmo == 1) // Lento
                        PuntosCalidad -= 10;

                    if (TiempoEnfriamiento >= 180)
                        PuntosCalidad += 25;

                    break;

                default:
                    Console.WriteLine("Aleación no reconocida.");
                    break;
            }

            // Asegurar que la puntuación esté entre 0 y 100
            if (PuntosCalidad < 0)
                PuntosCalidad = 0;
            else if (PuntosCalidad > 100)
                PuntosCalidad = 100;
        }

    }
}
