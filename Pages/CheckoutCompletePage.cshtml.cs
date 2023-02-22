using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BakeTRy.Pages
{
    [Authorize]
    public class CheckoutCompletePageModel : PageModel
    {
        public void OnGet()
        {
            ViewData["CheckoutCompleteMessage"] = "Thanks for your order! Your order is complete.";
        }
    }
}
