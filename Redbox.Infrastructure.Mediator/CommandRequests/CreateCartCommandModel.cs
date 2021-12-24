using MediatR;
using System;

namespace Redbox.Infrastructure.Mediator.CommandRequests
{
    public class CreateCartCommandModel : IRequest<int>
    {
    }
}
