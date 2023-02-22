namespace BakeTRy.Models
{
    public interface IShoppingCart
    {
        public static ShoppingCart GetCart(IServiceProvider services) { return default!; }
        public void AddToShoppingCart(Pastry pastry);
        public int RemoveFromShoppingCart(Pastry pastry);
        public IEnumerable<ShoppingCartItem> GetShoppingCartItems();
        public void ClearCart();
        public decimal GetShoppingCartTotal();
        public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart GetShoppingCart();
    }
}
