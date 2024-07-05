using AplicacionInventario;

namespace EP6
{
    public class PCPortatil : ProductoTerminado
    {
        public PCPortatil(string id, int cantidad, decimal precioUnitario) : base(id, cantidad, precioUnitario)
        {
        }

        public override void Produccion(int cantidadPCPortatil, List<ItemInventario> partes)
        {
            Parte placaBase = BuscarParte(partes, "Placa Base");
            Parte carcasa = BuscarParte(partes, "Carcasa");
            Parte bateria = BuscarParte(partes, "Batería");
            Parte moduloRAM = BuscarParte(partes, "Módulo RAM");
            Parte discoDuro = BuscarParte(partes, "Disco Duro");

            for (int i = 0; i < cantidadPCPortatil; i++)
            {
                // Se esperan 1 placa base, 1 carcasa, 1 batería, 1 módulo de RAM y 1 disco duro para producir un PC portátil
                if (placaBase.Consumir(1) && carcasa.Consumir(1) && bateria.Consumir(1) && moduloRAM.Consumir(1) && discoDuro.Consumir(1))
                {
                    Cantidad++;
                    Console.WriteLine($"Se han utilizado 1 placa base, 1 carcasa, 1 batería, 1 módulo de RAM y 1 disco duro.");
                    Console.WriteLine($"Se ha producido un PC Portátil.");
                }
                else
                {
                    Console.WriteLine($"No se pudo producir un PC Portátil. Faltan materiales.");
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
