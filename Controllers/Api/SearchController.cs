using BakeTRy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BakeTRy.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IPastryRepository _pastryRepository;

        public SearchController(IPastryRepository pastryRepository)
        {
            this._pastryRepository = pastryRepository;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var pastries = _pastryRepository.AllPastries;
            return Ok(pastries);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_pastryRepository.AllPastries.Any(p => p.PastryId == id)) return NotFound();

            var result = _pastryRepository.AllPastries.Where(p => p.PastryId == id);
            return Ok(result);

        }

        [HttpPost]
        public IActionResult SearchPies([FromBody]string searchText)
        {
            IEnumerable<Pastry> pastries = Enumerable.Empty<Pastry>();

            if (searchText.Length >= 3 && !string.IsNullOrEmpty(searchText))
            {
                pastries = _pastryRepository.SearchPastries(searchText);
            }
            
            if(pastries.IsNullOrEmpty())
            {
                return NoContent();
            }

            return new JsonResult(pastries);
        }
    }
}
