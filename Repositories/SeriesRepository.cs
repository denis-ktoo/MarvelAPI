using MarvelAPI.Data;
using MarvelAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarvelAPI.Repositories
{
    public class SeriesRepository : ISeriesRepository
    {
        private readonly MarvelContext _context;

        public SeriesRepository(MarvelContext context)
        {
            _context = context;
        }

        public int GetSeriesCount()
        {
            return _context.Series.Count();
        }

        public async Task<IEnumerable<Series>> GetSeries()
        {
            return await _context.Series.ToListAsync();
        }

        public async Task<Series> GetSeriesById(int id)
        {
            var series = await _context.Series.FindAsync(id);
            if (series == null)
            {
                return null;
            }
            return series;
        }
    }
}
