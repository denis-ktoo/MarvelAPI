using MarvelAPI.Data;
using MarvelAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarvelAPI.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly MarvelContext _context;

        public MoviesRepository(MarvelContext context)
        {
            _context = context;
        }

        public int GetMoviesCount()
        {
            return _context.Movies.Count();
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return null;
            }
            return movie;
        }
    }
}
