namespace BakeTRy.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories => new List<Category> 
        { 
            new Category { CategoryId = 1, CategoryName = "Breads"},
            new Category { CategoryId = 2, CategoryName = "Simit"},
            new Category { CategoryId = 3, CategoryName = "Borek"}

        };
    }
}
