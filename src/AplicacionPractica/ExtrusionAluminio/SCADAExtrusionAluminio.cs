using Sensores;
using Actuadores;
using Materiales;
using Maquinaria;


namespace ExtrusionAluminio
{
    // Clase para gestionar la lógica de Simulación
    public class SCADAExtrusionAluminio
    {
        private List<Maquina> maquinasProceso { get; }
        private List<Perfil> perfilesCreados { get; }
        private List<Tocho> tochos { get; }
        

        public SCADAExtrusionAluminio()
        {
            // Inicializar la cola de máquinas en el orden de operación
            maquinasProceso = new List<Maquina>
            {
                new Horno("H1", new SensorTemperatura("STH1"), new ResistenciaCalefactora("RCH1")),
                new Prensa("P1", new SensorPresion("SPP1"), new SensorVelocidad("SVP1")),
                new TunelEnfriamiento("TE1", new SensorTemperatura("STTE1"), new SensorTemperatura("STTE2"), new Ventilador("VTE1"))
            };

            // Inicializar lista de perfiles creados
            perfilesCreados = new List<Perfil>();

            tochos = new List<Tocho>();
        }

        // Método para solicitar al usuario cantidad de tochos a procesar
        private int SolicitarTochos()
        {
            Console.Write("Ingrese el número de tochos que se van a procesar: ");
            return int.Parse(Console.ReadLine());
        }

        // Función para solicitar al usuario que ingrese la aleación para el perfil
        private string SolicitarAleacion()
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
        private double[] ConsultarGuiaManual(string aleacion)
        {
            // Proporcionar recomendaciones basadas en la aleación seleccionada
            switch (aleacion)
            {
                case "6061":
                    Console.WriteLine("\nRecomendaciones para aleación 6061:");
                    Console.WriteLine("Temperatura óptima: 450-500°C");
                    Console.WriteLine("Presión: Media a Alta");
                    Console.WriteLine("Ritmo de extrusión: Medio");
                    return new double [] {450,500,6.5,8,4,7.5};
                    break;
                case "7075":
                    Console.WriteLine("\nRecomendaciones para aleación 7075:");
                    Console.WriteLine("Temperatura óptima: 420-470°C");
                    Console.WriteLine("Presión: Alta");
                    Console.WriteLine("Ritmo de extrusión: Lento a Medio");
                    return new double [] {420,470,7.5,8,0.5,5};
                    break;
                case "2024":
                    Console.WriteLine("\nRecomendaciones para aleación 2024:");
                    Console.WriteLine("Temperatura óptima: 400-450°C");
                    Console.WriteLine("Presión: Media");
                    Console.WriteLine("Ritmo de extrusión: Medio a Rápido");
                    return new double [] {400,450,5.5,7,5,10};
                    break;
                default:
                    Console.WriteLine("Aleación no reconocida.");
                    return new double [] {0,0,0,0,0,0};
                    break;
            }
        }

        // Método para mostrar la lista de perfiles creados
        public void MostrarListaPerfiles()
        {
            Console.WriteLine("\nLista de perfiles creados:");

            if (perfilesCreados.Count > 0)
            {
                foreach (var perfil in perfilesCreados)
                {
                    Console.WriteLine($"- {perfil.Id}: {perfil.Aleacion}, {perfil.Forma}.");
                }
            }
            else
            {
                Console.WriteLine("No hay perfiles almacenados en esta simulación.");
            }
        }

        // Método para simular una prueba de creación de perfil
        public void ProcesarPerfiles()
        {
            // Soliciar número de tochos a procesar
            int numTochos = SolicitarTochos();

            // Solicitar al usuario que elija la aleación del tocho
            string aleacionSeleccionada = SolicitarAleacion();

            // Mostrar la guía con las recomendaciones para la aleación seleccionada
            double[] datos  = ConsultarGuiaManual(aleacionSeleccionada);

            ((Horno)maquinasProceso[0]).MinTemp = datos[0];
            ((Horno)maquinasProceso[0]).MaxTemp = datos[1];
            ((Prensa)maquinasProceso[1]).MinPresion = datos[2];
            ((Prensa)maquinasProceso[1]).MaxPresion = datos[3];
            ((Prensa)maquinasProceso[1]).MinVel = datos[4];
            ((Prensa)maquinasProceso[1]).MaxVel = datos[5];
            ((TunelEnfriamiento)maquinasProceso[2]).MinTemp = datos[0];
            ((TunelEnfriamiento)maquinasProceso[2]).MaxTemp = datos[1];

            string forma = SeleccionarFormaMatriz();

            // Crear tochos con la aleación seleccionada y longitud aleatoria
            for (int i = 0; i < numTochos; i++)
            {
                Tocho tocho = new Tocho(aleacionSeleccionada, $"Tocho{i+1}");
                tochos.Add(tocho);
                Perfil perfil = new Perfil($"Perfil{i+1}", forma, aleacionSeleccionada);
                // Almacenar perfil creado en la lista de perfiles
                perfilesCreados.Add(perfil);
            }         
    
            // Procesar el tocho en cada máquina en la cola
            foreach (var tocho in tochos)
            {
                foreach (var maquina in maquinasProceso)
                {
                    Console.WriteLine($"\nETAPA {maquinasProceso.IndexOf(maquina)+1} - Perfil {tocho.Id}: {maquina.GetType().Name}");
                    maquina.RealizarOperacion(tocho, perfilesCreados[tochos.IndexOf(tocho)]);
                    System.Threading.Thread.Sleep(2000);
                }
            }
            tochos.Clear();
        }
    }
}
