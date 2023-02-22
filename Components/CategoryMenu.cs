using BakeTRy.Models;
using Microsoft.AspNetCore.Mvc;

namespace BakeTRy.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.AllCategories.OrderBy(c => c.CategoryName).ToList();
            return View(categories);
        }
    }
}
