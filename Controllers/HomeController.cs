using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MarvelAPI.Data;
using MarvelAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MarvelAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICharactersRepository _charactersRepository;
        private readonly IMoviesRepository _moviesRepository;
        private readonly ISeriesRepository _seriesRepository;
        private readonly IPlanetsRepository _planetsRepository;

        public HomeController(
            ICharactersRepository charactersRepository,
            IMoviesRepository moviesRepository,
            ISeriesRepository seriesRepository,
            IPlanetsRepository planetsRepository)
        {
            _charactersRepository = charactersRepository;
            _moviesRepository = moviesRepository;
            _seriesRepository = seriesRepository;
            _planetsRepository = planetsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var stats = new
            {
                Characters = _charactersRepository.GetCharactersCount(),
                Movies = _moviesRepository.GetMoviesCount(),
                Series = _seriesRepository.GetSeriesCount(),
                Planets = _planetsRepository.GetPlanetsCount()
            };

            return View(stats);
        }
        public IActionResult Documentation()
        {
            return View();
        }
    }
}