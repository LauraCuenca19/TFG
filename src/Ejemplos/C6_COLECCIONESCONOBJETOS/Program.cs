using MonitorizacionControl;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Crear lista genérica de dispositivos electrónicos
        List<DispositivoElectronico> dispositivos = new List<DispositivoElectronico>();

        // Crear instancias de los dispositivos
        SensorTemperatura sensorTemperatura = new SensorTemperatura("ST1","FabricanteA","°C");
        Ventilador ventilador = new Ventilador("V1", "FabricanteB", 475, 20);
        ValvulaCompuerta valvulaCompuerta = new ValvulaCompuerta("VC1","FabricanteC");
        SensorHumedad sensorHumedad = new SensorHumedad("SH1","FabricanteA","%");

        // Añadir los dispositivos a la lista
        dispositivos.Add(sensorTemperatura);
        dispositivos.Add(ventilador);
        dispositivos.Add(valvulaCompuerta);
        dispositivos.Add(sensorHumedad);

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
            if (dispositivo is Sensor s)
            {
                s.Calibrar();
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
            // Unhandled exception. System.InvalidCastException: Unable to cast object of type 'ValvulaCompuerta' to type 'IModo'.
        } 
        */

        // Iterar sobre la lista y activar el modo automático de dispositivos que implementan IModo
        Console.WriteLine("\nActivar modo automático:");
        foreach (var dispositivo in dispositivos)
        {
            if (dispositivo is IModo modoDispositivo)
            {
                if (dispositivo is Ventilador v)
                {
                    // Asignar la temperatura del sensor al ventilador
                    v.TemperaturaInput = sensorTemperatura.Temperatura;
                }
                modoDispositivo.ModoAutomatico();
                Console.WriteLine();
            }
        }

        // Iterar sobre la lista y mostrar información de cada dispositivo
        Console.WriteLine("\nInformación de los dispositivos:");
        foreach (var dispositivo in dispositivos)
        {
            Console.WriteLine(dispositivo);
        }
    }
}