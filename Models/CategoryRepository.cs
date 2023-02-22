namespace BakeTRy.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BaketryDBContext _baketryDBContext;

        public CategoryRepository(BaketryDBContext baketryDBContext)
        {
            this._baketryDBContext = baketryDBContext;
        }

        IEnumerable<Category> ICategoryRepository.AllCategories => _baketryDBContext.Categories.OrderBy(c => c.CategoryName);
    }
}
