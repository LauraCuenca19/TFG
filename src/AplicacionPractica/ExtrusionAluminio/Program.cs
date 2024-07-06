﻿using SCADA;
class Program
{
    static void Main()
    {
        SCADAExtrusionAluminio simulador = new SCADAExtrusionAluminio();
        while (true)
        {
            simulador.ProcesarPerfiles(); // Simular producción de perfiles

            // Opciones al finalizar la prueba
            while (true)
            {
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("\nOpciones:");
                Console.WriteLine("1. Mostrar lista de perfiles creados");
                Console.WriteLine("2. Continuar producción");
                Console.WriteLine("3. Salir del programa");
                Console.Write("Seleccione una opción (1/2/3): ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        // Mostrar lista de perfiles creados
                        simulador.MostrarListaPerfiles();
                        break;
                    case "2":
                        // Continuar con otra prueba
                        Console.WriteLine("\nPreparando para iniciar...");
                        Console.WriteLine("----------------------------");
                        break; // Salir del switch
                    case "3":
                        // Salir del programa
                        Console.WriteLine("\nProducción finalizada.");
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
