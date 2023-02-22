namespace BakeTRy.Models
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> AllCategories { get; }
    }
}
