using esportsMania.Context;
using Microsoft.EntityFrameworkCore;
using esportsMania.Models;

namespace esportsMania.Services
{
    public class GanadoresService
    {
        private readonly EsportsContext _context;

        public GanadoresService(EsportsContext context)
        {
            _context = context;
        }

        public async Task<List<Ganadores>> GetAllAsync()
        {
            return await _context.Ganadores
                .Include(g => g.IdJuegoNavigation)
                .ToListAsync();
        }

        public async Task<Ganadores?> GetByIdAsync(int id)
        {
            return await _context.Ganadores
                .Include(g => g.IdJuegoNavigation)
                .FirstOrDefaultAsync(g => g.IdGanador == id);
        }

        public async Task AddAsync(Ganadores ganador)
        {
            // Cargar el juego existente para evitar problemas de tracking
            var juegoExistente = await _context.Juegos.FindAsync(ganador.IdJuego);

            if (juegoExistente == null)
                throw new InvalidOperationException("El juego especificado no existe.");

            // Asignar la propiedad de navegación para EF Core
            ganador.IdJuegoNavigation = juegoExistente;

            // Añadir el ganador al contexto y guardar
            _context.Ganadores.Add(ganador);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ganadores ganador)
        {
            _context.Ganadores.Update(ganador);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ganador = await _context.Ganadores.FindAsync(id);
            if (ganador != null)
            {
                _context.Ganadores.Remove(ganador);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Ganadores>> GetTopAsync(int count, int juegoId)
        {
            return await _context.Ganadores
                .Where(g => g.IdJuego == juegoId)
                .OrderByDescending(g => g.Puntos)
                .Take(count)
                .ToListAsync();
        }
        public async Task<bool> ExisteNombreGanadorAsync(string nombre)
        {
            return await _context.Ganadores.AnyAsync(g => g.NombreGanador == nombre);
        }
    }
}
