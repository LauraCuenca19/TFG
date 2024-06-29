namespace AplicacionInventario;

public class Inventario
    {
        private List<ItemInventario> items;

        public Inventario()
        {
            items = new List<ItemInventario>();
        }

        public void AgregarItem(ItemInventario item)
        {
            items.Add(item);
            Console.WriteLine($"Ítem {item.Id} ({item.Descripcion}) agregado al inventario.");
        }

        public void EliminarItem(string id)
        {
            ItemInventario item = BuscarItemPorId(id);
            if (item != null)
            {
                items.Remove(item);
                Console.WriteLine($"Ítem {item.Id} ({item.Descripcion}  eliminado del inventario.");
            }
            else
            {
                Console.WriteLine($"Ítem con ID {id} no encontrado.");
            }
        }

        public void MostrarInventario()
        {
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private ItemInventario BuscarItemPorId(string id)
        {
            foreach (var item in items)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
