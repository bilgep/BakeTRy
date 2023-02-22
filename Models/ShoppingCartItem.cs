namespace BakeTRy.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Pastry PastryItem { get; set; } = default!;
        public int Amount { get; set; }
        public string? ShoppingCartId { get; set; }
    }
}
