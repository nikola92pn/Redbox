using MediatR;
using Redbox.Core.Entities;
using Redbox.Core.Repositories;
using Redbox.Infrastructure.Mediator.CommandRequests;
using System.Threading;
using System.Threading.Tasks;

namespace Redbox.Infrastructure.Mediator.CommandHandlers
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommandModel, int>
    {
        private readonly IRepository<Cart> _cartRepository;

        public CreateCartCommandHandler(IRepository<Cart> cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<int> Handle(CreateCartCommandModel request, CancellationToken cancellationToken)
        {
            Cart entity = await _cartRepository.Create(new Cart());
            return entity.Id;
        }
    }
}
