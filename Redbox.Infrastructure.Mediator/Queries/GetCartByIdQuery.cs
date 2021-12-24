using MediatR;
using Redbox.Core.Entities;

namespace Redbox.Infrastructure.Mediator.Queries
{
    public class GetCartByIdQuery : IRequest<Cart>
    {
        public int Id { get; set; }
    }
}
