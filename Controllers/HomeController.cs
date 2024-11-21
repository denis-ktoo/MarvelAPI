using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MarvelAPI.Data;
using MarvelAPI.Repositories;

namespace MarvelAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}