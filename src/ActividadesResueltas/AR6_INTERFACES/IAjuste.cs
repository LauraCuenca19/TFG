namespace ActividadesResueltas.AR6_INTERFACES
{
    public interface IAjuste
    {
        // Propiedad para obtener o establecer el valor máximo permitido
        double ValorMax { get; set; }

        // Propiedad para obtener o establecer el valor actual
        double ValorActual { get; set; }
        
        // Método para realizar el ajuste
        void AjusteDirecto(double valor);

        // Método para realizar el ajuste con un porcentaje
        void AjusteProporcional(int porcentaje); 
    }
}