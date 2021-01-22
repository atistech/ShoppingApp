using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.BusinessLogicLayer;
using ShoppingApp.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingApp.PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        private ProductBLL _productBLL = new ProductBLL();
        private CategoryBLL _categoryBLL = new CategoryBLL();

        // Product/List/:id
        public IActionResult ListByCategory(Guid id)
        {
            ProductListVM vm = new ProductListVM();
            vm.categories = _categoryBLL.GetAllCategories();
            vm.products = _productBLL.GetProductsByCategoryID(id);
            return View("List", vm);
        }

        // Product/List
        public IActionResult List()
        {
            ProductListVM vm = new ProductListVM();
            vm.categories = _categoryBLL.GetAllCategories();
            vm.products = _productBLL.GetAllProducts();
            return View(vm);
        }
    }
}
