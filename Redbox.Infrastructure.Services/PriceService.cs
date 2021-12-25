using Redbox.Core.Entities;
using Redbox.Core.Services;
using System.Linq;

namespace Redbox.Infrastructure.Services
{
    public class PriceService : IPriceService
    {
        public double CalculatePrice(string discountCode, Cart cart)
        {
            double cartPrice;
            if (string.IsNullOrEmpty(discountCode))
            {
                cartPrice = cart.CartItems.Sum(ca => ca.Price);
            }
            else
            {
                cartPrice = cart.CartItems.Sum(ci => GetCartItemPrice(ci, discountCode));
            }

            return cartPrice;
        }

        public double GetCartItemPrice(CartItem cartItem, string discountCode)
        {
            ItemDiscount itemDiscount = cartItem.Item.ItemDiscounts.FirstOrDefault(id => id.DiscountCode == discountCode);
            if (itemDiscount != null)
            {
                double discount = itemDiscount.Discount.Percentage;
                return cartItem.Price -= cartItem.Price * discount / 100;
            }
            else
            {
                return cartItem.Price;
            }
        }

        public double GetItemPriceByQty(double basePrice, int quantity)
        {
            bool isThirdItem = quantity % 3 == 0;
            return isThirdItem ? basePrice / 2 : basePrice;
        }
    }
}
