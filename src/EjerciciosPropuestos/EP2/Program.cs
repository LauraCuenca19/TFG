using EP1;

public class Program
{
    public static void Main()
    {
        // Crear una luz
        Luz luz = new Luz { Id = "LuzLampara" };

        // Crear el controlador de luces
        ControladorDeLuces controlador = new ControladorDeLuces(luz);

        // Crear los sensores
        SensorDeMovimiento sensorMovimiento = new SensorDeMovimiento { Id = "SensorMov1", Ubicacion = "Sala" };
        SensorDeLuz sensorLuz = new SensorDeLuz { Id = "SensorLuz1", Ubicacion = "Sala" };

        // Leer valores de los sensores
        sensorMovimiento.LeerValor();
        sensorLuz.LeerValor();

        // Lógica para controlar las luces
        if (sensorMovimiento.Estado && sensorLuz.IntensidadLuz < 30)
        {
            controlador.EncenderLuces();
        }
        // Ajustar intensidad según la luz natural
        else if (sensorMovimiento.Estado && sensorLuz.IntensidadLuz >= 30 && sensorLuz.IntensidadLuz < 75)
        {
            controlador.AjustarIntensidad(100 - sensorLuz.IntensidadLuz); // Ajustar a una intensidad media
        }
        else
        {
            controlador.ApagarLuces();
        }
    }
}

