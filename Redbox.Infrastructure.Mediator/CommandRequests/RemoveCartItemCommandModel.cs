using MediatR;
using Redbox.Core.Entities;

namespace Redbox.Infrastructure.Mediator.CommandRequests
{
    public class RemoveCartItemCommandModel : IRequest<CartItem>
    {
        public int CartId { get; set; }
        public int ItemId { get; set; }
    }
}
