using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BlackBox.Entities.Ordering;

namespace BlackBox.Models.Ordering
{
    public class CartModel
    {
        public IEnumerable<Cart> Carts { get; set; }

        public int Count { get; set; }

        public double Price { get; set; }
    }
}
