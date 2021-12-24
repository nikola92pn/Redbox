using Microsoft.EntityFrameworkCore;
using Redbox.Core.Entities;
using Redbox.Infrastructure.Persistance.Context;
using System.Threading.Tasks;

namespace Redbox.Infrastructure.Persistance.Repositories
{
    public class CartRepository : BaseRepository<Cart, RedboxDbContext>
    {
        public CartRepository(RedboxDbContext context) : base(context)
        {
        }

        #region overrides
        public override async Task<Cart> GetById(params object[] id)
        {
            Cart cart = await _context.Carts
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Item)
                        .ThenInclude(i => i.ItemDiscounts)
                            .ThenInclude(id => id.Discount)
                .FirstOrDefaultAsync(c => c.Id == (int)id[0]);
            return cart;
        }
        #endregion
    }
}
