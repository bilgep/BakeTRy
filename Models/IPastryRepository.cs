namespace BakeTRy.Models
{
    public interface IPastryRepository
    {
        public IEnumerable<Pastry> AllPastries { get; }
        public Pastry GetPastryById(int id);
        IEnumerable<Pastry> SearchPastries(string searchText);
    }
}
