using esportsMania.Models;
using Microsoft.EntityFrameworkCore;

namespace esportsMania.Context
{
    public class EsportsContext : DbContext
    {
        public EsportsContext(DbContextOptions<EsportsContext> options) : base(options)
        {
        }

        public DbSet<Ganadores> Ganadores { get; set; }
        public DbSet<Jugadores> Jugadores { get; set; }
        public DbSet<Juegos> Juegos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Claves primarias con IDENTITY (auto-increment)
            modelBuilder.Entity<Ganadores>()
                .HasKey(g => g.IdGanador);
            modelBuilder.Entity<Ganadores>()
                .Property(g => g.IdGanador)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Jugadores>()
                .HasKey(j => j.IdJugador);
            modelBuilder.Entity<Jugadores>()
                .Property(j => j.IdJugador)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Juegos>()
                .HasKey(j => j.IdJuego);
            modelBuilder.Entity<Juegos>()
                .Property(j => j.IdJuego)
                .ValueGeneratedOnAdd();

            // Relaciones Ganadores -> Juegos (muchos a uno)
            modelBuilder.Entity<Ganadores>()
                .HasOne(g => g.IdJuegoNavigation)
                .WithMany(j => j.Ganadores)
                .HasForeignKey("IdJuego")
                .IsRequired();

            // Relaciones Jugadores -> Juegos (muchos a uno)
            modelBuilder.Entity<Jugadores>()
                .HasOne(j => j.IdJuegoNavigation)
                .WithMany(jg => jg.Jugadores)
                .HasForeignKey("IdJuego")
                .IsRequired();
        }
    }
}
