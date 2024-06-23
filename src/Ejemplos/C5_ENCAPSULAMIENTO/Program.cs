class Program
{
    static void Main()
    {
        DispositivoElectronico sensor1 = new DispositivoElectronico("00000","ModeloA",DateTime.Today);

        // Acceso a atributo público desde fuera de la clase
        sensor1.fechaMantenimiento = new DateTime(2024, 9, 1);

        // Acceso a métodos públicos desde fuera de la clase
        sensor1.MostrarFechaDeMantenimiento();

        sensor1.DemostrarAccesoDesdeClase();

        // Los siguientes accesos no son posibles:
        // sensor1.numeroDeSerie = "MarcaNueva";  // Error: 'numeroDeSerie' is inaccessible due to its protection level
        // sensor1.MostrarNumeroDeSerie();    // Error: 'MostrarNumeroDeSerie' is inaccessible due to its protection level
        // sensor1.modelo = "NuevoModelo";  // Error: 'modelo' is inaccessible due to its protection level
        // sensor1.MostrarModelo();    // Error: 'MostraModelo' is inaccessible due to its protection level
    }
}