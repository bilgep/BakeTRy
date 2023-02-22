namespace BakeTRy.Models
{
    public class MockPastryRepository : IPastryRepository
    {
        private readonly ICategoryRepository _categoryRepository;

        public MockPastryRepository(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public IEnumerable<Pastry> AllPastries =>
            new List<Pastry>
            {
                new Pastry{ PastryId = 1, Name ="Somun (Loaf)", Price = 5.5M, ImageUrl="/img/somun.jpg", CategoryId = 1, CurrentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryId == 1)  },
                new Pastry{ PastryId = 2, Name ="Vakifkebir", Price = 7M, ImageUrl="/img/vakifkebir.jpg", CategoryId = 1, CurrentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryId == 1)  },
                new Pastry{ PastryId = 3, Name ="Cornbread", Price = 8.5M, ImageUrl="/img/cornbread.jpg", CategoryId = 1, CurrentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryId == 1)  },
                new Pastry{ PastryId = 4, Name ="Simit", Price = 5M, ImageUrl="/img/simit.jpg", CategoryId = 2, CurrentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryId == 2)  },
                new Pastry{ PastryId = 5, Name ="Butter Simit", Price = 6M, ImageUrl="/img/buttersimit.png", CategoryId = 2, CurrentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryId == 2) },
                new Pastry{ PastryId = 6, Name ="Cheese Borek", Price = 10.5M, ImageUrl="/img/cheeseborek.jpg", CategoryId = 3 , CurrentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryId == 3)},
                new Pastry{ PastryId = 7, Name ="Patato Borek", Price = 10.5M, ImageUrl="/img/patatoborek.jpg", CategoryId = 3 , CurrentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryId == 3)}
            };

        public Pastry GetPastryById(int id)
        {
            return AllPastries.FirstOrDefault(p => p.PastryId == id) ?? new();
        }

        public IEnumerable<Pastry> SearchPastries(string searchText)
        {
            throw new NotImplementedException();
        }
    }
}
