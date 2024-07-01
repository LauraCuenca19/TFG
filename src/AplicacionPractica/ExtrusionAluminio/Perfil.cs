namespace ExtrusionAluminio
{
    // Clase Perfil para representar un perfil generado
    class Perfil
    {
        public string Nombre { get; }
        public int TiempoProcesoTotal { get; set; } // En segundos
        public string FormaMatriz { get; }
        public string Aleacion { get; }
        public int PuntosCalidad { get; set; } // Sobre 100
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

            // Evaluar según la aleación y parámetros de proceso recibidos
            switch (Aleacion)
            {
                case "6061":
                    if (TemperaturaHorno >= 450 && TemperaturaHorno <= 500)
                        PuntosCalidad += 25; // Añadir puntos por temperatura óptima

                    if (FuerzaPrensa == "Alta")
                        PuntosCalidad += 15;
                    else if (FuerzaPrensa == "Media")
                        PuntosCalidad += 25;
                    else if (FuerzaPrensa == "Baja")
                        PuntosCalidad += 0;

                    if (RitmoExtrusionPrensa == "Medio")
                        PuntosCalidad += 25;
                    else if (RitmoExtrusionPrensa == "Lento")
                        PuntosCalidad -= 10;    

                    if (TiempoEnfriamiento >= 300)
                        PuntosCalidad += 25; // Añadir puntos por tiempo de enfriamiento correcto
                    break;

                case "7075":
                    if (TemperaturaHorno >= 420 && TemperaturaHorno <= 470)
                        PuntosCalidad += 25;

                    if (FuerzaPrensa == "Alta")
                        PuntosCalidad += 25;
                    else if (FuerzaPrensa == "Baja")
                        PuntosCalidad -= 10;    

                    if (RitmoExtrusionPrensa == "Medio") // Medio
                        PuntosCalidad += 15;
                    else if (RitmoExtrusionPrensa == "Rápido") // Rápido
                        PuntosCalidad -= 10; 
                    else if (RitmoExtrusionPrensa == "Lento") // Lento
                        PuntosCalidad += 25;  

                    if (TiempoEnfriamiento >= 240)
                        PuntosCalidad += 25;
                    break;

                case "2024":
                    if (TemperaturaHorno >= 400 && TemperaturaHorno <= 450)
                        PuntosCalidad += 25;

                    if (FuerzaPrensa == "Media") // Media
                        PuntosCalidad += 25;
                    if (FuerzaPrensa == "Alta") // Alta
                    PuntosCalidad -= 10;

                    if (RitmoExtrusionPrensa == "Medio") // Medio
                        PuntosCalidad += 25;
                    if (RitmoExtrusionPrensa == "Rápido") // Rápido
                        PuntosCalidad += 15;
                    if (RitmoExtrusionPrensa == "Lento") // Lento
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
