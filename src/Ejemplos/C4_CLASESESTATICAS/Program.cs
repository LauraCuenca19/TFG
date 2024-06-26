namespace Ejemplos.C4_CLASESESTATICAS
{
    class Program
    {
        static void Main()
        {
            // Declaración de variables
            double numero = 16.0;

            // Math.Sqrt para calcular la raíz cuadrada
            double raizCuadrada = Math.Sqrt(numero);
            Console.WriteLine($"La raíz cuadrada de {numero} es {raizCuadrada}.");

            // Math.Pow para calcular la potencia
            double potencia = Math.Pow(numero, 2);
            Console.WriteLine($"{numero} elevado a la potencia de 2 es {potencia}.");

            // Math.Max para encontrar el valor máximo entre dos números
            double maximo = Math.Max(numero, potencia);
            Console.WriteLine($"El valor máximo entre {numero} y {potencia} es {maximo}.");
        }
    }
}