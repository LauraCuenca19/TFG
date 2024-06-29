namespace EP2;

public class RobotPintura : Robot
{
    public RobotPintura(string modelo) : base(modelo)
    {
    }

    public override void RealizarTarea()
    {
        Console.WriteLine($"Robot de pintura {Modelo} está aplicando pintura.");
        // Lógica simulada de pintura
        Console.WriteLine("Aplicando capa base de pintura...");
        System.Threading.Thread.Sleep(4000);
        Console.WriteLine("Pintura aplicada correctamente.");
    }
}

