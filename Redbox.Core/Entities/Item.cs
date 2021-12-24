using System;
using System.Collections.Generic;

namespace Redbox.Core.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double BasePrice { get; set; }

        public ICollection<ItemDiscount> ItemDiscounts { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
