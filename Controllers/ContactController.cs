using Microsoft.AspNetCore.Mvc;

namespace BakeTRy.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
