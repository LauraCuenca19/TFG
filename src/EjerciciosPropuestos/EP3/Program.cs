using EP3;

class Program
    {
        static void Main()
        {
            // Lista de órdenes de producción
            List<OrdenProduccion> ordenes = new List<OrdenProduccion>();

            // Instancias de la clase OrdenProduccion
            OrdenProduccion orden1 = new OrdenProduccion("Producto A", "Cliente 1", 550, "Pendiente");
            OrdenProduccion orden2 = new OrdenProduccion("Producto B", "Cliente 2", 450, "Pausada");
            OrdenProduccion orden3 = new OrdenProduccion("Producto C", "Cliente 1", 625, "En Proceso");
            OrdenProduccion orden4 = new OrdenProduccion("Producto A", "Cliente 3", 250, "Completada");
            OrdenProduccion orden5 = new OrdenProduccion("Producto C", "Cliente 2", 425, "Urgente");

            // Añadir órdenes a la lista
            ordenes.Add(orden1);
            ordenes.Add(orden2);  
            ordenes.Add(orden3);  
            ordenes.Add(orden4);  
            ordenes.Add(orden5);  

            // Mostrar órdenes incialmente
            Console.WriteLine("\nÓrdenes de producción iniciales:");
            foreach (var orden in ordenes)
            {
                Console.WriteLine(orden.ToString());
            }
            
            // Modificar algunas órdenes de producción
            foreach (var orden in ordenes)
            {
                if (orden.ConsultarCantidad() >= 500)
                {
                    orden.ModificarCantidad(500);
                }
                switch (orden.ConsultarEstadoActual())
                {
                    case "Pendiente":
                        orden.ModificarEstado("En Proceso");
                        break;
                    case "En Proceso":
                        orden.ModificarEstado("Completada");
                        break;
                    case "Pausada":
                        orden.ModificarEstado("En Proceso");
                        break;
                    case "Completada":
                        orden.ModificarEstado("Completada");
                        break;
                    default:
                        orden.ModificarEstado("En Proceso");
                        break;
                }
            }

            // Mostrar lista final
            Console.WriteLine("\nLista de ordenes final:");
            foreach (var orden in ordenes)
            {
                Console.WriteLine(orden.ToString());
            }
        }
    }