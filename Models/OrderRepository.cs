namespace BakeTRy.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BaketryDBContext _dBContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(BaketryDBContext dBContext, IShoppingCart shoppingCart)
        {
            this._dBContext = dBContext;
            this._shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            IEnumerable<ShoppingCartItem> cartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
            order.OrderDetails = new List<OrderDetail>();

            foreach (var cartItem in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = cartItem.Amount,
                    PastryId = cartItem.PastryItem.PastryId,
                    Price = cartItem.PastryItem.Price
                };
                order.OrderDetails.Add(orderDetail);
            }

            _dBContext.Orders.Add(order);
            _dBContext.SaveChanges();

        }
    }
}
