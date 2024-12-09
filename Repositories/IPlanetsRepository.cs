using System.Collections.Generic;
using MarvelAPI.Models;

namespace MarvelAPI.Repositories
{
    public interface IPlanetsRepository
    {
        int GetPlanetsCount();
        Task<IEnumerable<Planet>> GetPlanets();
        Task<Planet> GetPlanetById(int id);
    }
}