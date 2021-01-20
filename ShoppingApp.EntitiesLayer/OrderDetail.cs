using ShoppingApp.CoreLayer.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp.EntitiesLayer
{
    public class OrderDetail : CoreEntity
    {
        public decimal OrderPrice { get; set; }
        public int Quantity { get; set; }

        public Guid ProductID { get; set; }
        public Product Product { get; set; }

        public Guid OrderID { get; set; }
        public Order Order { get; set; }
    }
}
