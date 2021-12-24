using System;
using System.Collections.Generic;

namespace Redbox.Core.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
