using MediatR;
using Redbox.Core.Entities;
using Redbox.Core.Repositories;
using Redbox.Core.Services;
using Redbox.Infrastructure.Mediator.CommandRequests;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Redbox.Infrastructure.Mediator.CommandHandlers
{
    public class RemoveCartItemCommandHandler : IRequestHandler<RemoveCartItemCommandModel, bool>
    {
        private readonly IRepository<CartItem> _cartItemRepository;
        private readonly IPriceService _priceService;


        public RemoveCartItemCommandHandler(IRepository<CartItem> cartItemRepository, IPriceService priceService)
        {
            _cartItemRepository = cartItemRepository;
            _priceService = priceService;
        }

        public async Task<bool> Handle(RemoveCartItemCommandModel request, CancellationToken cancellationToken)
        {
            CartItem cartItem = await _cartItemRepository.GetById(request.CartId, request.ItemId);
            if (cartItem == null)
            {
                throw new ValidationException("No cart items found.");
            }

            bool result;
            if (cartItem.Quantity == 1)
            {
                result = await _cartItemRepository.Delete(cartItem.CartId, cartItem.ItemId);
            }
            else
            {
                double itemBasePrice = cartItem.Item.BasePrice;
                double cartItemPrice = _priceService.GetItemPriceByQty(itemBasePrice, cartItem.Quantity);

                cartItem.Price -= cartItemPrice;
                cartItem.Quantity -= 1;

                result = await _cartItemRepository.Update(cartItem) != null;
            }

            return result;
        }
    }
}
