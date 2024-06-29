namespace EP3;

public class RobotSoldadura : Robot
{
    public RobotSoldadura(string modelo) : base(modelo)
    {
    }

    public override void RealizarTarea()
    {
        Console.WriteLine($"Robot de soldadura {Modelo} está realizando soldadura.");
        // Lógica simulada de soldadura
        Console.WriteLine("Proceso de soldadura en curso...");
        System.Threading.Thread.Sleep(2000);
        Console.WriteLine("Soldadura completa.");
    }
}
