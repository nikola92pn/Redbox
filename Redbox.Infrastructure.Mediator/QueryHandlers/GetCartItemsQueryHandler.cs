using MediatR;
using Redbox.Core.Entities;
using Redbox.Core.Repositories;
using Redbox.Infrastructure.Mediator.Queries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Redbox.Infrastructure.Mediator.QueryHandlers
{
    public class GetCartItemsQueryHandler : IRequestHandler<GetCartItemsQuery, ICollection<CartItem>>
    {
        private readonly IRepository<Cart> _cartRepository;

        public GetCartItemsQueryHandler(IRepository<Cart> cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<ICollection<CartItem>> Handle(GetCartItemsQuery request, CancellationToken cancellationToken)
        {
            Cart cart = await _cartRepository.GetById(request.CartId);
            if (cart == null) throw new ValidationException("The cart was not found.");

            return cart.CartItems;
        }
    }
}
