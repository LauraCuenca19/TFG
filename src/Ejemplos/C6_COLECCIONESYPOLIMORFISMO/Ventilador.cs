public class Ventilador : Actuador, IModo, IAjuste
{
    // Atributo para almacenar la temperatura umbral límite
    public readonly double temperaturaLimite ;

    // Atributo privado para almacenar el modo
    private bool modoAuto;

    // Propiedad para indicar si el ventilador en funcionamiento
    public bool Activo { get; private set; }

    // Implementación propiedad ModoAuto de la interfaz IModo
    public bool ModoAuto 
    { 
        get {return modoAuto;} 
        set
        {
            if(!Estado)
            {
                Console.WriteLine("No se puede activar el modo automático porque el actuador está apagado.");
            }
            else
            {
                modoAuto = value;
                if (modoAuto)
                {
                    Console.WriteLine($"{TipoActuador} operando en modo automático.");
                }
                else
                {
                    Console.WriteLine($"{TipoActuador} operando en modo manual.");
                }
            }
        } 
    }

    // Propiedad para obtener temperatura
    public double TemperaturaInput { get; set; }

    // Propiedad para obtener o establecer el valor mínimo permitido
    public double ValorMin { get; set; } = 0.0;

    // Propiedad para obtener o establecer el valor máximo permitido
    public double ValorMax { get; set; }

    // Propiedad para obtener o establecer el valor actual
    public double ValorActual { get; set; }

    // Constructores
    public Ventilador(string fabricante, double valormaximo, double temperatura) : base("Ventilador", fabricante)
    {
        Activo = false;
        ValorMax = valormaximo;
        ValorActual = 0.0;
        modoAuto = false;
        temperaturaLimite = temperatura;
    }

    // Método público para activar el ventilador
    public override void Activar()
    {
        Estado = true;
        Activo = true;
        AjusteDirecto(ValorMax/2);
        Console.WriteLine("El ventilador se ha activado.");
    }

    // Método público para desactivar el ventilador
    public override void Desactivar()
    {
        modoAuto = false;
        Activo = false;
        Estado = false;
        ValorActual = 0.0;
        Console.WriteLine("El ventilador se ha desactivado.");
    }

    // Sobrescritura del método ToString de la clase Object
    public override string ToString()
    {
        return base.ToString() + $", Activo: {Activo}, ModoAuto: {ModoAuto}";
    }

    // Implementación del método ModoAutomatico de la interfaz IModo
    public void ModoAutomatico()
    {
        ModoAuto = true;
    // Lógica de modo automático
        while (ModoAuto)
        {
            if (TemperaturaInput >= temperaturaLimite)
            {
                Console.WriteLine($"[Modo Automático]");
                // Código para activar el ventilador
                AjusteProporcional((int)((TemperaturaInput - temperaturaLimite) * 100 / temperaturaLimite));
                // Verificar si se debe continuar en modo automático
                Console.WriteLine("¿Desea continuar en modo automático? (si/no): ");
                var respuesta = Console.ReadLine();
                if (respuesta?.ToLower() == "si")
                {
                    Console.WriteLine("Inserte nueva temperatura medida:");
                    if (double.TryParse(Console.ReadLine(), out double nuevaTemperatura))
                    {
                        TemperaturaInput = nuevaTemperatura;
                    }
                    else
                    {
                        Console.WriteLine("Temperatura inválida. Saliendo del modo automático.");
                        ModoAuto = false;
                    }
                }
            else ModoAuto = false;
            }
            else
            {
                // Código para desactivar el ventilador
                Desactivar();
            }
            // Esperar un poco antes de la siguiente verificación
            System.Threading.Thread.Sleep(2000);
        }
    }

    // Implementación método AjusteDirecto de la interfaz IAjuste
    public void AjusteDirecto(double velocidad)
    {
        if (Estado == true)
        {
            if (!Activo) Activo = true;
            if (velocidad < ValorMin || velocidad > ValorMax)
            {
                Console.WriteLine("El valor debe estar entre el mínimo y el máximo permitido.");
            }
            else if (velocidad == ValorMin) 
            {
                Activo = false;
                ValorActual = ValorMin;
            }
            else ValorActual = velocidad;
        } else Console.WriteLine("El ventilador está apagado.");
        
    }

    // Implementación método AjusteProporcional de la interfaz IAjuste
    public void AjusteProporcional(int porcentaje)
    {
        if (Activo)
        {
            // Calcular la nueva velocidad en función del porcentaje
            double nuevaVelocidad = ValorMin + (ValorMax - ValorMin) * (porcentaje / 100.0);
            
            // Asegurarse de que la nueva velocidad esté dentro de los límites permitidos
            if (nuevaVelocidad < ValorMin) nuevaVelocidad = ValorMin;
            if (nuevaVelocidad > ValorMax) nuevaVelocidad = ValorMax;

            ValorActual = nuevaVelocidad;
            Console.WriteLine($"La velocidad se ha ajustado a {ValorActual} rpm.");
        }
        else
        {
            Console.WriteLine("El ventilador está apagado.");
        }
    }
}