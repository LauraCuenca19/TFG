using System;
using System.Collections.Generic;
using ExtrusionAluminio;

// Clase principal del programa
class Program
{
    static void Main(string[] args)
    {
        ExtrusionAluminioAPS sistema = new ExtrusionAluminioAPS();
        sistema.IniciarSimulacion();
    }
}
