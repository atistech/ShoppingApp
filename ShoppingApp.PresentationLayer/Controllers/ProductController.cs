using Microsoft.AspNetCore.Mvc;
using ShoppingApp.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        private ProductBLL _productBLL = new ProductBLL();

        // Product/List/:id
        public IActionResult List(Guid id)
        {
            return View(_productBLL.GetProductsByCategoryID(id));
        }
    }
}
