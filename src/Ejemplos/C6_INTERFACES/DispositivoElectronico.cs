namespace Ejemplos.C6_INTERFACES
{
    public abstract class DispositivoElectronico
    {
        // Atributos privados
        private bool estado;
        private string dispositivoID;
        private static int contadorDispositivos = 0;
        
        // Propiedad para acceder al estado del dispositivo
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        // Propiedad (solo lectura) para obtener el id del dispositivo
        public string DispositivoID
        {
            get { return dispositivoID; }
        }

        // Propiedad automática para el fabricante
        public string Fabricante { get; set; }

        // Constructores
        public DispositivoElectronico(string dispositivoID, bool estado)  
        {
            contadorDispositivos++;
            this.dispositivoID = dispositivoID;
            this.estado = estado;
        }
        public DispositivoElectronico(string dispositivoID, string fabricante) : this(dispositivoID, false)
        {
            Fabricante = fabricante;
        }

        // Método estático para obtener el número de dispositivos
        public static void ObtenerTotalDispositivos()
        {
            Console.WriteLine($"Hay {contadorDispositivos} dispositivos en el sistema.");
        }

        // Métodos abstractos para activar/desactivar el dispositivo
        public abstract  void Activar();
        public abstract void Desactivar();

        // Representación textual de la información del objeto
        public override string ToString()
        {
            return $"ID: {dispositivoID}, Estado: {estado}";
        }
    }
}