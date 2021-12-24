using MediatR;
using Redbox.Core.Entities;
using Redbox.Core.Repositories;
using Redbox.Infrastructure.Mediator.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Redbox.Infrastructure.Mediator.QueryHandlers
{
    public class GetAllCartsQueryHandler : IRequestHandler<GetAllCartsQuery, IEnumerable<Cart>>
    {
        private readonly IRepository<Cart> _cartRepository;

        public GetAllCartsQueryHandler(IRepository<Cart> cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Task<IEnumerable<Cart>> Handle(GetAllCartsQuery request, CancellationToken cancellationToken)
        {
            return _cartRepository.GetAll();
        }
    }
}
