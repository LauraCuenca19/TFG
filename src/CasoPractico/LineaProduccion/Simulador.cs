using System;
using System.Collections.Generic;

namespace LineaProduccion
{
    public class Simulador
    {
        private int contadorEstacionesManuales = 0;
        private int contadorEstacionesAutomaticas = 0;
        public List<Estacion> listaEstaciones { get; set; }
        public List<Resultado> listaResultados { get; set; }
        public Cinta Cinta { get; set; }

        public Simulador()
        {
            listaEstaciones = new List<Estacion>();
            listaResultados = new List<Resultado>();
        }

        public void ConfigurarLinea()
        {
            while (true)
            {
                Console.WriteLine("Introduce las estaciones en la línea (M - manual / A - automática).");
                Console.WriteLine("Pulse X para dejar de añadir máquinas.");
                Console.WriteLine("Máquina (M/A): ");
                string tipoEstacion = Console.ReadLine().ToUpper();

                if (tipoEstacion == "X")
                    break;

                if (tipoEstacion == "M")
                {
                    Console.Write("Introduce el tiempo mínimo de ciclo (s): ");
                    int tiempoMin = int.Parse(Console.ReadLine());
                    Console.Write("Introduce el tiempo máximo de ciclo (s): ");
                    int tiempoMax = int.Parse(Console.ReadLine());
                    Console.Write("Introduce el tiempo de mantenimiento (s): ");
                    int tiempoMantenimiento = int.Parse(Console.ReadLine());
                    listaEstaciones.Add(new EstacionManual(tiempoMin, tiempoMax, tiempoMantenimiento));
                    Console.WriteLine("Estación manual añadida a la línea.\n");
                    contadorEstacionesManuales++;
                    System.Threading.Thread.Sleep(1000);
                }
                else if (tipoEstacion == "A")
                {
                    Console.Write("Introduce el tiempo de ciclo (s): ");
                    int tiempoOperacion = int.Parse(Console.ReadLine());
                    Console.Write("Introduce el tiempo de mantenimiento (s): ");
                    int tiempoMantenimiento = int.Parse(Console.ReadLine());
                    listaEstaciones.Add(new EstacionAutomatica(tiempoOperacion, tiempoMantenimiento));
                    Console.WriteLine("Estación automática añadida a la línea.\n");
                    contadorEstacionesAutomaticas++;
                    System.Threading.Thread.Sleep(1000);
                }
            }

            Console.WriteLine("\nIntroduce los datos de la cinta transportadora:");
            Console.Write("Velocidad nominal (m/s): ");
            int velocidadNominal = int.Parse(Console.ReadLine());
            Console.Write("Velocidad máxima (m/s): ");
            int velocidadMaxima = int.Parse(Console.ReadLine());
            Console.Write("Distancia entre máquinas (m): ");
            int distancia = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Cinta = new Cinta(velocidadNominal, velocidadMaxima, distancia);
            System.Threading.Thread.Sleep(1000);
        }

        public double SimulacionIdeal()
        {
            double tiempoTotal = 0;
            double velocidad = Cinta.VelocidadMaxima;

            Console.Write("Ingrese un nombre para la simulacion: ");
            string nombre = Console.ReadLine();

            foreach (var estacion in listaEstaciones)
            {
                if (estacion is EstacionAutomatica)
                {
                    tiempoTotal += estacion.TiempoCiclo;
                }
                else if (estacion is EstacionManual EstacionManual)
                {
                    tiempoTotal += EstacionManual.TiempoCicloMinimo;
                }
                tiempoTotal += Math.Round(Cinta.DistanciaEstaciones / velocidad,2);
                estacion.RealizarOperacion();
            }

            listaResultados.Add(new Resultado(nombre,"Ideal", contadorEstacionesManuales, contadorEstacionesAutomaticas, tiempoTotal));
            return tiempoTotal;
        }

        public double SimulacionEstandar()
        {
            double tiempoTotal = 0;
            double velocidad = Cinta.VelocidadNominal;

            Console.Write("Ingrese un nombre para la simulacion: ");
            string nombre = Console.ReadLine();

            foreach (var estacion in listaEstaciones)
            {
                if (estacion is EstacionAutomatica)
                {
                    tiempoTotal += estacion.TiempoCiclo;
                }
                else if (estacion is EstacionManual)
                {
                    tiempoTotal += estacion.TiempoCiclo;
                }
                tiempoTotal += Math.Round(Cinta.DistanciaEstaciones / velocidad,2);
                estacion.RealizarOperacion();
            }

            listaResultados.Add(new Resultado(nombre,"Estandar", contadorEstacionesManuales, contadorEstacionesAutomaticas, tiempoTotal));
            return tiempoTotal;
        }

        public double SimulacionCritico()
        {
            Console.Write("Ingrese un nombre para la simulacion: ");
            string nombre = Console.ReadLine();

            double tiempoTotal = 0;
            double velocidad = Cinta.VelocidadNominal;

            foreach (var estacion in listaEstaciones)
            {
                if (estacion is EstacionAutomatica)
                {
                    tiempoTotal += estacion.TiempoCiclo;
                }
                else if (estacion is EstacionManual EstacionManual)
                {
                    tiempoTotal += EstacionManual.TiempoCicloMaximo;
                }
                tiempoTotal += Math.Round(Cinta.DistanciaEstaciones / velocidad,2);
                estacion.RealizarOperacion();
            }
            listaResultados.Add(new Resultado(nombre,"Critico", contadorEstacionesManuales, contadorEstacionesAutomaticas, tiempoTotal));
            return tiempoTotal;
        }

        public double SimulacionFallo()
        {
            Console.Write("Ingrese un nombre para la simulacion: ");
            string nombre = Console.ReadLine();

            double tiempoTotal = 0;
            double velocidad = Cinta.VelocidadNominal;

            Console.WriteLine("Indica la máquina que ha fallado (índice): ");
            int indiceFallo = int.Parse(Console.ReadLine())-1;

            foreach (var estacion in listaEstaciones)
            {
                if (listaEstaciones.IndexOf(estacion) == indiceFallo)
                {
                    tiempoTotal += estacion.TiempoMantenimiento;
                    estacion.RealizarMantenimiento();
                }            
                if (estacion is EstacionAutomatica)
                {
                    tiempoTotal += estacion.TiempoCiclo;
                }
                else if (estacion is EstacionManual EstacionManual)
                {
                    tiempoTotal += EstacionManual.TiempoCiclo;
                }
                tiempoTotal += Math.Round(Cinta.DistanciaEstaciones / velocidad,2);
                estacion.RealizarOperacion();
            }
            listaResultados.Add(new Resultado(nombre,$"Fallo en estación {indiceFallo+1}", contadorEstacionesManuales, contadorEstacionesAutomaticas, tiempoTotal));
            return tiempoTotal;
        }

        public double SimulacionCambioVelocidad()
        {
            Console.Write("Ingrese un nombre para la simulacion: ");
            string nombre = Console.ReadLine();
            
            Console.Write("Introduce la velocidad de la cinta (m/s):");

            double velocidad = double.Parse(Console.ReadLine());

            double tiempoTotal = 0;

            foreach (var estacion in listaEstaciones)
            {
                if (estacion is EstacionAutomatica)
                {
                    tiempoTotal += estacion.TiempoCiclo;
                }
                else if (estacion is EstacionManual)
                {
                    tiempoTotal += estacion.TiempoCiclo;
                }
                tiempoTotal += Math.Round(Cinta.DistanciaEstaciones / velocidad,2);
                estacion.RealizarOperacion();
            }

            listaResultados.Add(new Resultado(nombre,$"Velocidad determinada {velocidad} m/s", contadorEstacionesManuales, contadorEstacionesAutomaticas, tiempoTotal));
            return tiempoTotal;
        }
        

        // Método para mostrar la lista de perfiles creados
        public void MostrarResultados()
        {
            Console.WriteLine("\nLista de resultados:");

            if (listaResultados.Count > 0)
            {
                foreach (var resultado in listaResultados)
                {
                    Console.WriteLine($"- {resultado.NombreSimulacion} ({resultado.TipoSimulacion}): Número de estaciones automáticas: {resultado.NumeroEstacionesAutomaticas}, Numero de estaciones manuales: {resultado.NumeroEstacionesManuales}, Tiempo total de producción: {resultado.TiempoTotalProduccion}s.");
                }
            }
            else
            {
                Console.WriteLine("No hay resultados de simulación.");
            }
        }
    }
}