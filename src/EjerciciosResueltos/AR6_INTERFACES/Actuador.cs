public abstract class Actuador : DispositivoElectronico
{
    // Atributo privado para el estado de emergencia
    private bool estadoEmergencia;

    // Propiedad para el tipo de actuador
    public string TipoActuador{ get ; set; }

    // Constructor
    public Actuador(string tipo, string fabricante) : base("Actuador", fabricante)
    {
        TipoActuador = tipo;
        estadoEmergencia = false;
    }

    // Métodos abstractos
    public override abstract void Activar();
    public override abstract void Desactivar();

    public void ParadaEmergencia()
    {
        if (estadoEmergencia) Desactivar();
    }

    // Sobrescritura del método ToString de la clase Object
    public override string ToString()
    {
        return base.ToString() + $", TipoActuador: {TipoActuador}";
    }
}