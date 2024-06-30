﻿using AplicacionInventario;

namespace EP5;

// Clase Parte para representar las partes de las sillas y taburetes
public class Parte : ItemInventario
{
    public string Id { get; set; }
    public string Descripcion { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }

    public Parte(string id, string descripcion, int cantidad, decimal precioUnitario)
    {
        Id = id;
        Descripcion = descripcion;
        Cantidad = cantidad;
        PrecioUnitario = precioUnitario;
    }

    public void Reponer(int cantidad)
    {
        Cantidad += cantidad;
        Console.WriteLine($"Se han repuesto {cantidad} unidades de {Id}.");
    }

    public bool Consumir(int cantidad)
    {
        if (Cantidad >= cantidad)
        {
            Cantidad -= cantidad;
            return true;
        }
        else
        {
            Console.WriteLine($"No hay suficientes unidades de {Id} disponibles.");
            return false;
        }
    }

    public override string ToString()
    {
        return $"{Id} ({Descripcion}): {Cantidad} unidades, Precio unitario: {PrecioUnitario}";
    }
}
