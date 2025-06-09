using esportsMania.Context;
using esportsMania.Models;
using Microsoft.EntityFrameworkCore;

namespace esportsMania.Services
{
    public class JugadoresService
    {
        private readonly EsportsContext _context;

        public JugadoresService(EsportsContext context)
        {
            _context = context;
        }

        public async Task<List<Jugadores>> GetAllAsync()
        {
            return await _context.Jugadores
                .Include(j => j.IdJuegoNavigation)
                .ToListAsync();
        }

        public async Task<Jugadores?> GetByIdAsync(int id)
        {
            return await _context.Jugadores
                .Include(j => j.IdJuegoNavigation)
                .FirstOrDefaultAsync(j => j.IdJugador == id);
        }

        public async Task AddAsync(Jugadores jugador)
        {
            _context.Jugadores.Add(jugador);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Jugadores jugador)
        {
            _context.Jugadores.Update(jugador);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var jugador = await _context.Jugadores.FindAsync(id);
            if (jugador != null)
            {
                _context.Jugadores.Remove(jugador);
                await _context.SaveChangesAsync();
            }
        }
    }
}
