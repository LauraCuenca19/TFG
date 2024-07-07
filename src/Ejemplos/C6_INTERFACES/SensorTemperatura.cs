namespace Ejemplos.C6_INTERFACES
{
    public class SensorTemperatura : Sensor, IModo
    {
        // Atributos privados
        private double temperatura;
        private bool modoAuto;

        // Implementación propiedad ModoAuto de la interfaz IModo
        public bool ModoAuto 
        { 
            get {return modoAuto;} 
            set
            {
                if(!Estado)
                {
                    Console.WriteLine("No se puede cambiar el modo de funcionamiento porque el sensor está apagado.");
                }
                else if (!Calibrado)
                {
                    Console.WriteLine("No se puede cambiar el modo de funcionamiento con el sensor sin calibrar.");
                }
                else
                {
                    modoAuto = value;
                    if (modoAuto)
                    {
                        Console.WriteLine($"{DispositivoID} operando en modo automático.");
                    }
                    else
                    {
                        Console.WriteLine($"{DispositivoID} operando en modo manual.");
                    }
                }
            } 
        }

        // Propiedad para la temperatura con validación en el setter
        public double Temperatura
        {
            get { return temperatura; }
            set
            {
                // Verifica si el sensor está encendido
                if (!Estado)
                {
                    Console.WriteLine("Error: El sensor no está encendido. No se puede actualizar la temperatura.");
                }
                else
                {
                    // Verifica si el sensor está calibrado
                    if (!Calibrado)
                    {
                        Console.WriteLine("Error: El sensor no está calibrado. No se puede actualizar la temperatura.");
                    }
                    // Verifica si el valor está dentro del rango permitido
                    else if (value < 0 || value > 100)
                    {
                        Console.WriteLine("Error: Valor de temperatura fuera de rango válido (0 a 100).");
                    }
                    else
                    {
                        // Actualiza el valor de la temperatura
                        temperatura = value;
                        Console.WriteLine("Temperatura actualizada.");
                    }
                }
            }
        }

        // Constructor que inicializa el sensor con tipo "Temperatura"
        public SensorTemperatura(string dispositivoID, string fabricante, string unidadMedida) : base(dispositivoID, fabricante, unidadMedida)
        {
            // Inicializa la temperatura a 0.0
            temperatura = 0.0;
        }

        // Método Calibrar sobrescrito
        public override void Calibrar()
        {
            base.Calibrar(); // Llamada al método Calibrar de clase base
            if (Calibrado)
            {      
                Console.WriteLine("Calibrando sensor de temperatura...");
                // Lógica de calibración específica sensor de temperatura
                double[] lecturas = new double[5];
                double suma = 0;

                // Simula la lectura de 5 valores de temperatura
                for (int i = 0; i < lecturas.Length; i++)
                {
                    ObtenerValor();
                    lecturas[i] = Temperatura;
                    Console.WriteLine($"Lectura {i + 1}: {lecturas[i]:F2}{unidadMedida}");
                    suma += lecturas[i];
                    System.Threading.Thread.Sleep(500); // Simulación tiempo entre lecturas
                }

                double promedio = suma / lecturas.Length;
                Console.WriteLine($"Promedio de lecturas: {promedio:F2}{unidadMedida}");

                // Lógica de ajuste del sensor
                Console.WriteLine("Ajustando sensor de temperatura...");
                System.Threading.Thread.Sleep(2000); // Simulación tiempo de ajuste
                temperatura = Math.Round(promedio,2);
                Console.WriteLine("Sensor de temperatura ajustado y calibrado.");
            }
            else
            {
                Console.WriteLine("Error de calibración.");
            }
        }

        public override void ObtenerValor()
        {
            Random rand = new Random();
            // Genera un valor aleatorio entre 10 y 30
            Medida = Math.Round(10 + rand.NextDouble() * 20, 2);
            Temperatura = Medida;
        }

        // Representación textual de la información del objeto
        public override string ToString()
        {
            return base.ToString() + $", Temperatura actual: {temperatura}{unidadMedida}";
        }

        // Implementación método ModoAutomatico de la interfaz IModo
        public void ModoAutomatico()
        {
            ModoAuto = true;
            // Lógica de modo automático
            while (ModoAuto)
            {
                Console.WriteLine($"[Modo Automático]");
                Medir(5);
                // Verificar si se debe continuar en modo automático
                Console.WriteLine("¿Desea continuar en modo automático? (si/no): ");
                var respuesta = Console.ReadLine();
                if (respuesta.ToLower() != "si")
                {
                    ModoAuto = false;
                }
            }
        }
    }
}