namespace AplicacionInventario;

public interface ItemInventario
{
    public string Id { get; set; }
    public string Descripcion { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}
