namespace ExtrusionAluminio
{
    // Clase principal del programa
    class ExtrusionAluminioAPS
    {
        private List<Maquina> ColaMaquinas { get; }
        private List<Perfil> PerfilesCreados { get; }

        public ExtrusionAluminioAPS()
        {
            // Inicializar la cola de máquinas en el orden de operación
            ColaMaquinas = new List<Maquina>
            {
                new Horno(),
                new Prensa(),
                new Enfriador()
            };

            // Inicializar lista de perfiles creados
            PerfilesCreados = new List<Perfil>();
        }

        // Función para solicitar al usuario que ingrese un nombre para el perfil
        private string SolicitarNombrePerfil()
        {
            Console.Write("Ingrese un nombre para el perfil: ");
            return Console.ReadLine();
        }

        // Función para solicitar al usuario que ingrese la aleación para el perfil
        private string SolicitarAleacionPerfil()
        {
            Console.Write("Ingrese la aleación del tocho (6061, 7075, 2024): ");
            while (true)
            {
                string aleacion = Console.ReadLine();

                // Validar que la aleación ingresada sea una de las opciones permitidas
                if (aleacion == "6061" || aleacion == "7075" || aleacion == "2024")
                {
                    return aleacion; // Devolver la aleación válida
                }
                else
                {
                    Console.WriteLine("Aleación no válida. Por favor, ingrese una de las siguientes opciones: 6061, 7075, 2024");
                }
            }
        }

        private (int, string, string, int) SolicitarDatosPrueba()
        {
            // Solicitar al usuario los datos de la prueba
            Console.Write("\nIngrese la temperatura del horno (en °C): ");
            int temperaturaHorno = Convert.ToInt32(Console.ReadLine());
            Console.Write("Fuerza de la prensa (1:Baja/2:Media/3:Alta): ");
            string fuerzaPrensa;
            int fuerza = Convert.ToInt32(Console.ReadLine());
            switch (fuerza)
            {
                case 1:
                fuerzaPrensa = "Baja";
                break;
                case 2:
                fuerzaPrensa = "Media";
                break;
                case 3:
                fuerzaPrensa = "Alta";
                break;
                default:
                Console.WriteLine("Se ha elegido Media por defecto");
                fuerzaPrensa = "Media";
                break;
            }
            Console.Write("Ritmo de extrusión de la prensa (1:Lento/2:Medio/3:Rápido): ");
            string ritmoExtrusionPrensa;
            int ritmo = Convert.ToInt32(Console.ReadLine());
            switch (ritmo)
            {
                case 1:
                ritmoExtrusionPrensa = "Lento";
                break;
                case 2:
                ritmoExtrusionPrensa = "Medio";
                break;
                case 3:
                ritmoExtrusionPrensa = "Rápido";
                break;
                default:
                Console.WriteLine("Se ha elegido Medio por defecto");
                ritmoExtrusionPrensa = "Medio";
                break;
            }
            Console.Write("Tiempo de enfriamiento (en segundos): ");
            int tiempoEnfriamiento = Convert.ToInt32(Console.ReadLine());

            return (temperaturaHorno, fuerzaPrensa, ritmoExtrusionPrensa, tiempoEnfriamiento); 
        }

        // Función para solicitar al usuario que elija la forma de la matriz
        private string SeleccionarFormaMatriz()
        {
            Console.WriteLine("\nSeleccione la forma de la matriz:");
            Console.WriteLine("1. Circular");
            Console.WriteLine("2. Rectangular");
            Console.WriteLine("3. Personalizada");

            Console.Write("Ingrese la opción deseada (1/2/3): ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    return "Circular";
                case 2:
                    return "Rectangular";
                case 3:
                    return "Personalizada";
                default:
                    Console.WriteLine("Opción no válida. Seleccionando forma circular por defecto.");
                    return "Circular";
            }
        }

        // Método para consultar la guía con los requisitos óptimos para cada aleación
        private void ConsultarGuiaManual(string aleacion)
        {
            // Proporcionar recomendaciones basadas en la aleación seleccionada
            switch (aleacion)
            {
                case "6061":
                    Console.WriteLine("\nRecomendaciones para aleación 6061:");
                    Console.WriteLine("Temperatura óptima: 450-500°C");
                    Console.WriteLine("Fuerza de la prensa: Media a Alta");
                    Console.WriteLine("Ritmo de extrusión: Medio");
                    Console.WriteLine("Tiempo de enfriamiento recomendado: 300 segundos");
                    break;
                case "7075":
                    Console.WriteLine("\nRecomendaciones para aleación 7075:");
                    Console.WriteLine("Temperatura óptima: 420-470°C");
                    Console.WriteLine("Fuerza de la prensa: Alta");
                    Console.WriteLine("Ritmo de extrusión: Lento a Medio");
                    Console.WriteLine("Tiempo de enfriamiento recomendado: 240 segundos");
                    break;
                case "2024":
                    Console.WriteLine("\nRecomendaciones para aleación 2024:");
                    Console.WriteLine("Temperatura óptima: 400-450°C");
                    Console.WriteLine("Fuerza de la prensa: Media");
                    Console.WriteLine("Ritmo de extrusión: Medio a Rápido");
                    Console.WriteLine("Tiempo de enfriamiento recomendado: 180 segundos");
                    break;
                default:
                    Console.WriteLine("Aleación no reconocida.");
                    break;
            }
        }

        // Método para simular una prueba de creación de perfil
        private void SimularPruebaCreacionPerfil()
        {
            // Solicitar al usuario que ingrese el nombre del perfil
            string nombrePerfil = SolicitarNombrePerfil();

            // Solicitar al usuario que elija la aleación del tocho
            string aleacionSeleccionada = SolicitarAleacionPerfil();

            // Crear un tocho con la aleación seleccionada y longitud aleatoria
            Tocho tocho = new Tocho(aleacionSeleccionada);

            // Mostrar la guía con las recomendaciones para la aleación seleccionada
            ConsultarGuiaManual(aleacionSeleccionada);

            // Solicitar al usuario los datos de la prueba
            int temperaturaHorno;
            string fuerzaPrensa ;
            string ritmoExtrusionPrensa;
            int tiempoEnfriamiento;

            (temperaturaHorno, fuerzaPrensa, ritmoExtrusionPrensa, tiempoEnfriamiento) = SolicitarDatosPrueba();

            // Crear un perfil con los datos ingresados
            Perfil perfil = new Perfil(nombrePerfil, SeleccionarFormaMatriz(), aleacionSeleccionada, temperaturaHorno, ritmoExtrusionPrensa, fuerzaPrensa, tiempoEnfriamiento);

            // Procesar el tocho en cada máquina en la cola
            foreach (var maquina in ColaMaquinas)
            {
                maquina.RealizarOperacion(tocho, perfil);
            }

            // Calcular los puntos de calidad del perfil
            perfil.CalcularPuntosCalidad();

            // Mostrar resultados del perfil creado
            Console.WriteLine($"\nPerfil creado: {perfil.Nombre}");
            Console.WriteLine($"Forma de la matriz: {perfil.FormaMatriz}");
            Console.WriteLine($"Tiempo total de proceso: {perfil.TiempoProcesoTotal} segundos");
            Console.WriteLine($"Puntos de calidad: {perfil.PuntosCalidad}");

            // Almacenar perfil creado en la lista de perfiles
            PerfilesCreados.Add(perfil);
        }

        // Método para mostrar la lista de perfiles creados
        private void MostrarListaPerfiles()
        {
            Console.WriteLine("\nLista de perfiles creados:");

            if (PerfilesCreados.Count > 0)
            {
                foreach (var perfil in PerfilesCreados)
                {
                    Console.WriteLine($"- {perfil.Nombre}: {perfil.Aleacion}, {perfil.FormaMatriz}, Tiempo: {perfil.TiempoProcesoTotal} segundos, Calidad: {perfil.PuntosCalidad}");
                }
            }
            else
            {
                Console.WriteLine("No hay perfiles almacenados en esta simulación.");
            }
        }

        // Método principal para iniciar la simulación
        public void IniciarSimulacion()
        {
            while (true)
            {
                SimularPruebaCreacionPerfil(); // Simular una prueba de creación de perfil

                // Opciones al finalizar la prueba
                while (true)
                {
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("\nOpciones:");
                    Console.WriteLine("1. Mostrar lista de perfiles creados");
                    Console.WriteLine("2. Continuar con otra prueba");
                    Console.WriteLine("3. Salir del programa");
                    Console.Write("Seleccione una opción (1/2/3): ");
                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            // Mostrar lista de perfiles creados
                            MostrarListaPerfiles();
                            break;
                        case "2":
                            // Continuar con otra prueba
                            Console.WriteLine("\nPreparando para iniciar otra prueba...");
                            Console.WriteLine("-------------------------------------");
                            break; // Salir del switch y continuar con la simulación
                        case "3":
                            // Salir del programa
                            Console.WriteLine("\nSimulación finalizada.");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("\nOpción no válida. Intente nuevamente.");
                            break;
                    }

                    // Si se selecciona continuar con otra prueba, salir del bucle interno
                    if (opcion == "2")
                    {
                        break;
                    }
                }
            }
        }
    }
}
