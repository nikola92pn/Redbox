using MediatR;
using Redbox.Core.Entities;
using Redbox.Core.Repositories;
using Redbox.Core.Services;
using Redbox.Infrastructure.Mediator.Queries;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Redbox.Infrastructure.Mediator.QueryHandlers
{
    public class GetCartPriceQueryHandler : IRequestHandler<GetCartPriceQuery, double>
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IPriceService _priceService;

        public GetCartPriceQueryHandler(IRepository<Cart> cartRepository, IPriceService priceService)
        {
            _cartRepository = cartRepository;
            _priceService = priceService;
        }
        public async Task<double> Handle(GetCartPriceQuery request, CancellationToken cancellationToken)
        {
            Cart cart = await _cartRepository.GetById(request.CartId);
            if (cart == null) throw new ValidationException("The cart was not found.");

            double cartPrice = _priceService.CalculatePrice(request.DiscountCode, cart);
            return cartPrice;
        }        
    }
}
