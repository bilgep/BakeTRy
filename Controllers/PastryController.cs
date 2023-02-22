using BakeTRy.Models;
using BakeTRy.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BakeTRy.Controllers
{
    public class PastryController : Controller
    {

        private readonly IPastryRepository _pastryRepository;

        private readonly ICategoryRepository _categoryRepository;

        public PastryController(IPastryRepository pastryRepository, ICategoryRepository categoryRepository)
        {
            _pastryRepository = pastryRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List(string category)
        {
            //PastryListViewModel listViewModel = new(_pastryRepository.AllPastries, "All Pastries");
            //return View(listViewModel);

            IEnumerable<Pastry> pastries;
            string? currCategory;

            if (string.IsNullOrEmpty(category))
            {
                pastries = _pastryRepository.AllPastries.OrderBy(p => p.Name);
                currCategory = "All pastries";
            }
            else 
            {
                pastries = _pastryRepository.AllPastries.Where(p => p.CurrentCategory?.CategoryName == category).OrderBy(p => p.PastryId);

                currCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new PastryListViewModel(pastries, currCategory!));
        }

        public IActionResult Details(int id) 
        {
            var pastry = _pastryRepository.GetPastryById(id);
            if(pastry == null) { return View(); }

            return View(pastry);

        }

        public IActionResult Search(string searchText)
        {
            var pastries = _pastryRepository.SearchPastries(searchText);
            return View(pastries);
        }
    }
}
