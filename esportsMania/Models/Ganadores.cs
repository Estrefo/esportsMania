namespace esportsMania.Models
{
    public class Ganadores
    {
        public int IdGanador { get; set; }
        public string NombreGanador { get; set; } = null!;
        public int Puntos { get; set; } = 0;
        // Añadimos la propiedad para la clave foránea
        public int IdJuego { get; set; }
        public virtual Juegos IdJuegoNavigation { get; set; } = null!;
    }
}
