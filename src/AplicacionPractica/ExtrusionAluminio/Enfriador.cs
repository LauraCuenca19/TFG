namespace ExtrusionAluminio
{
    // Clase Enfriador que hereda de Maquina
    class Enfriador : Maquina
    {
        public override void RealizarOperacion(Tocho tocho, Perfil perfil)
        {
            // El tiempo de proceso del enfriador es igual al tiempo de enfriamiento indicado por el usuario
            perfil.TiempoProcesoTotal += perfil.TiempoEnfriamiento;

            // Simular proceso de enfriamiento del perfil
            Console.WriteLine("\nEnfriando el perfil...");
            System.Threading.Thread.Sleep(1000);
        }
    }
}
