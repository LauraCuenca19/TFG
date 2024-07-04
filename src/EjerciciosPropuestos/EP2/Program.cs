using ControlIluminacion;

public class Program
{
    public static void Main()
    {
        // Crear el controlador de luces
        ControladorDeLuces controlador = new ControladorDeLuces();

        // Crear sistema de sensores y luces:
        controlador.AgregarPuntosControl();

        controlador.ControlAutomaticoLuces();
    }
}

