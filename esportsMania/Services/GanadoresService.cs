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
        public async Task<List<Ganadores>> GetTopAsync(int topCount, int juegoId)
        {
            return await _context.Ganadores
                .Include(g => g.IdJuegoNavigation)
                .Where(g => g.IdJuegoNavigation.IdJuego == juegoId)
                .OrderByDescending(g => g.Puntos)
                .Take(topCount)
                .ToListAsync();
        }
    }
}
