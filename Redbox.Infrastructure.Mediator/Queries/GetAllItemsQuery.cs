using MediatR;
using Redbox.Core.Entities;
using System.Collections.Generic;

namespace Redbox.Infrastructure.Mediator.Queries
{
    public class GetAllItemsQuery : IRequest<IEnumerable<Item>>
    {
    }
}
