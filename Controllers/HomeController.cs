using BakeTRy.Models;
using BakeTRy.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BakeTRy.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPastryRepository _pastryRepository;

        public HomeController(IPastryRepository pastryRepository)
        {
            this._pastryRepository = pastryRepository;
        }

        public IActionResult Index()
        {

            HomeViewModel homeViewModel = new(_pastryRepository.AllPastries.OrderBy(x => x.Price).Take(3));
            return View(homeViewModel);
        }
    }
}
