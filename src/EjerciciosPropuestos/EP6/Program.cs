using AplicacionInventario;
using EP5;

class Program
{
    static void Main()
    {
        // Crear instancias de Partes
        Parte pata = new Parte("P1", "Pata", 20, 5.0m);
        Parte baseSilla = new Parte("P2", "Base de Silla", 10, 10.0m);
        Parte respaldo = new Parte("P3", "Respaldo", 10, 8.0m);
        Parte baseTaburete = new Parte("P4", "Base de Taburete", 15, 12.0m);

        // Crear instancias de Productos Terminados
        Silla silla = new Silla("PT1", 0, 50.0m);
        Taburete taburete = new Taburete("PT2", 0, 30.0m);

        Inventario inventario = new Inventario();

        inventario.AgregarItem(pata);
        inventario.AgregarItem(baseSilla);
        inventario.AgregarItem(respaldo);
        inventario.AgregarItem(baseTaburete);
        inventario.AgregarItem(silla);
        inventario.AgregarItem(taburete);

        // Mostrar inventario actual de partes y productos terminados
        Console.WriteLine("\n--- Inventario actual ---");
        inventario.MostrarInventario();

        // Ejemplo de producción de productos terminados
        Console.WriteLine("\n--- Producción de productos terminados ---");
        
        var (numSillas, numTaburetes) = Orden("producir");

        silla.Produccion(numSillas, pata, baseSilla, respaldo);
        taburete.Produccion(numTaburetes, pata, baseTaburete);

        // Mostrar inventario actual de partes y productos terminados
        Console.WriteLine("\n--- Inventario actual ---");
        inventario.MostrarInventario();

        // Ejemplo de venta de productos terminados
        Console.WriteLine("\n--- Venta de productos terminados ---");
        
        (numSillas, numTaburetes) = Orden("vender");

        silla.Vender(numSillas);
        taburete.Vender(numTaburetes);

        // Mostrar inventario actual de partes y productos terminados
        Console.WriteLine("\n--- Inventario actual ---");
        inventario.MostrarInventario();

        // Ejemplo de reposición de partes
        Console.WriteLine("\n--- Reposición de partes ---");

        var (numPatas, numRespaldo, numBaseSilla, numBaseTaburete) = Reponer();

        pata.Reponer(numPatas);
        respaldo.Reponer(numRespaldo);
        baseSilla.Reponer(numBaseSilla);
        baseTaburete.Reponer(numBaseTaburete);

        // Mostrar inventario actual de partes y productos terminados
        Console.WriteLine("\n--- Inventario actual ---");
        inventario.MostrarInventario();
    }

    static (int,int) Orden(string orden)
    {
        int numSillas = 0;
        int numTaburetes = 0;
        bool confirmacion = false;
        string entrada;
        
        switch (orden)
        {
            case "producir":
            {
                Console.WriteLine("¿Cuántos productos deseas producir?");
        
                while(!confirmacion)
                {
                    Console.WriteLine("Sillas: ");
                    entrada = Console.ReadLine(); 
                    if (int.TryParse(entrada, out numSillas))
                    {
                        confirmacion = true;
                    }
                    else
                    {
                        // Si la conversión falla, imprimir un mensaje de error
                        Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.");
                        confirmacion = false;
                    }
                }
                confirmacion = false;

                while(!confirmacion)
                {
                    Console.WriteLine("Taburetes: ");
                    entrada = Console.ReadLine();
                    if (int.TryParse(entrada, out numTaburetes))
                    {
                        confirmacion = true;
                    }
                    else
                    {
                        // Si la conversión falla, imprimir un mensaje de error
                        Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.");
                        confirmacion = false;
                    }
                }
                confirmacion = false;
                break;
            }

            case "vender":
            {
                Console.WriteLine("¿Cuántos productos deseas vender?");
        
                while(!confirmacion)
                {
                    Console.WriteLine("Sillas: ");
                    entrada = Console.ReadLine(); 
                    if (int.TryParse(entrada, out numSillas))
                    {
                        confirmacion = true;
                    }
                    else
                    {
                        // Si la conversión falla, imprimir un mensaje de error
                        Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.");
                        confirmacion = false;
                    }
                }
                confirmacion = false;

                while(!confirmacion)
                {
                    Console.WriteLine("Taburetes: ");
                    entrada = Console.ReadLine();
                    if (int.TryParse(entrada, out numTaburetes))
                    {
                        confirmacion = true;
                    }
                    else
                    {
                        // Si la conversión falla, imprimir un mensaje de error
                        Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.");
                        confirmacion = false;
                    }
                }
                confirmacion = false;
                break;
            }
        }
        return (numSillas, numTaburetes);
    }

    static (int, int, int, int) Reponer()
    {
        int numPatas = 0;
        int numRespaldo = 0;
        int numBaseSilla = 0;
        int numBaseTaburete = 0;
        bool confirmacion = false;
        string entrada;
        Console.WriteLine("¿Cuántos productos deseas reponer?");
        
        while(!confirmacion)
        {
            Console.WriteLine("Patas: ");
            entrada = Console.ReadLine(); 
            if (int.TryParse(entrada, out numPatas))
            {
                confirmacion = true;
            }
            else
            {
                // Si la conversión falla, imprimir un mensaje de error
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.");
                confirmacion = false;
            }
        }
        confirmacion = false;

        while(!confirmacion)
        {
            Console.WriteLine("Respaldo: ");
            entrada = Console.ReadLine();
            if (int.TryParse(entrada, out numRespaldo))
            {
                confirmacion = true;
            }
            else
            {
                // Si la conversión falla, imprimir un mensaje de error
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.");
                confirmacion = false;
            }
        }
        confirmacion = false;

        while(!confirmacion)
        {
            Console.WriteLine("Base de Silla: ");
            entrada = Console.ReadLine();
            if (int.TryParse(entrada, out numBaseSilla))
            {
                confirmacion = true;
            }
            else
            {
                // Si la conversión falla, imprimir un mensaje de error
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.");
                confirmacion = false;
            }
        }
        confirmacion = false;

        while(!confirmacion)
        {
            Console.WriteLine("Base de Taburete: ");
            entrada = Console.ReadLine();
            if (int.TryParse(entrada, out numBaseTaburete))
            {
                confirmacion = true;
            }
            else
            {
                // Si la conversión falla, imprimir un mensaje de error
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.");
                confirmacion = false;
            }
        }
        confirmacion = false;

        return (numPatas, numRespaldo, numBaseSilla, numBaseTaburete);
    } 
}
