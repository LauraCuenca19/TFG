namespace Ejemplos.C5_ENCAPSULAMIENTO
{
    class Program
    {
        static void Main()
        {
            // Instanciar objeto de Dispositivo
            Dispositivo sensor1 = new Dispositivo("00000","ModeloA",DateTime.Today);

            // Acceso a atributo público desde fuera de la clase
            sensor1.fechaMantenimiento = new DateTime(2024, 9, 1, 10, 0, 0);

            // Acceso a métodos públicos desde fuera de la clase
            sensor1.MostrarFechaDeMantenimiento();

            sensor1.DemostrarAccesoDesdeClase();

            // Los siguientes accesos no son posibles:
            // sensor1.numeroDeSerie = "11111";  // Error: 'numeroDeSerie' is inaccessible due to its protection level
            // sensor1.MostrarNumeroDeSerie();    // Error: 'MostrarNumeroDeSerie' is inaccessible due to its protection level
            // sensor1.MostrarModelo();    // Error: 'MostraModelo' is inaccessible due to its protection level
        }
    }
}