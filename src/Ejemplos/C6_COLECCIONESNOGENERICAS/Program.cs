using System.Collections; // Espacio de nombres que contiene las colecciones no genéricas

class Program
{
    static void Main()
    {
        // **************************************************
        // ***************** ARRAYLIST **********************
        // **************************************************

        Console.WriteLine("*****************");
        Console.WriteLine("*** ARRAYLIST ***");
        Console.WriteLine("*****************\n");

        // Inicializa lista con diferentes tipos de datos
        ArrayList lista = new ArrayList(){ "Resistencia", 100 };
        
        // Añade más elementos a la lista
        lista.Add("Condensador");
        lista.Add(0.001); // microfaradios

        // Recupera elementos de la lista utilizando índices
        string componente = (string)lista[0]; // Casting
        int valor = (int)lista[1]; // Casting

        // Imprime los elementos recuperados
        Console.WriteLine($"Componente: {componente}"); 
        Console.WriteLine($"Valor: {valor} ohms");

        // Itera sobre la lista utilizando el tipo object
        foreach (object elemento in lista)
        {
            Console.WriteLine($"Elemento: {elemento} en la posición {lista.IndexOf(elemento)+1}.");
        }

        // Itera asumiendo que todos los elementos son strings
        /* foreach (string elemento in lista)
        {
            Console.WriteLine($"Elemento: {elemento} en la posición {lista.IndexOf(elemento)+1}.");
            // Unhandled exception. System.InvalidCastException: Unable to cast object of type 'System.Int32' to type 'System.String'.
        }*/

        // **************************************************
        // ***************** HASTHTABLE *********************
        // **************************************************

        Console.WriteLine("\n*****************");
        Console.WriteLine("*** HASHTABLE ***");
        Console.WriteLine("*****************\n");

        // Crear una hashtable para almacenar los valores de los sensores
        Hashtable tabla = new Hashtable();

        // Agregar algunos sensores y sus valores iniciales
        tabla.Add("SensorTemperatura", 22.5); // Temperatura
        tabla["SensorHumedad"] = 68.5;  // Humedad

        // Leer los valores actuales de los sensores
        Console.WriteLine($"Valor de SensorTemperatura: {tabla["SensorTemperatura"]}°C");
        Console.WriteLine($"Valor de SensorHumedad: {tabla["SensorHumedad"]}%");

        tabla.Add("SensorPresion", 50); // Presion

        foreach(DictionaryEntry par in tabla)
        {
            Console.WriteLine($"Clave: {par.Key} - Valor: {par.Value}");
        }

        // *********************************************
        // ***************** STACK *********************
        // *********************************************

        Console.WriteLine("\n*************");
        Console.WriteLine("*** STACK ***");
        Console.WriteLine("*************\n");

        Stack pila = new Stack();
        
        // Agregar estados a la pila
        pila.Push("Inicialización del sistema");
        pila.Push("Operación normal");
        pila.Push("Modo de mantenimiento");

        // Mostrar el número de estados en la pila
        Console.WriteLine($"Estados en la pila: {pila.Count}");

        // Consultar el último estado sin eliminarlo
        Console.WriteLine($"Estado actual (Peek): {pila.Peek()}");

        // Eliminar y mostrar el último estado
        Console.WriteLine($"Regresando al estado previo (Pop): {pila.Pop()}");

        // Mostrar número de estados en la pila después de un Pop
        Console.WriteLine($"Estados en la pila (tras Pop): {pila.Count}");

        // Consultar nuevamente el último estado
        Console.WriteLine($"Estado actual (Peek): {pila.Peek()}");

        // *********************************************
        // ***************** QUEUE *********************
        // *********************************************

        Console.WriteLine("\n************");
        Console.WriteLine("*** QUEUE ***");
        Console.WriteLine("*************\n");

        Queue<string> cola = new Queue<string>();
        
        // Agregar estados a la cola
        cola.Enqueue("Inicialización del sistema");
        cola.Enqueue("Operación normal");
        cola.Enqueue("Modo de mantenimiento");

        // Mostrar el número de estados en la cola
        Console.WriteLine($"Estados en la cola: {cola.Count}");

        // Consultar el primer estado sin eliminarlo
        Console.WriteLine($"Estado actual (Peek): {cola.Peek()}");

        // Eliminar y mostrar el primer estado
        Console.WriteLine($"Procesando el estado (Dequeue): {cola.Dequeue()}");

        // Mostrar número de estados en la cola después de un Dequeue
        Console.WriteLine($"Estados en la cola: {cola.Count}");

        // Consultar nuevamente el primer estado
        Console.WriteLine($"Estado actual (Peek): {cola.Peek()}");
    }
}