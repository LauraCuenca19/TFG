using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Crear lista genérica de dispositivos electrónicos
        List<DispositivoElectronico> dispositivos = new List<DispositivoElectronico>();

        // Crear instancias de los dispositivos
        SensorTemperatura sensorTemperatura1 = new SensorTemperatura("Honeywell", "°C");
        Ventilador ventilador1 = new Ventilador("Magnovent", 475, 25);
        ValvulaCompuerta valvulaCompuerta1 = new ValvulaCompuerta("Flomatic");

        // Añadir los dispositivos a la lista
        dispositivos.Add(sensorTemperatura1);
        dispositivos.Add(ventilador1);
        dispositivos.Add(valvulaCompuerta1);

        // Iterar sobre la lista y mostrar información de cada dispositivo
        Console.WriteLine("\nInformación de los dispositivos:");
        foreach (var dispositivo in dispositivos)
        {
            Console.WriteLine(dispositivo);
        }

        // Iterar sobre la lista y activar dispositivos
        Console.WriteLine("\nActivación de los dispositivos:");
        foreach (var dispositivo in dispositivos)
        {
            dispositivo.Activar();
            if (dispositivo is Sensor sensor)
            {
                sensor.Calibrar();
            }
            Console.WriteLine();
        }

        // Iterar sobre la lista y mostrar información de cada dispositivo
        Console.WriteLine("\nInformación de los dispositivos:");
        foreach (var dispositivo in dispositivos)
        {
            Console.WriteLine(dispositivo);
        }

        /* 
        // Activar directamente el modo automático en cada dispositivo
        foreach (IModo dispositivo in dispositivos)
        {
            dispositivo.ModoAutomatico();
        } 
        */

        // Iterar sobre la lista y activar el modo automático de dispositivos que implementan IModo
        Console.WriteLine("\nActivar modo automático:");
        foreach (var dispositivo in dispositivos)
        {
            if (dispositivo is IModo modoDispositivo)
            {
                if (dispositivo is Ventilador ventilador)
                {
                    // Asignar la temperatura del sensor al ventilador
                    ventilador.TemperaturaInput = sensorTemperatura1.Temperatura;
                }
                modoDispositivo.ModoAutomatico();
            }
            Console.WriteLine();
        }
        
        // Iterar sobre la lista y mostrar información de cada dispositivo
        Console.WriteLine("\nInformación de los dispositivos:");
        foreach (var dispositivo in dispositivos)
        {
            Console.WriteLine(dispositivo);
        }
    }
}
