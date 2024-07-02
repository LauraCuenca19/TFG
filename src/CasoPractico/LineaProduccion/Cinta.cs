using System;
namespace LineaProduccion
{
    public class Cinta
    {
        public double VelocidadNominal { get; set; }
        public double VelocidadMaxima { get; set; }
        public double DistanciaEstaciones { get; set; }

        public Cinta(double velocidadNominal, double velocidadMaxima, double distanciaEstaciones)
        {
            VelocidadNominal = velocidadNominal;
            VelocidadMaxima = velocidadMaxima;
            DistanciaEstaciones = distanciaEstaciones;
        }
    }
}
