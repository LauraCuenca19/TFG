namespace Ejemplos.C4_CLASEYOBJETO
{
    public class DispositivoElectronico
    {
        // Atributos privados
        private bool estado;
        private string tipoDispositivo;
        private string dispositivoID;
        private static int contadorDispositivos = 0; // atributo estático
        
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

        // Propiedad para acceder al tipo del dispositivo
        public string TipoDispositivo
        {
            get { return tipoDispositivo; }
            set { 
                if (value == "Sensor" || value == "Actuador")
                {
                    tipoDispositivo = value; 
                } 
                else 
                {
                    Console.WriteLine("El tipo de dispositivo electrónico no es válido.");
                    tipoDispositivo = "Por determinar";
                }
            }
        }

        // Propiedad automática para el fabricante
        public string Fabricante { get; set; }

        // Constructor con parámetro para inicializar ID y estado
        public DispositivoElectronico(string dispositivoID, bool estado)  
        {
            contadorDispositivos++;
            this.dispositivoID = dispositivoID;
            this.estado = estado;
            Console.WriteLine("Dispositivo con ID y estado especificados.");
        }
        
        // Constructor que reutiliza lógica del otro constructor e inicializa tipo y fabricante
        public DispositivoElectronico(string tipoDispositivo, string fabricante, string dispositivoID) : this(dispositivoID, false)
        {
            TipoDispositivo = tipoDispositivo;
            Fabricante = fabricante;
            Console.WriteLine("Dispositivo con tipo y fabricante especificados.");
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
    }
}