using System.Collections.Generic;
using MarvelAPI.Models;

namespace MarvelAPI.Repositories
{
    public interface IMoviesRepository
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovieById(int id);
        Task<Movie> PostMovie(Movie movie);
        Task<bool> PutMovie(int id, Movie movie);
        Task<bool> DeleteMovie(int id);
    }
}