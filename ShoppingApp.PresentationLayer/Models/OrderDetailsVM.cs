using ShoppingApp.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.PresentationLayer.Models
{
    public class OrderDetailsVM
    {
        public List<OrderDetail> OrderDetails { get; set; }
        public string OrderDate { get; set; }
        public decimal OrderPrice { get; set; }
    }
}
