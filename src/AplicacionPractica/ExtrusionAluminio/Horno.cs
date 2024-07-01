namespace ExtrusionAluminio
{
    // Clase Horno que hereda de Maquina
    class Horno : Maquina
    {
        public override void RealizarOperacion(Tocho tocho, Perfil perfil)
        {
            // Calcular tiempo de proceso según la temperatura del horno y la aleación
            double tiempoProceso = (perfil.TemperaturaHorno - 450) / 100.0;
            // Simular proceso de calentamiento del tocho
            Console.WriteLine($"\nCalentando el tocho de aleación {perfil.Aleacion} en el horno...");
            System.Threading.Thread.Sleep(1000);

            // Simulación de tiempo de proceso realista basado en la temperatura y la aleación
            perfil.TiempoProcesoTotal += Convert.ToInt32(60 + 60 * tiempoProceso); // Ejemplo de tiempo ajustado
        }
    }
}
