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
        silla.Produccion(4, pata, baseSilla, respaldo);
        taburete.Produccion(2, pata, baseTaburete);

        // Mostrar inventario actual de partes y productos terminados
        Console.WriteLine("\n--- Inventario actual ---");
        inventario.MostrarInventario();

        // Ejemplo de venta de productos terminados
        Console.WriteLine("\n--- Venta de productos terminados ---");
        silla.Vender(1);
        taburete.Vender(3);

        // Mostrar inventario actual de partes y productos terminados
        Console.WriteLine("\n--- Inventario actual ---");
        inventario.MostrarInventario();

        // Ejemplo de reposición de partes
        Console.WriteLine("\n--- Reposición de partes ---");
        pata.Reponer(10);
        baseSilla.Reponer(5);

        // Mostrar inventario actual de partes y productos terminados
        Console.WriteLine("\n--- Inventario actual ---");
        inventario.MostrarInventario();
    }
}
