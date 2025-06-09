using esportsMania.Context;
using esportsMania.Models;
using Microsoft.EntityFrameworkCore;

namespace esportsMania.Services
{
    public class JuegosService
    {
        private readonly EsportsContext _context;

        public JuegosService(EsportsContext context)
        {
            _context = context;
        }

        public async Task<List<Juegos>> GetAllAsync()
        {
            return await _context.Juegos
                .Include(j => j.Ganadores)
                .Include(j => j.Jugadores)
                .ToListAsync();
        }

        public async Task<Juegos?> GetByIdAsync(int id)
        {
            return await _context.Juegos
                .Include(j => j.Ganadores)
                .Include(j => j.Jugadores)
                .FirstOrDefaultAsync(j => j.IdJuego == id);
        }

        public async Task AddAsync(Juegos juego)
        {
            _context.Juegos.Add(juego);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Juegos juego)
        {
            _context.Juegos.Update(juego);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var juego = await _context.Juegos.FindAsync(id);
            if (juego != null)
            {
                _context.Juegos.Remove(juego);
                await _context.SaveChangesAsync();
            }
        }
    }
}
