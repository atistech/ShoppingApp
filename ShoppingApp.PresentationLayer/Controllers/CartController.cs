using Microsoft.AspNetCore.Mvc;
using ShoppingApp.BusinessLogicLayer;
using ShoppingApp.EntitiesLayer;
using ShoppingApp.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp.PresentationLayer.Controllers
{
    public class CartController : Controller
    {
        private ProductBLL _productBLL = new ProductBLL();

        [HttpGet]
        public IActionResult Cart()
        {
            CardVM vm = new CardVM();
            List<Product> list = new List<Product>();
            foreach (var item in Request.Cookies)
            {
                if (item.Key.StartsWith("CartItem"))
                {
                    Product p = _productBLL.GetProductByID(new Guid(item.Value));
                    if (p != null)
                    {
                        list.Add(p);
                        vm.TotalPrice += p.ProductPrice;
                    }
                }
            }
            vm.Products = list;
            return View(vm);
        }

        [HttpGet]
        public IActionResult AddToCart(Guid id)
        {
            var cookie = Request.Cookies.FirstOrDefault(c => c.Value == id.ToString());

            //cookie is default value
            if (cookie.Equals(default(KeyValuePair<string, string>)))
            {
                int new_order = CartItemCounter() + 1;
                Response.Cookies.Append("CartItem-" + new_order, id.ToString());
                return RedirectToAction("Cart");
            }
            else
                return RedirectToAction("Cart");
        }

        [HttpGet]
        public IActionResult RemoveFromCart(Guid id)
        {
            var cookie = Request.Cookies.FirstOrDefault(c => c.Value == id.ToString());

            //cookie is first element
            if (!cookie.Equals(default(KeyValuePair<string, string>)))
            {
                Response.Cookies.Delete(cookie.Key);
                return RedirectToAction("Cart");
            }
            //cookie is default value
            else
            {
                return RedirectToAction("Cart");
            }
        }

        [HttpGet]
        public IActionResult CartCount() => Json(new { count = CartItemCounter() });

        private int CartItemCounter()
        {
            int counter = 0;
            foreach (var item in Request.Cookies)
            {
                if (item.Key.StartsWith("CartItem"))
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
