namespace esportsMania.Models
{
    public class Juegos
    {
        public int IdJuego { get; set; }
        public string NombreJuego { get; set; } = null!;

        public virtual ICollection<Ganadores> Ganadores { get; set; } = new List<Ganadores>();
        public virtual ICollection<Jugadores> Jugadores { get; set; } = new List<Jugadores>();

    }
}
