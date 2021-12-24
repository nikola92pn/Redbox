using Redbox.Core.Entities;
using Redbox.Infrastructure.Persistance.Context;

namespace Redbox.Infrastructure.Persistance.Repositories
{
    public class CartItemRepository : BaseRepository<CartItem, RedboxDbContext>
    {
        public CartItemRepository(RedboxDbContext context) : base(context)
        {
        }
    }
}
