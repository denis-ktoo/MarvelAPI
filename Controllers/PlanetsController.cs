using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarvelAPI.Data;
using MarvelAPI.Models;
using MarvelAPI.Repositories;

namespace MarvelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetsController : ControllerBase
    {
        private readonly IPlanetsRepository _planetsRepository;

        public PlanetsController(IPlanetsRepository planetsRepository)
        {
            _planetsRepository = planetsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planet>>> GetPlanets()
        {
            var planets = await _planetsRepository.GetPlanets();

            // Create a response object with planet details and character URLs
            var planetsWithUrls = planets.Select(planet => new
            {
                planet.Id,
                planet.Name,
                planet.Climate,
                planet.Terrain,
                planet.Population,
                // List of character URLs
                characters = planet.Characters.Select(c => $"https://localhost:7119/api/characters/{c.Id}/").ToList()
            });

            return Ok(planetsWithUrls);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Planet>> GetPlanet(int id)
        {
            var planet = await _planetsRepository.GetPlanetById(id);
            if (planet == null)
            {
                return NotFound();
            }

            // Create a response object with planet details and character URLs
            var planetWithUrls = new
            {
                planet.Id,
                planet.Name,
                planet.Climate,
                planet.Terrain,
                planet.Population,
                // List of character URLs
                characters = planet.Characters.Select(c => $"https://localhost:7119/api/characters/{c.Id}/").ToList()
            };

            return Ok(planetWithUrls);
        }
    }
}