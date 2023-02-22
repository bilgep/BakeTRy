using BakeTRy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BakeTRy.Pages
{
    [Authorize]
    public class CheckoutPageModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;

        public CheckoutPageModel(IOrderRepository orderRepository, IShoppingCart shoppingCart)
        {
            this._orderRepository = orderRepository;
            this._shoppingCart = shoppingCart;
        }

        [BindProperty]
        public Order Order { get; set; } = new();
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
;
            _shoppingCart.GetShoppingCartItems();

            if (_shoppingCart.ShoppingCartItems.Count() == 0)
            {
                ModelState.AddModelError("M001", "Your cart is empty");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(Order);
                _shoppingCart.ClearCart();
                return RedirectToPage("CheckoutCompletePage");
            }

            return Page();
        }
    }
}
