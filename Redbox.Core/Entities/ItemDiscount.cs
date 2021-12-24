using System;

namespace Redbox.Core.Entities
{
    public class ItemDiscount
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public string DiscountCode { get; set; }
        public Discount Discount { get; set; }
    }
}
