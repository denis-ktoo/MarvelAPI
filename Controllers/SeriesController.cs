using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarvelAPI.Data;
using MarvelAPI.Models;
using MarvelAPI.Repositories;

namespace MarvelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ISeriesRepository _seriesRepository;

        public SeriesController(ISeriesRepository seriesRepository)
        {
            _seriesRepository = seriesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Series>>> GetSeries()
        {
            var series =  await _seriesRepository.GetSeries();
            return Ok(series);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Series>> GetSeries(int id)
        {
            var series = await _seriesRepository.GetSeriesById(id);
            if (series == null)
            {
                return NotFound();
            }
            return series;
        }
    }
}
