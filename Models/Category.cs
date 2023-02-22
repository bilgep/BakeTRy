namespace BakeTRy.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public IEnumerable<Pastry> Pastries { get; set; } = default!;
    }
}
