namespace EP1;

public abstract class Sensor
{
    private string id;
    private string ubicacion;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Ubicacion
    {
        get { return ubicacion; }
        set { ubicacion = value; }
    }

    public abstract void LeerValor();
}
