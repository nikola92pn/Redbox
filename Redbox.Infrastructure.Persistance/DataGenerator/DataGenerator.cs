using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Redbox.Core.Entities;
using Redbox.Infrastructure.Persistance.Context;
using System;

namespace Redbox.Infrastructure.Persistance.DataGenerator
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RedboxDbContext(serviceProvider.GetRequiredService<DbContextOptions<RedboxDbContext>>()))
            {
                var item1 = new Item { Id = 1, Name = "item1", BasePrice = 100 };
                var item2 = new Item { Id = 2, Name = "item2", BasePrice = 150 };
                var item3 = new Item { Id = 3, Name = "item3", BasePrice = 500 };
                var item4 = new Item { Id = 4, Name = "itemWithoutDiscount", BasePrice = 99 };

                var discount = new Discount { Code = "discount15", Percentage = 15 };

                var item1Discount = new ItemDiscount { ItemId = item1.Id, DiscountCode = discount.Code };
                var item2Discount = new ItemDiscount { ItemId = item2.Id, DiscountCode = discount.Code };
                var item3Discount = new ItemDiscount { ItemId = item3.Id, DiscountCode = discount.Code };

                context.Items.AddRange(item1, item2, item3, item4);
                context.Discounts.AddRange(discount);
                context.ItemDiscounts.AddRange(item1Discount, item2Discount, item3Discount);


                context.SaveChanges();
            }
        }
    }
}
