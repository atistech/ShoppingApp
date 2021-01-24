using Microsoft.AspNetCore.Mvc;
using ShoppingApp.BusinessLogicLayer;
using ShoppingApp.CoreLayer.EntitiesLayer;
using ShoppingApp.DataAccessLayer.Concrete;
using ShoppingApp.EntitiesLayer;
using ShoppingApp.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShoppingApp.PresentationLayer.Controllers
{
    public class OrderController : Controller
    {
        private OrderBLL _orderBLL = new OrderBLL();
        private OrderDetailBLL _orderDetailBLL = new OrderDetailBLL();
        private ProductBLL _productBLL = new ProductBLL();

        public IActionResult List(Guid id)
        {
            return View(_orderBLL.GetOrdersByUserID(id));
        }

        [HttpPost]
        public IActionResult AddOrder(CartToOrderVM vm)
        {
            var userIdentity = (ClaimsIdentity)User.Identity;
            Order order1 = new Order();
            order1.ID = Guid.NewGuid();
            order1.Status = Status.Active;
            order1.OrderDescription = "Siparişlerim zamanında elime ulaşmıştır. Teşekkürler...";
            order1.OrderDate = DateTime.UtcNow;
            order1.UserID = new Guid(userIdentity.Name);
            order1.OrderPrice = vm.TotalPrice;
            _orderBLL.AddOrder(order1);

            for (int i = 0; i < vm.ProductIDs.Count; i++)
            {
                Product product = _productBLL
                    .GetProductByID(new Guid(vm.ProductIDs[i]));
                OrderDetail orderDetail = new OrderDetail()
                {
                    ID = Guid.NewGuid(),
                    Status = Status.Active,
                    OrderPrice = vm.Quantities[i] * product.ProductPrice,
                    Quantity = vm.Quantities[i],
                    OrderID = order1.ID,
                    ProductID = product.ID,
                };
                _orderDetailBLL.AddOrderDetail(orderDetail);

                var cookie = Request.Cookies.FirstOrDefault(c => c.Value == vm.ProductIDs[i]);
                if (!cookie.Equals(default(KeyValuePair<string, string>)))
                {
                    Response.Cookies.Delete(cookie.Key);
                }
            }

            return RedirectToAction("Cart", "Cart");
        }

        public IActionResult OrderDetails(Guid id)
        {
            OrderDetailsVM vm = new OrderDetailsVM();
            Order order = _orderBLL.GetOrderByID(id);
            List<OrderDetail> list = _orderDetailBLL
                .GetOrderDetailsByOrderID(id);
            foreach (var item in list)
            {
                item.Product = _productBLL.GetProductByID(item.ProductID);
            }
            vm.OrderDetails = list;
            vm.OrderDate = order.OrderDate.Day
                + "/" + order.OrderDate.Month
                + "/" + order.OrderDate.Year;
            vm.OrderPrice = order.OrderPrice;
            return View(vm);
        }
    }
}
