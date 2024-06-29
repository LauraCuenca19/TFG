namespace EP5;

// Clase Silla que hereda de ProductoTerminado
public class Silla : ProductoTerminado
{
    public Silla(string id, int cantidad, decimal precioUnitario) : base(id, cantidad, precioUnitario)
    {
    }

    public override void Produccion(int cantidadSillas, Parte pata, Parte asiento, Parte respaldo)
    {
        for (int i = 0; i < cantidadSillas; i++)
        {
            // Se esperan 4 patas, 1 asiento y 1 respaldo para producir una silla
            if (pata.Consumir(4) && asiento.Consumir(1) && respaldo.Consumir(1))
            {
                Cantidad++;
                Console.WriteLine($"Se han utilizado 4 patas, 1 base de silla y 1 respaldo.");
                Console.WriteLine($"Se ha producido una Silla.");
            }
            else
            {
                Console.WriteLine($"No se pudo producir una Silla. Faltan materiales.");
                break;
            }
        }
    }
}

