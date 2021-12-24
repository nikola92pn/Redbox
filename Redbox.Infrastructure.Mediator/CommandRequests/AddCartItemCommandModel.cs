using MediatR;
using Redbox.Core.Entities;
using System;

namespace Redbox.Infrastructure.Mediator.CommandRequest
{
    public class AddCartItemCommandModel : IRequest<CartItem>
    {
        public int CartId { get; set; }
        public int ItemId { get; set; }
    }
}
