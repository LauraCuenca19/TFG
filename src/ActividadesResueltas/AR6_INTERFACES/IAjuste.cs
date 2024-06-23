public interface IAjuste
{
    // Método para realizar el ajuste
    void AjusteDirecto(double valor);

    // Método para realizar el ajuste con un porcentaje
    void AjusteProporcional(int porcentaje); 

    // Propiedad para obtener o establecer el valor mínimo permitido
    double ValorMin { get; set; }

    // Propiedad para obtener o establecer el valor máximo permitido
    double ValorMax { get; set; }

    // Propiedad para obtener o establecer el valor actual
    double ValorActual { get; set; }
}