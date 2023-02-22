using Microsoft.EntityFrameworkCore;

namespace BakeTRy.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly BaketryDBContext _dBContext;

        public ShoppingCart(BaketryDBContext dBContext)
        {
            this._dBContext = dBContext;
        }

        public string? ShoppingCartId { get; set; }
        public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; } = Enumerable.Empty<ShoppingCartItem>();

        public ShoppingCart GetShoppingCart() => this;
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            BaketryDBContext dbContext = services.GetService<BaketryDBContext>() ?? throw new Exception("Error while accessing the dbcontext");
            string cartId = session?.GetString("cartId") ?? Guid.NewGuid().ToString();
            session?.SetString("cartId", cartId);
            return new ShoppingCart(dbContext) { ShoppingCartId = cartId };

        }

        public void AddToShoppingCart(Pastry pastry)
        {
            var shoppingCartItem = _dBContext.ShoppingCartItems.SingleOrDefault(sci => sci.PastryItem.PastryId == pastry.PastryId && sci.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    PastryItem = pastry,
                    ShoppingCartId = ShoppingCartId,
                    Amount = 1
                };

                _dBContext.ShoppingCartItems.Add(shoppingCartItem); ;
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            _dBContext.SaveChanges();

            ShoppingCartItems = _dBContext.ShoppingCartItems.Where(item => item.ShoppingCartId == shoppingCartItem.ShoppingCartId).ToList();

            
        }

        public void ClearCart()
        {
            var cartItems = _dBContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);
            _dBContext.ShoppingCartItems.RemoveRange(cartItems);
            ShoppingCartItems = Enumerable.Empty<ShoppingCartItem>();
            _dBContext.SaveChanges();
        }

        public IEnumerable<ShoppingCartItem> GetShoppingCartItems()
        {
            var items = _dBContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Include( c => c.PastryItem).ToList();
            ShoppingCartItems = items;
            return ShoppingCartItems;
        }

        public decimal GetShoppingCartTotal()
        {
            return _dBContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId).Select(c => c.PastryItem.Price * c.Amount).Sum();
             
        }

        public int RemoveFromShoppingCart(Pastry pastry)
        {
            var cartItem = _dBContext.ShoppingCartItems.SingleOrDefault<ShoppingCartItem>(p => p.PastryItem.PastryId == pastry.PastryId && p.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if(cartItem != null) 
            {
                if (cartItem.Amount > 1) { cartItem.Amount--; localAmount = cartItem.Amount; }
                else { _dBContext.ShoppingCartItems.Remove(cartItem); }
            }
            _dBContext.SaveChanges();
            return localAmount;
        }
    }
}
