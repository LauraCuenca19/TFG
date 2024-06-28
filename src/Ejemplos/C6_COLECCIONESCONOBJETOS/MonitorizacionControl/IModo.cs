namespace MonitorizacionControl
{
    public interface IModo
    {
        // Propiedad para indicar modo de funcionamiento
        bool ModoAuto { get; set; }

        // Método para definir la lógica del modo automático del actuador
        void ModoAutomatico();
    }
}