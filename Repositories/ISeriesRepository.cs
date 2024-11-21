using System.Collections.Generic;
using MarvelAPI.Models;

namespace MarvelAPI.Repositories
{
    public interface ISeriesRepository
    {
        Task<IEnumerable<Series>> GetSeries();
        Task<Series> GetSeriesById(int id);
        Task<Series> PostSeries(Series series);
        Task<bool> PutSeries(int id, Series series);
        Task<bool> DeleteSeries(int id);
    }
}