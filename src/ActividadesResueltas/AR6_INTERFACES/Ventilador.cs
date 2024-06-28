using Ejemplos.C6_INTERFACES;

namespace ActividadesResueltas.AR6_INTERFACES
{
    public class Ventilador : Actuador, IModo, IAjuste
    {
        // Atributo para almacenar la temperatura umbral límite
        public readonly double temperaturaLimite ;

        // Atributo privado para almacenar el modo
        private bool modoAuto;

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
                        Console.WriteLine($"{DispositivoID} operando en modo automático.");
                    }
                    else
                    {
                        Console.WriteLine($"{DispositivoID} operando en modo manual.");
                    }
                }
            } 
        }

        // Propiedad para obtener temperatura
        public double TemperaturaInput { get; set; }

        // Propiedad para obtener o establecer el valor máximo permitido
        public double ValorMax { get; set; }

        // Propiedad para obtener o establecer el valor actual
        public double ValorActual { get; set; }

        // Constructor
        public Ventilador(string dispositivoID, string fabricante, double valormaximo, double temperaturaLimite) : base(dispositivoID, fabricante)
        {
            ValorMax = valormaximo;
            ValorActual = 0.0;
            modoAuto = false;
            this.temperaturaLimite = temperaturaLimite;
        }

        // Método público para activar el ventilador
        public override void Activar()
        {
            Estado = true;
            AjusteDirecto(ValorMax/2);
            Console.WriteLine("El ventilador se ha activado.");
        }

        // Método público para desactivar el ventilador
        public override void Desactivar()
        {
            modoAuto = false;
            Estado = false;
            ValorActual = 0.0;
            Console.WriteLine("El ventilador se ha desactivado.");
        }

        // Sobrescritura del método ToString de la clase Object
        public override string ToString()
        {
            return base.ToString() + $", ModoAuto: {ModoAuto}";
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
                    } else ModoAuto = false;
                } else Desactivar(); // Código para desactivar el ventilador
                // Esperar un poco antes de la siguiente verificación
                System.Threading.Thread.Sleep(2000);
            }
        }

        // Implementación método AjusteDirecto de la interfaz IAjuste
        public void AjusteDirecto(double velocidad)
        {
            if (Estado)
            {
                if (velocidad < 0 || velocidad > ValorMax)
                {
                    Console.WriteLine("El valor debe estar entre el mínimo y el máximo permitido.");
                }
                else if (velocidad == 0) 
                {
                    
                    ValorActual = 0;
                }
                else ValorActual = velocidad;
            } else Console.WriteLine("El ventilador está apagado.");
            
        }

        // Implementación método AjusteProporcional de la interfaz IAjuste
        public void AjusteProporcional(int porcentaje)
        {
            if (Estado)
            {
                // Calcular la nueva velocidad en función del porcentaje
                double nuevaVelocidad = (ValorMax - ValorActual) * (porcentaje / 100.0);
                
                // Asegurarse de que la nueva velocidad esté dentro de los límites permitidos
                if (nuevaVelocidad < 0) nuevaVelocidad = 0;
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
}