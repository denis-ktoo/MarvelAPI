using System.Collections.Generic;
using MarvelAPI.Models;

namespace MarvelAPI.Repositories
{
    public interface ISeriesRepository
    {
        int GetSeriesCount();
        Task<IEnumerable<Series>> GetSeries();
        Task<Series> GetSeriesById(int id);
    }
}