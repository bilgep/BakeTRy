using System.IO.Pipelines;

namespace BakeTRy.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int PastryId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Pastry Pastry { get; set; } = default!;
        public Order Order { get; set; } = default!;
    }
}