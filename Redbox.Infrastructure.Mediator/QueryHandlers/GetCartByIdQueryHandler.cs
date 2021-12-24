using MediatR;
using Redbox.Core.Entities;
using Redbox.Core.Repositories;
using Redbox.Infrastructure.Mediator.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Redbox.Infrastructure.Mediator.QueryHandlers
{
    public class GetCartByIdQueryHandler : IRequestHandler<GetCartByIdQuery, Cart>
    {
        private readonly IRepository<Cart> _cartRepository;

        public GetCartByIdQueryHandler(IRepository<Cart> cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Task<Cart> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            return _cartRepository.GetById(request.Id);
        }
    }
}
