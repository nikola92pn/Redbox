using System;

namespace Redbox.Core.Entities
{
    public class CartItem
    {
        public int CartId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Cart Cart { get; set; }
        public Item Item { get; set; }
    }
}
