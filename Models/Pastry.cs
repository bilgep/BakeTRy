namespace BakeTRy.Models
{
    public class Pastry
    {
        public int PastryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = "/img/default.jpg";
        public int CategoryId { get; set; }
        public Category? CurrentCategory { get; set; }

    }
}
