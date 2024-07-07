using System.Collections.Generic; // Espacio de nombres que contiene las colecciones genéricas

public class Program
{
    public static void Main()
    {
        // **************************************************
        // ***************** LIST<T> ************************
        // **************************************************

        Console.WriteLine("*****************");
        Console.WriteLine("**** LIST<T> ****");
        Console.WriteLine("*****************\n");

        // Crear una lista de string
        List<string> lista = new List<string>();

        // Mostrar capacidad de la lista
        Console.WriteLine($"Capacidad inicial: {lista.Capacity}");

        // Añadir elementos
        lista.Add("Resistencia");
        lista.Add("Condensador");
        lista.Add("Bobina");

        // Mostrar capacidad de la lista
        Console.WriteLine($"Capacidad: {lista.Capacity}"); 
        
        // Contar el número de elementos en la lista
        Console.WriteLine($"Número de elementos: {lista.Count}");

        // Eliminar elemento especificado
        Console.WriteLine("Eliminamos un elemento.");
        lista.Remove("Condensador");
        
        // Mostrar capacidad de la lista
        Console.WriteLine("Reducimos la capacidad de la lista.");
        lista.TrimExcess();
        Console.WriteLine($"Capacidad: {lista.Capacity}");
        
        // Contar el número de elementos en la lista
        Console.WriteLine($"Número de elementos: {lista.Count}");

        // Recorrer y mostrar los elementos de la lista
        foreach (var componente in lista)
        {
            Console.WriteLine($"Componente: {componente}");
        }

        // ***************************************************
        // ************* DICTIONARY<TKey,TValue> *************
        // ***************************************************

        Console.WriteLine("\n*********************************");
        Console.WriteLine("**** DICTIONARY<TKey,TValue> ****");
        Console.WriteLine("*********************************\n");

        // Crear un diccionario
        Dictionary<string, double> diccionario = new Dictionary<string, double>();

        // Agregar algunos sensores y sus valores iniciales
        diccionario.Add("SensorTemperatura", 22.5); // Temperatura
        diccionario["SensorHumedad"] = 68.5;  // Humedad

        // Leer los valores actuales de los sensores
        Console.WriteLine($"Valor de SensorTemperatura: {diccionario["SensorTemperatura"]}°C");
        Console.WriteLine($"Valor de SensorHumedad: {diccionario["SensorHumedad"]}%");

        // Agregar otro sensor
        diccionario.Add("SensorPresion", 50.0); // Presion

        // Verificar si contiene una clave específica
        if (diccionario.ContainsKey("SensorPresion"))
        {
            Console.WriteLine("El diccionario contiene la clave 'SensorPresion'.");
        }

        // Iterar y mostrar los pares clave-valor
        foreach (var par in diccionario)
        {
            Console.WriteLine($"Clave: {par.Key} - Valor: {par.Value}");
        }

        // ************************************
        // ************* STACK<T> *************
        // ************************************

        Console.WriteLine("\n*********************************");
        Console.WriteLine("************ STACK<T> ************");
        Console.WriteLine("*********************************\n");

        // Crear una pila de piezas
        Stack<string> piezasDespiece = new Stack<string>();
        
        // Agregar piezas a la pila en el orden en que deben colocarse
        piezasDespiece.Push("Base");
        piezasDespiece.Push("Cuerpo");
        piezasDespiece.Push("Cabezal");

        // Mostrar el número de piezas en la pila
        Console.WriteLine($"Piezas: {piezasDespiece.Count}");

        Console.WriteLine("Operación de despiece:");

        // Consultar la última pieza sin eliminarla
        Console.WriteLine($"Pieza actual (Peek): {piezasDespiece.Peek()}");

        // Eliminar y mostrar la última pieza
        Console.WriteLine($"Eliminando y mostrando la pieza eliminada (Pop): {piezasDespiece.Pop()}");

        // Consultar nuevamente la última pieza
        Console.WriteLine($"Pieza actual (Peek): {piezasDespiece.Peek()}");

        // ************************************
        // ************* QUEUE<T> *************
        // ************************************

        Console.WriteLine("\n*********************************");
        Console.WriteLine("************ QUEUE<T> ************");
        Console.WriteLine("*********************************\n");

        // Crear una cola de piezas de ensamblaje
        Queue<string> piezasMontaje = new Queue<string>();

        // Agregar piezas a la cola en el orden en que deben ensamblarse
        piezasMontaje.Enqueue("Base");
        piezasMontaje.Enqueue("Cuerpo");
        piezasMontaje.Enqueue("Cabezal");

        // Mostrar el número de piezas en la cola
        Console.WriteLine($"Piezas en cola: {piezasMontaje.Count}");

        Console.WriteLine("Operación de despiece:");
        
        // Consultar la primera pieza sin eliminarla
        Console.WriteLine($"Pieza actual (Peek): {piezasMontaje.Peek()}");

        // Eliminar y mostrar la primera pieza
        Console.WriteLine($"Procesando y mostrando pieza actual (Dequeue): {piezasMontaje.Dequeue()}");

        // Mostrar el número de piezas en la cola después de un Dequeue
        Console.WriteLine($"Piezas en la cola después de un Dequeue: {piezasMontaje.Count}");

        // Consultar nuevamente la primera pieza
        Console.WriteLine($"Pieza actual (Peek): {piezasMontaje.Peek()}");
    }
}