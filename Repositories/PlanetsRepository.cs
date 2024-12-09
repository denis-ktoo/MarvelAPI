using MarvelAPI.Data;
using MarvelAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarvelAPI.Repositories
{
    public class PlanetsRepository : IPlanetsRepository
    {
        private readonly MarvelContext _context;

        public PlanetsRepository(MarvelContext context)
        {
            _context = context;
        }

        public int GetPlanetsCount()
        {
            return _context.Planets.Count();
        }

        public async Task<IEnumerable<Planet>> GetPlanets()
        {
            return await _context.Planets
                                 .Include(p => p.Characters)  // Include related characters
                                 .ToListAsync();
        }

        public async Task<Planet> GetPlanetById(int id)
        {
            var planet = await _context.Planets
                                        .Include(p => p.Characters)  // Include related characters
                                        .FirstOrDefaultAsync(p => p.Id == id);

            if (planet == null)
            {
                return null;
            }
            return planet;
        }
    }
}