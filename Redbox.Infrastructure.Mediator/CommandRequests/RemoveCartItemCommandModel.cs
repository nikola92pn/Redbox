using MediatR;

namespace Redbox.Infrastructure.Mediator.CommandRequests
{
    public class RemoveCartItemCommandModel : IRequest<bool>
    {
        public int CartId { get; set; }
        public int ItemId { get; set; }
    }
}
