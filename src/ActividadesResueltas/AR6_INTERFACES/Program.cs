class Program
{
    static void Main()
    {
        // Crear objeto de la clase ventilador
        Ventilador ventilador = new Ventilador("FabricanteA", 475, 25);
        
        // Activar el ventilador
        ventilador.Activar();

        // Asignar valor a la temperatura de entrada
        ventilador.TemperaturaInput = 30;
        
        // Cambiar a modo automático
        ventilador.ModoAutomatico();

        // Mostrar información del ventilador
        Console.WriteLine(ventilador);

        // Esperar un poco antes de finalizar
        System.Threading.Thread.Sleep(1000); // 1 segundo
        Console.WriteLine("Fin de la prueba.");
    }
}