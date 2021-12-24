using MediatR;
using Redbox.Core.Entities;
using Redbox.Core.Repositories;
using Redbox.Infrastructure.Mediator.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Redbox.Infrastructure.Mediator.QueryHandlers
{
    public class GetCartPriceQueryHandler : IRequestHandler<GetCartPriceQuery, double>
    {
        private readonly IRepository<Cart> _cartRepository;

        public GetCartPriceQueryHandler(IRepository<Cart> cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<double> Handle(GetCartPriceQuery request, CancellationToken cancellationToken)
        {
            Cart cart = await _cartRepository.GetById(request.CartId);
            double cartPrice = 0;

            if (string.IsNullOrEmpty(request.DiscountCode))
            {
                cartPrice = cart.CartItems.Sum(ca => ca.Price);
            }
            else
            {
                cartPrice = cart.CartItems.Sum(ci => GetCartItemPrice(ci, request.DiscountCode));
            }

            return cartPrice;
        }

        private static double GetCartItemPrice(CartItem cartItem, string discountCode)
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
    }
}
