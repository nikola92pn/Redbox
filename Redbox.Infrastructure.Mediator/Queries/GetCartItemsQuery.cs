using MediatR;
using Redbox.Core.Entities;
using System.Collections.Generic;

namespace Redbox.Infrastructure.Mediator.Queries
{
    public class GetCartItemsQuery : IRequest<ICollection<CartItem>>
    {
        public int CartId { get; set; }
    }
}
