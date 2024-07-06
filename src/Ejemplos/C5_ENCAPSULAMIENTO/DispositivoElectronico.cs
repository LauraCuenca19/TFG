namespace Ejemplos.C5_ENCAPSULAMIENTO
{
    public class Dispositivo
    {
        // Atributo privado
        private string numeroDeSerie;

        // Atributo protegido
        protected string modeloDispositivo;

        // Atributo público
        public DateTime fechaMantenimiento;

        // Constructor
        public Dispositivo(string numeroDeSerie, string modeloDispositivo, DateTime fechaMantenimiento)
        {
            this.numeroDeSerie = numeroDeSerie;
            this.modeloDispositivo = modeloDispositivo;
            this.fechaMantenimiento = fechaMantenimiento;
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
            Console.WriteLine($"Modelo: {modeloDispositivo}");
        }

        // Método público para mostrar la fecha de mantenimiento
        public void MostrarFechaDeMantenimiento()
        {
            Console.WriteLine($"Fecha de Mantenimiento: {fechaMantenimiento}");
        }

        // Método público para acceder a miembros de la clase
        public void DemostrarAccesoDesdeClase()
        {
            // Acceso a atributos y métodos desde dentro de la clase
            numeroDeSerie = "12345";
            modeloDispositivo = "ModeloX";
            fechaMantenimiento = new DateTime(2024, 10, 25, 10, 0, 0);

            Console.WriteLine("Demostración de acceso desde la clase:");
            MostrarNumeroDeSerie();
            MostrarModelo();
            MostrarFechaDeMantenimiento();

            // Todos los miembros son accesibles desde aquí 
            // No presentan ningún error en este punto del código
        }
    }
}