using System.Collections.Generic;
using MarvelAPI.Models;

namespace MarvelAPI.Repositories
{
    public interface IMoviesRepository
    {
        int GetMoviesCount();
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovieById(int id);
    }
}