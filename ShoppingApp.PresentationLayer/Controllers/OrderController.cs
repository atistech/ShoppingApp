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
    public class OrderController : Controller
    {
        private OrderBLL _orderBLL = new OrderBLL();

        public IActionResult List(Guid id)
        {
            List<Order> list = _orderBLL.GetOrdersByUserID(id);

            List<OrderListVM> vm = new List<OrderListVM>();
            if(list.Count != 0)
                foreach (var item in list)
                    vm.Add(new OrderListVM{
                        ID = item.ID,
                        OrderDescription = item.OrderDescription,
                        OrderDate = item.OrderDate
                    });
            
            return View(vm);
        }
    }
}
