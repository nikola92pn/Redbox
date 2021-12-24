using MediatR;
using Redbox.Core.Entities;
using Redbox.Core.Repositories;
using Redbox.Infrastructure.Mediator.CommandRequests;
using System.Threading;
using System.Threading.Tasks;

namespace Redbox.Infrastructure.Mediator.CommandHandlers
{
    public class RemoveCartItemCommandHandler : IRequestHandler<RemoveCartItemCommandModel, CartItem>
    {
        private readonly IRepository<CartItem> _cartItemRepository;
        private readonly IRepository<Item> _itemRepository;
        private readonly IRepository<Cart> _cartRepository;

        public RemoveCartItemCommandHandler(IRepository<CartItem> cartItemRepository, IRepository<Item> itemRepository, IRepository<Cart> cartRepository)
        {
            _cartItemRepository = cartItemRepository;
            _itemRepository = itemRepository;
            _cartRepository = cartRepository;
        }

        public async Task<CartItem> Handle(RemoveCartItemCommandModel request, CancellationToken cancellationToken)
        {
            Item item = await _itemRepository.GetById(request.ItemId);
            Cart cart = await _cartRepository.GetById(request.CartId);

            // TODO: Izvrsiti proveru da li postoje objekti


            CartItem cartItem = await _cartItemRepository.GetById(request.CartId, request.ItemId);
            if (cartItem == null)
            {
                // TODO: validacija
            }
            else
            {
                if (cartItem.Quantity == 1)
                {
                    await _cartItemRepository.Delete(cartItem.CartId, cartItem.ItemId);
                }
                else
                {                    
                    bool isThirdItem = cartItem.Quantity % 3 == 0;
                    cartItem.Price -= isThirdItem ? item.BasePrice / 2 : item.BasePrice;
                    cartItem.Quantity -= 1;
                    await _cartItemRepository.Update(cartItem);
                }
            }

            return cartItem;
        }
    }
}
