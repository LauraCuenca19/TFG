namespace ExtrusionAluminio
{
    // Clase base Maquina que implementa IMaquina
    abstract class Maquina
    {
        public abstract void RealizarOperacion(Tocho tocho, Perfil perfil);
    }
}