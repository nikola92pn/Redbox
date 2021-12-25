using Redbox.Core.Entities;

namespace Redbox.Core.Services
{
    public interface IPriceService
    {
        /// <summary>
        /// Calculates price for cart with a discount code
        /// </summary>
        /// <param name="discountCode">Discount code as an optional parameter</param>
        /// <param name="cart">Cart as a required parameter</param>
        /// <returns>Cart price</returns>
        public double CalculatePrice(string discountCode, Cart cart);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="discountCode">Discount code as a required parameter</param>
        /// <param name="cartItem">CartItem as a required parameter</param>
        /// <returns>Price of one cart item with a discount</returns>
        public double GetCartItemPrice(CartItem cartItem, string discountCode);

        /// <summary>
        /// Gets item price by quantity
        /// </summary>
        /// <param name="basePrice"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetItemPriceByQty(double basePrice, int quantity);
    }
}
