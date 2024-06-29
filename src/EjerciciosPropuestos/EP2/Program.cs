using EP2;

class Program
{
    static void Main()
    {
        // Crear instancias de RobotSoldadura y RobotPintura
        RobotSoldadura robotSoldadura1 = new RobotSoldadura("ModeloA");
        RobotPintura robotPintura1 = new RobotPintura("ModeloB");
        
        // Crear lista de piezas
        List<Pieza> piezas = new List<Pieza>();
     
        // Crear algunas piezas con diferentes necesidades
        Pieza pieza1 = new Pieza("Chasis", necesitaSoldadura: true, necesitaPintura: true);
        Pieza pieza2 = new Pieza("Tapacubos", necesitaSoldadura: false, necesitaPintura: true);
        Pieza pieza3 = new Pieza("SoporteMotor", necesitaSoldadura: true, necesitaPintura: false);

        // Agregar piezas a la lista
        piezas.Add(pieza1);
        piezas.Add(pieza2);
        piezas.Add(pieza3);

        // Simulación de producción
        Console.WriteLine("Simulación de trabajo en la fábrica:");

        foreach (var pieza in piezas)
        {
            Console.WriteLine($"\nProcesando {pieza.Tipo}:");
            if (pieza.NecesitaSoldadura)
            {
                robotSoldadura1.RealizarTarea();
                pieza.Soldada = true;
            }
            if (pieza.NecesitaPintura)
            {
                robotPintura1.RealizarTarea();
                pieza.Pintada = true;
            }
            // Mostrar el estado final de la pieza
            Console.WriteLine($"Fin del procesamiento de la pieza {pieza.Tipo}.");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine(); // Separador para claridad
        }

        Console.WriteLine("Información sobre las piezas:");
        foreach (var pieza in piezas)
        {
            Console.WriteLine(pieza);
        }
    }
}
