using Microsoft.AspNetCore.Mvc;
using ShoppingApp.BusinessLogicLayer;
using ShoppingApp.DataAccessLayer.Concrete;
using ShoppingApp.EntitiesLayer;
using ShoppingApp.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        /*public IActionResult AddOrder()
        {

        }*/

        public IActionResult OrderDetails(Guid id)
        {
            return View(_orderDetailBLL.GetOrderDetailsByOrderID(id));
        }
    }
}
