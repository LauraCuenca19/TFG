using System;
using Simulacion;

class Program
{
    static void Main(string[] args)
    {
        Simulador simulador = new Simulador();
        simulador.ConfigurarLinea();
        
        while (true)
        {
            Console.WriteLine("\nElige el tipo de simulación: ");
            Console.WriteLine("1. Ideal");
            Console.WriteLine("2. Estándar");
            Console.WriteLine("3. Crítico sin paradas");
            Console.WriteLine("4. Estado de falla");
            Console.WriteLine("5. Cambio velocidad de cinta");
            Console.WriteLine("Si quieres ver la lista de resultados de las simulaciones pulsa 6.\n");
            Console.WriteLine("Pulsa 7 para salir.\n");
            int key = int.Parse(Console.ReadLine());

            double tiempoTotal = 0;

            switch (key)
            {
                case 1:
                    tiempoTotal = simulador.SimulacionIdeal();
                    Console.WriteLine($"Tiempo total de producción: {Math.Round(tiempoTotal,2)}s.");
                    break;
                case 2:
                    tiempoTotal = simulador.SimulacionEstandar();
                    Console.WriteLine($"Tiempo total de producción: {Math.Round(tiempoTotal,2)}s.");
                    break;
                case 3:
                    tiempoTotal = simulador.SimulacionCritico();
                    Console.WriteLine($"Tiempo total de producción: {Math.Round(tiempoTotal,2)}s.");
                    break;
                case 4:
                    tiempoTotal = simulador.SimulacionFallo();
                    Console.WriteLine($"Tiempo total de producción: {Math.Round(tiempoTotal,2)}s.");
                    break;
                case 5:
                    tiempoTotal = simulador.SimulacionCambioVelocidad();
                    Console.WriteLine($"Tiempo total de producción: {Math.Round(tiempoTotal,2)}s.");
                    break;
                case 6:
                    simulador.MostrarResultados();
                    break;
                case 7:
                    // Salir del programa
                    Console.WriteLine("\nSimulación finalizada.");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
