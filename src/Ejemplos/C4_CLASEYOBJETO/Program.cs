namespace Ejemplos.C4_CLASEYOBJETO
{
    class Program
    {
        static void Main()
        {
            DispositivoElectronico.ObtenerTotalDispositivos();

            Console.WriteLine("\nSensor1:");
            // Creación objeto sensor1 de la clase DispositivoElectronico
            DispositivoElectronico sensor1 = new DispositivoElectronico("Sensor","Honeywell","s1");
            DispositivoElectronico.ObtenerTotalDispositivos();

            Console.WriteLine("\nActuador1:");
            // Creación objeto actuador1 de la clase DispositivoElectronico
            DispositivoElectronico actuador1 = new DispositivoElectronico("a1", true);
            DispositivoElectronico.ObtenerTotalDispositivos();

            // Interacción con el objeto sensor1
            Console.WriteLine($"\nSensor1 - ID: {sensor1.DispositivoID}, Tipo de Dispositivo: {sensor1.TipoDispositivo}, Fabricante: {sensor1.Fabricante}, Operativo: {sensor1.Estado}");
            sensor1.Activar();
            Console.WriteLine($"Sensor1 - Estado después de activar: {sensor1.Estado}");

            // Interacción con el objeto actuador1
            actuador1.TipoDispositivo = "Actuador";
            actuador1.Fabricante = "Siemens";
            Console.WriteLine($"\nActuador1 - ID: {actuador1.DispositivoID}, Tipo de Dispositivo: {actuador1.TipoDispositivo}, Fabricante: {actuador1.Fabricante}, Operativo: {actuador1.Estado}");
            actuador1.Desactivar();
            Console.WriteLine($"Actuador1 - Estado después de desactivar: {actuador1.Estado}");
        }
    }
}