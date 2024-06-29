namespace EP3;

public class Robot
{
    public string Modelo { get; }

    public Robot(string modelo)
    {
        Modelo = modelo;
    }

    public virtual void RealizarTarea()
    {
        // Método virtual que será sobrescrito en las clases derivadas
    }
}