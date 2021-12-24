using MediatR;
using Redbox.Core.Entities;
using Redbox.Core.Repositories;
using Redbox.Infrastructure.Mediator.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Redbox.Infrastructure.Mediator.QueryHandlers
{
    public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, IEnumerable<Item>>
    {
        private readonly IRepository<Item> _itemRepository;

        public GetAllItemsQueryHandler(IRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public Task<IEnumerable<Item>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            return _itemRepository.GetAll();
        }
    }
}
