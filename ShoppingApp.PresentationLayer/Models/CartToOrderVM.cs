﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.PresentationLayer.Models
{
    public class CartToOrderVM
    {
        public List<Guid> ProductIDs { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
