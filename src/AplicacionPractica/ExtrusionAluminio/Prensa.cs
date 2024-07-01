namespace ExtrusionAluminio
{
    // Clase Prensa que hereda de Maquina
    class Prensa : Maquina
    {
        public override void RealizarOperacion(Tocho tocho, Perfil perfil)
        {
            // Calcular tiempo de proceso según el ritmo de extrusión y la fuerza
            int tiempoBase = 240; // Tiempo base en segundos
            int tiempoAdicional = 0;

            if (perfil.RitmoExtrusionPrensa == "Lento")
            {
                tiempoAdicional = 120; // Ejemplo de tiempo adicional para ritmo lento
            }
            else if (perfil.RitmoExtrusionPrensa == "Medio")
            {
                tiempoAdicional = 60; // Ejemplo de tiempo adicional para ritmo medio
            }
            else if (perfil.RitmoExtrusionPrensa == "Rápido")
            {
                tiempoAdicional = 0; // Ejemplo de tiempo adicional para ritmo rápido
            }

            // Ajustar tiempo de proceso según la fuerza
            switch (perfil.FuerzaPrensa)
            {
                case "Baja":
                    tiempoBase += 30;
                    break;
                case "Media":
                    tiempoBase += 0;
                    break;
                case "Alta":
                    tiempoBase -= 30;
                    break;
                default:
                    break;
            }

            // Simular proceso de extrusión del perfil
            Console.WriteLine("\nExtruyendo el perfil en la prensa...");
            System.Threading.Thread.Sleep(1000);

            // Sumar tiempo total de proceso
            perfil.TiempoProcesoTotal += tiempoBase + tiempoAdicional;
        }
    }
}
