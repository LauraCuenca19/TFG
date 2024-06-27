namespace ActividadesResueltas.AR5_POLIMORFISMODINAMICO
{
    public class DispositivoElectronico
    {
        // Atributos privados
        private bool estado;
        private string dispositivoID;
        private static int contadorDispositivos = 0;
        
        // Propiedad para acceder al estado del dispositivo
        public bool Estado
        {
            get { return estado; }
            private set { estado = value; }
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

        // Método público para activar el dispositivo
        public void Activar()
        {
            Estado = true;
            Console.WriteLine("El dispositivo se ha activado.");
        }

        // Método público para desactivar el dispositivo
        public void Desactivar()
        {
            Estado = false;
            Console.WriteLine("El dispositivo se ha desactivado.");
        }

        // Representación textual de la información del objeto
        public override string ToString()
        {
            return $"ID: {dispositivoID}, Estado: {estado}";
        }
    }
}