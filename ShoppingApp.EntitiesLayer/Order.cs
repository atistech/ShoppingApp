using ShoppingApp.CoreLayer.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp.EntitiesLayer
{
    public class Order : CoreEntity
    {
        public string OrderDescription { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderPrice { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Guid UserID { get; set; }
        public User User { get; set; }
    }
}
