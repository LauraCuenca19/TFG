using AplicacionInventario;
using EP6;

class Program
{
    static void Main()
    {
        // Crear instancias de Partes
        Parte placaBase = new Parte("PB01", "Placa Base", 10, 100.00m);
        Parte carcasa = new Parte("CA01", "Carcasa", 10, 45.00m);
        Parte caja = new Parte("CA02", "Caja", 10, 50.00m);
        Parte fuenteAlimentacion = new Parte("FA01", "Fuente de Alimentación", 10, 70.00m);
        Parte bateria = new Parte("BA01", "Batería", 10, 40.00m);
        Parte moduloRAM = new Parte("MR01", "Módulo RAM", 20, 30.00m);
        Parte discoDuro = new Parte("DD01", "Disco Duro", 20, 35.00m);

        // Crear instancias de Productos Terminados
        PCSobremesa pcSobremesa = new PCSobremesa("PC-S01", 0, 900.00m);
        PCPortatil pcPortatil = new PCPortatil("PC-P01", 0, 700.00m);

        // Agregar items a inventario
        Inventario inventario = new Inventario();

        inventario.AgregarItem(placaBase);
        inventario.AgregarItem(carcasa);
        inventario.AgregarItem(caja);
        inventario.AgregarItem(fuenteAlimentacion);
        inventario.AgregarItem(bateria);
        inventario.AgregarItem(moduloRAM);
        inventario.AgregarItem(discoDuro);
        inventario.AgregarItem(pcSobremesa);
        inventario.AgregarItem(pcPortatil);

        // Mostrar inventario actual de partes y productos terminados
        Console.WriteLine("\n--- Inventario actual ---");
        inventario.MostrarInventario();

        // Ejemplo de producción de productos terminados
        Console.WriteLine("\n--- Producción de productos terminados ---");
        
        // Pedir cantidad a producir
        Console.Write("¿Cuántos PCs de Sobremesa quieres producir? ");
        int cantidadPCSobremesa = int.Parse(Console.ReadLine());
        Console.Write("¿Cuántos PCs Portátiles quieres producir? ");
        int cantidadPCPortatil = int.Parse(Console.ReadLine());

        pcSobremesa.Produccion(cantidadPCSobremesa, inventario.items);
        pcPortatil.Produccion(cantidadPCPortatil, inventario.items);

        // Mostrar inventario actual de partes y productos terminados
        Console.WriteLine("\n--- Inventario actual ---");
        inventario.MostrarInventario();

        // Ejemplo de venta de productos terminados
        Console.WriteLine("\n--- Venta de productos terminados ---");
        
        // Pedir cantidad a vender
        Console.Write("¿Cuántos PCs de Sobremesa quieres vender? ");
        int venderPCSobremesa = int.Parse(Console.ReadLine());
        pcSobremesa.Vender(venderPCSobremesa);
        
        Console.Write("¿Cuántos PCs Portátiles quieres vender? ");
        int venderPCPortatil = int.Parse(Console.ReadLine());
        pcPortatil.Vender(venderPCPortatil);

        // Mostrar inventario actual de partes y productos terminados
        Console.WriteLine("\n--- Inventario actual ---");
        inventario.MostrarInventario();

        // Ejemplo de reposición de partes
        Console.WriteLine("\n--- Reposición de partes ---");

        foreach (var item in inventario.items)
        {
            if (item is Parte)
            {
                Console.WriteLine($"¿Cuántos {((Parte)item).Nombre} deseas reponer?");
                int partesReponer = int.Parse(Console.ReadLine());;
                ((Parte)item).Reponer(partesReponer);
            }
        }
        // Mostrar inventario actual de partes y productos terminados
        Console.WriteLine("\n--- Inventario actual ---");
        inventario.MostrarInventario();
    }
}
