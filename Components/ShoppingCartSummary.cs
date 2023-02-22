using BakeTRy.Models;
using BakeTRy.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BakeTRy.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartSummary(IShoppingCart shoppingCart)
        {
            this._shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        { 
            _shoppingCart.GetShoppingCartItems();
            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());
            return View(shoppingCartViewModel);

        }
        
    }
}
