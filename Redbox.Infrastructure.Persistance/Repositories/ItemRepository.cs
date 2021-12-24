using Redbox.Core.Entities;
using Redbox.Infrastructure.Persistance.Context;

namespace Redbox.Infrastructure.Persistance.Repositories
{
    public class ItemRepository : BaseRepository<Item, RedboxDbContext>
    {
        public ItemRepository(RedboxDbContext context) : base(context)
        {
        }
    }
}
