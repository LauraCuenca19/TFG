using AplicacionInventario;

namespace EP5;

// Clase ProductoTerminado para representar productos terminados
public abstract class ProductoTerminado : ItemInventario
{
    public string Id { get; set; }
    public string Descripcion 
    { 
        get { return this.GetType().Name; }
        set { value = this.GetType().Name; } 
    }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; protected set; }

    public ProductoTerminado(string id, int cantidad, decimal precioUnitario)
    {
        Id = id;
        Cantidad = cantidad;
        PrecioUnitario = precioUnitario;
    }

    public abstract void Produccion(int cantidadProductos, Parte parte1, Parte parte2, Parte parte3);

    public void Vender(int cantidad)
    {
        int ventas = 0;
        int pedido = cantidad;
        
        while (cantidad != 0 && Cantidad != 0)
        {
            ventas++;
            cantidad--;
            Cantidad--;
        }

        if (cantidad >= Cantidad)
        {
            Console.WriteLine($"No hay suficientes unidades de {this.GetType().Name} disponibles para la venta.");
            Console.WriteLine($"Se han vendido solo {pedido-cantidad} unidades de {this.GetType().Name}.");
        }
        else
        {
            Console.WriteLine($"Se han vendido {pedido-cantidad} unidades de {this.GetType().Name}.");
        }
    }

    public override string ToString()
    {
        return $"{Id} ({Descripcion}): {Cantidad} unidades, Precio unitario: {PrecioUnitario}";
    }
}

