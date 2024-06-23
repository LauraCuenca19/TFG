public class DispositivoElectronico
{
    // Atributo privado
    private bool estado;
    private string tipoDispositivo;
    
    // Atributo estático para contar dispositivos
    private static int contadorDispositivos = 0;
    
    // Propiedad pública para acceder al estado del dispositivo
    public bool Estado
    {
        get { return estado; }
        private set { estado = value; }
    }

    // Propiedad pública para acceder al tipo del dispositivo
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

    // Constructor para inicializar tipo y fabricante
    public DispositivoElectronico(string tipo, string fabricante)
    {
        TipoDispositivo = tipo;
        Fabricante = fabricante;
        estado = false;
        contadorDispositivos++;
        Console.WriteLine("Dispositivo con valores especificados.");
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

    // Sobrescritura del método ToString de la clase Object
    public override string ToString()
    {
        return $"Tipo: {tipoDispositivo}, Estado: {estado}";
    }
}