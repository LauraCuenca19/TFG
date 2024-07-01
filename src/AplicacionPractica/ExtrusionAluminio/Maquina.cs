namespace ExtrusionAluminio
{
    // Clase base Maquina
    abstract class Maquina
    {
        public abstract void RealizarOperacion(Tocho tocho, Perfil perfil);
    }
}