using ShoppingApp.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.PresentationLayer.Models
{
    public class CartVM
    {
        public List<Product> Products { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
