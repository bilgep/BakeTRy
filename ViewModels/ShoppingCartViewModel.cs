using BakeTRy.Models;

namespace BakeTRy.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel(IShoppingCart shoppingCart, decimal cartTotal)
        {
            ShoppingCart = shoppingCart;
            CartTotal = cartTotal;
        }

        public IShoppingCart ShoppingCart { get; }
        public decimal CartTotal { get; }
    }
}
