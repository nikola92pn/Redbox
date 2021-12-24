using MediatR;
using System.Collections.Generic;
using Redbox.Core.Entities;

namespace Redbox.Infrastructure.Mediator.Queries
{
    public class GetAllCartsQuery : IRequest<IEnumerable<Cart>>
    {
    }
}
