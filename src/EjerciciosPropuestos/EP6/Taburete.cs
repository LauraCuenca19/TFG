namespace EP5;

// Clase Taburete que hereda de ProductoTerminado
public class Taburete : ProductoTerminado
{     
    public Taburete(string id, int cantidad, decimal precioUnitario) : base(id, cantidad, precioUnitario)
    {
    }

    public override void Produccion(int cantidadTaburetes, Parte parte1, Parte parte2, Parte parte3 = null)
    {
        for (int i = 0; i < cantidadTaburetes; i++)
        {
            // Se esperan 3 patas y 1 base para producir un taburete
            if (parte1.Consumir(3) && parte2.Consumir(1))
            {
                Cantidad++;
                Console.WriteLine($"Se han utilizado 3 patas y 1 base de taburete. ");
                Console.WriteLine($"Se ha producido un Taburete.");
            }
            else
            {
                Console.WriteLine($"No se pudo producir un Taburete. Faltan materiales.");
                break;
            }
        }
    }
}

