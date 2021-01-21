using ShoppingApp.CoreLayer.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp.EntitiesLayer
{
    public class Category : CoreEntity
    {
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
