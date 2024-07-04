using Sensores;
using Actuadores;

namespace ControlIluminacion
{
    public class ControladorDeLuces
    {
        private List <Luz> luces;
        private List <Sensor> sensores;

        public ControladorDeLuces()
        {
            sensores = new List<Sensor>();
            luces = new List<Luz>();
        }

        public void AgregarPuntosControl()
        {
            // Creamos los puntos de control: con un sensor de movimiento y uno de luz.
            // En cada punto se ubica también una Luz (una lámpara).

            Console.WriteLine("¿Cuantos puntos de control hay en el sistema (número de sensores de movimiento y de luz)?:");
            int numSensores = Int32.Parse(Console.ReadLine());
            string ubicacion;
            string idSensorLuz, idSensorMov, idLuz;

            for (int i = 0; i < numSensores; i++)
            {
                Console.WriteLine($"\nPunto de control {i+1}:");
                Console.WriteLine("Indica la ubicación:");
                ubicacion = Console.ReadLine();
                Console.WriteLine("Indica el id del sensor de luz:");
                idSensorLuz = Console.ReadLine();
                Console.WriteLine("Indica el id del sensor de movimiento:");
                idSensorMov = Console.ReadLine();
                sensores.Add(new SensorDeLuz(idSensorLuz, ubicacion));
                sensores.Add(new SensorDeMovimiento(idSensorMov, ubicacion));
                Console.WriteLine("Indica el id de la luz:");
                idLuz = Console.ReadLine();
                luces.Add(new Luz(idLuz, ubicacion));
            }
        }

        public void ControlAutomaticoLuces()
        {
            int posicionActual = 0;
            double intensidad = 0;
            bool accionEnLuz = false;
            bool estado = false;
            // Leer valores de los sensores
            foreach (Sensor sensor in sensores)
            {
                sensor.LeerValor();
                System.Threading.Thread.Sleep(1000);
                if (sensor is SensorDeLuz)
                {
                    intensidad = ((SensorDeLuz)sensor).IntensidadLuz;
                    accionEnLuz = false;
                }
                if (sensor is SensorDeMovimiento)
                {
                    
                    posicionActual = sensores.IndexOf(sensor)/2;
                    accionEnLuz = true;
                    estado = ((SensorDeMovimiento)sensor).Estado;
                }

                if (accionEnLuz)
                {
                    if (estado && intensidad < 30)
                    {
                        EncenderLuces(luces[posicionActual]);
                    }
                    // Ajustar intensidad según la luz natural
                    else if (estado && intensidad >= 30 && intensidad < 75)
                    {
                        AjustarIntensidad(luces[posicionActual], 100 - intensidad); // Ajustar a una intensidad media
                    }
                    else
                    {
                        ApagarLuces(luces[posicionActual]);
                    }
                }
            }
        }

        private void EncenderLuces(Luz luz)
        {
            luz.CambiarIntensidad(100);
            Console.WriteLine($"Luz en {luz.Ubicacion} encendida.");
            System.Threading.Thread.Sleep(1000);
        }

        private void ApagarLuces(Luz luz)
        {
            luz.CambiarIntensidad(0);
            Console.WriteLine($"Luz en {luz.Ubicacion} apagada.");
            System.Threading.Thread.Sleep(1000);
        }

        private void AjustarIntensidad(Luz luz, double intensidad)
        {
            luz.CambiarIntensidad(intensidad);
            System.Threading.Thread.Sleep(1000);
        }
    }
}