namespace esportsMania.Models.DTOs
{
    public class JugadoresDTO
    {
        public int IdJugador { get; set; }
        public string Nombre { get; set; } = null!;
        public string FotoJugador { get; set; } = null!;
        public int Kills { get; set; } = 0;
        public int Muertes { get; set; } = 0;
        public int Asistencias { get; set; } = 0;
    }
}
