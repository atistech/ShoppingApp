﻿using ShoppingApp.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.PresentationLayer.Models
{
    public class ProductListVM
    {
        public List<Category> categories { get; set; }
        public List<Product> products { get; set; }
    }
}
