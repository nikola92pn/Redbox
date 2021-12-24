using MediatR;
using Redbox.Core.Entities;
using Redbox.Core.Repositories;
using Redbox.Infrastructure.Mediator.CommandRequest;
using System.Threading;
using System.Threading.Tasks;

namespace Redbox.Infrastructure.Mediator.CommandHandlers
{
    public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommandModel, CartItem>
    {
        private readonly IRepository<CartItem> _cartItemRepository;
        private readonly IRepository<Item> _itemRepository;
        private readonly IRepository<Cart> _cartRepository;

        public AddCartItemCommandHandler(IRepository<CartItem> cartItemRepository, IRepository<Item> itemRepository, IRepository<Cart> cartRepository)
        {
            _cartItemRepository = cartItemRepository;
            _itemRepository = itemRepository;
            _cartRepository = cartRepository;
        }

        public async Task<CartItem> Handle(AddCartItemCommandModel request, CancellationToken cancellationToken)
        {
            Item item = await _itemRepository.GetById(request.ItemId);
            Cart cart = await _cartRepository.GetById(request.CartId);

            // TODO: Izvrsiti proveru da li postoje objekti


            CartItem cartItem = await _cartItemRepository.GetById(request.CartId, request.ItemId);
            if (cartItem == null)
            {
                cartItem = new CartItem()
                {
                    CartId = request.CartId,
                    ItemId = request.ItemId,
                    Quantity = 1,
                    Price = item.BasePrice
                };
                await _cartItemRepository.Create(cartItem);
            }
            else
            {
                cartItem.Quantity += 1;
                bool isThirdItem = cartItem.Quantity % 3 == 0;
                cartItem.Price += isThirdItem ? item.BasePrice / 2 : item.BasePrice;
                await _cartItemRepository.Update(cartItem);
            }

            return cartItem;
        }
    }
}
