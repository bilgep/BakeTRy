using BakeTRy.Models;
using BakeTRy.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BakeTRy.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPastryRepository _pastryRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IPastryRepository pastryRepository, IShoppingCart shoppingCart)
        {
            this._pastryRepository = pastryRepository;
            this._shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();
            var viewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

            return View(viewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int pastryId)
        {
            var pastryToAdd = _pastryRepository.AllPastries.FirstOrDefault(p => p.PastryId == pastryId);
            if(pastryToAdd!= null) { _shoppingCart.AddToShoppingCart(pastryToAdd); }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int pastryId)
        {
            var pastryToAdd = _pastryRepository.AllPastries.FirstOrDefault(p => p.PastryId == pastryId);
            if (pastryToAdd != null) { _shoppingCart.RemoveFromShoppingCart(pastryToAdd); }
            return RedirectToAction("Index");
        }
    }
}
