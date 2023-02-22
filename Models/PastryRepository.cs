using Microsoft.EntityFrameworkCore;

namespace BakeTRy.Models
{
    public class PastryRepository : IPastryRepository
    {
        private readonly BaketryDBContext _baketryDBContext;

        public PastryRepository(BaketryDBContext baketryDBContext)
        {
            this._baketryDBContext = baketryDBContext;
        }

        public IEnumerable<Pastry> AllPastries => _baketryDBContext.Pastries.Include(p => p.CurrentCategory) ?? Enumerable.Empty<Pastry>();

        public Pastry GetPastryById(int id)
        {
            return _baketryDBContext.Pastries.FirstOrDefault(p => p.PastryId == id) ?? new();   
        }

        public IEnumerable<Pastry> SearchPastries(string searchText)
        {
            return _baketryDBContext.Pastries.Where(p => p.Name.Contains(searchText));
        }
    }
}
