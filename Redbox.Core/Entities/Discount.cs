using System.Collections.Generic;

namespace Redbox.Core.Entities
{
    public class Discount
    {
        public string Code { get; set; }
        public double Percentage { get; set; }

        public ICollection<ItemDiscount> ItemDiscounts { get; set; }
    }
}
