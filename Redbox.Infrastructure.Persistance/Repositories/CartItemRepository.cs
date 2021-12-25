using Microsoft.EntityFrameworkCore;
using Redbox.Core.Entities;
using Redbox.Infrastructure.Persistance.Context;
using System.Threading.Tasks;

namespace Redbox.Infrastructure.Persistance.Repositories
{
    public class CartItemRepository : BaseRepository<CartItem, RedboxDbContext>
    {
        public CartItemRepository(RedboxDbContext context) : base(context)
        {
        }

        #region overrides
        public override async Task<CartItem> GetById(params object[] id)
        {
            CartItem cartItem = await _context.CartItems
                .Include(ci => ci.Cart)
                .Include(ci => ci.Item)
                .FirstOrDefaultAsync(ci => ci.CartId == (int)id[0] && ci.ItemId == (int)id[1]);
            return cartItem;
        }
        #endregion
    }
}
