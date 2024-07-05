using AplicacionInventario;

namespace EP6
{
    public class PCSobremesa : ProductoTerminado
    {
        public PCSobremesa(string id, int cantidad, decimal precioUnitario) : base(id, cantidad, precioUnitario)
        {
        }

        public override void Produccion(int cantidadPCSobremesa, List<ItemInventario> partes)
        {
            Parte placaBase = BuscarParte(partes, "Placa Base");
            Parte caja = BuscarParte(partes, "Caja");
            Parte fuenteAlimentacion = BuscarParte(partes, "Fuente de Alimentación");
            Parte moduloRAM = BuscarParte(partes, "Módulo RAM");
            Parte discoDuro = BuscarParte(partes, "Disco Duro");

            for (int i = 0; i < cantidadPCSobremesa; i++)
            {
                // Se esperan 1 placa base, 1 carcasa, 1 fuente de alimentación, 2 módulos de RAM y 2 discos duros para producir un PC de sobremesa
                if (placaBase.Consumir(1) && caja.Consumir(1) && fuenteAlimentacion.Consumir(1) && moduloRAM.Consumir(2) && discoDuro.Consumir(2))
                {
                    Cantidad++;
                    Console.WriteLine($"Se han utilizado 1 placa base, 1 caja, 1 fuente de alimentación, 2 módulos de RAM y 2 discos duros.");
                    Console.WriteLine($"Se ha producido un PC de Sobremesa.");
                }
                else
                {
                    Console.WriteLine($"No se pudo producir un PC de Sobremesa. Faltan materiales.");
                    break;
                }
            }
        }

        private Parte BuscarParte(List<ItemInventario> partes, string nombre)
        {
            foreach (var parte in partes)
            {
                if (parte.Nombre == nombre)
                {
                    return (Parte)parte;
                }
            }
            return null;
        }
    }
}
