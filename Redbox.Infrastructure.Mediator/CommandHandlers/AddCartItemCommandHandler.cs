using MediatR;
using Redbox.Core.Entities;
using Redbox.Core.Repositories;
using Redbox.Core.Services;
using Redbox.Infrastructure.Mediator.CommandRequest;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Redbox.Infrastructure.Mediator.CommandHandlers
{
    public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommandModel, CartItem>
    {
        private readonly IRepository<CartItem> _cartItemRepository;
        private readonly IRepository<Item> _itemRepository;
        private readonly IRepository<Cart> _cartRepository;
        private readonly IPriceService _priceService;

        public AddCartItemCommandHandler(IRepository<CartItem> cartItemRepository, IRepository<Item> itemRepository, IRepository<Cart> cartRepository, IPriceService priceService)
        {
            _cartItemRepository = cartItemRepository;
            _itemRepository = itemRepository;
            _cartRepository = cartRepository;
            _priceService = priceService;
        }

        public async Task<CartItem> Handle(AddCartItemCommandModel request, CancellationToken cancellationToken)
        {
            CartItem cartItem = await _cartItemRepository.GetById(request.CartId, request.ItemId);
            if (cartItem == null)
            {
                Item item = await _itemRepository.GetById(request.ItemId);
                if (item == null) throw new ValidationException("The item was not found.");

                Cart cart = await _cartRepository.GetById(request.CartId);
                if (cart == null) throw new ValidationException("The cart was not found.");

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

                double itemBasePrice = cartItem.Item.BasePrice;
                double cartItemPrice =_priceService.GetItemPriceByQty(itemBasePrice, cartItem.Quantity);
                cartItem.Price += cartItemPrice;                
                
                await _cartItemRepository.Update(cartItem);
            }

            return cartItem;
        }
    }
}
