using MediatR;

namespace Redbox.Infrastructure.Mediator.Queries
{
    public class GetCartPriceQuery : IRequest<double>
    {
        public int CartId { get; set; }
        public string DiscountCode { get; set; } = null;
    }
}
