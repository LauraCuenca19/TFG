namespace LineaProduccion
{
    public class Resultado
    {
        public string NombreSimulacion { get;}
        public string TipoSimulacion { get;}
        public int NumeroEstacionesManuales { get; }
        public int NumeroEstacionesAutomaticas { get; }
        public double TiempoTotalProduccion { get; }

        public Resultado(string nombreSimulacion, string tipoSimulacion, int numeroEstacionesManuales, int numeroEstacionesAutomaticas, double tiempoTotalProduccion)
        {
            NombreSimulacion = nombreSimulacion;
            TipoSimulacion = tipoSimulacion;
            NumeroEstacionesManuales = numeroEstacionesManuales;
            NumeroEstacionesAutomaticas = numeroEstacionesAutomaticas;
            TiempoTotalProduccion = tiempoTotalProduccion;
        }
    }
}


