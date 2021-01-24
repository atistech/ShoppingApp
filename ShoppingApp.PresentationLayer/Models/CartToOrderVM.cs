using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.PresentationLayer.Models
{
    public class CartToOrderVM
    {
        public List<string> ProductIDs { get; set; }
        public List<int> Quantities { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
