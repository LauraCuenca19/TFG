public class DispositivoElectronico
{
    // Atributos privados
    private string numeroDeSerie;

    // Atributo protegido
    protected string modelo;

    // Atributo público
    public DateTime fechaMantenimiento;

    // Constructor con parámetros
    public DispositivoElectronico(string numSerie, string modeloDispositivo, DateTime fechaDeMantenimiento)
    {
        numeroDeSerie = numSerie;
        modelo = modeloDispositivo;
        fechaMantenimiento = fechaDeMantenimiento;
        Console.WriteLine("Dispositivo con valores especificados.");
    }

    // Método privado para mostrar el número de serie
    private void MostrarNumeroDeSerie()
    {
        Console.WriteLine($"Número de Serie: {numeroDeSerie}");
    }

    // Método protegido para mostrar el modelo
    protected void MostrarModelo()
    {
        Console.WriteLine($"Modelo: {modelo}");
    }

    // Método público para mostrar la fecha de mantenimiento
    public void MostrarFechaDeMantenimiento()
    {
        Console.WriteLine($"Fecha de Mantenimiento: {fechaMantenimiento}");
    }

    public void DemostrarAccesoDesdeClase()
    {
        // Acceso a atributos y métodos desde dentro de la clase
        numeroDeSerie = "12345";
        modelo = "ModeloX";
        fechaMantenimiento = new DateTime(2024, 10, 25);;

        Console.WriteLine("Demostración de acceso desde la clase:");
        MostrarNumeroDeSerie();
        MostrarModelo();
        MostrarFechaDeMantenimiento();

        // Todos los miembros son accesibles desde aquí 
        // No presentan ningún error en este punto del código
    }
}