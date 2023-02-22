using BakeTRy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BakeTRy.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, IShoppingCart shoppingCart)
        {
            this._orderRepository = orderRepository;
            this._shoppingCart = shoppingCart;
        }

        public IActionResult CheckOut()
        {
            if (_shoppingCart.GetShoppingCartItems().Count() == 0) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            _shoppingCart.GetShoppingCartItems();
            if(!_shoppingCart.ShoppingCartItems.Any()) 
            {
                ModelState.AddModelError("M001", "Your cart is empty.");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order); 
        }

        public IActionResult CheckoutComplete()
        { 
            ViewBag.CheckoutCompleteMessage = "Thanks for your order.";
            return View();
        }

    }
}
