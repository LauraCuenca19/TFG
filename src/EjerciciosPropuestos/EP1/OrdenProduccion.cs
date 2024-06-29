namespace EP1;

public class OrdenProduccion
{
    private int id;
    private string producto;
    private string cliente;
    private int cantidad;
    private string estado;

    private static int contadorOrdenes = 0;

    public OrdenProduccion(string producto, string cliente, int cantidad, string estado)
    {
        contadorOrdenes ++;
        id = contadorOrdenes;
        this.producto = producto;
        this.cliente = cliente;
        this.cantidad = cantidad;
        ModificarEstado(estado);
        Console.WriteLine("Orden de Producción creada.");
    }

    public int ConsultarIdOrden()
    {
        return id;
    }

    public string ConsultarProducto()
    {
        return producto;
    }

    public string ConsultarCliente()
    {
        return cliente;
    }

    public int ConsultarCantidad()
    {
        return cantidad;
    }

    public void ModificarCantidad(int cantidad)
    {
        this.cantidad = cantidad;
    }

    public string ConsultarEstadoActual()
    {
        return estado;
    }

    public void ModificarEstado(string estado)
    {
        if (estado != "Pendiente" && estado != "En Proceso" && estado != "Pausada" && estado != "Completada")
        {
            Console.WriteLine("El estado no es válido. Se establecerá la orden como 'Pendiente'");
            this.estado = "Pendiente";
        } 
        else this.estado = estado;
    }

    public override string ToString()
    {
        return $"ID: {id}, Producto: {producto}, Cliente: {cliente}, Cantidad: {cantidad}, Estado: {estado}";
    }
}
