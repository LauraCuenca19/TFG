namespace Simulacion
{
    public class ResultadoSimulacion
    {
        public string NombreSimulacion { get;}
        public string TipoSimulacion { get;}
        public int NumeroEstacionesManuales { get; }
        public int NumeroEstacionesAutomaticas { get; }
        public double TiempoTotalProduccion { get; }

        public ResultadoSimulacion(string nombreSimulacion, string tipoSimulacion, int numeroEstacionesManuales, int numeroEstacionesAutomaticas, double tiempoTotalProduccion)
        {
            NombreSimulacion = nombreSimulacion;
            TipoSimulacion = tipoSimulacion;
            NumeroEstacionesManuales = numeroEstacionesManuales;
            NumeroEstacionesAutomaticas = numeroEstacionesAutomaticas;
            TiempoTotalProduccion = tiempoTotalProduccion;
        }
    }
}


