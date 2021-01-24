using ShoppingApp.DataAccessLayer.Concrete;
using ShoppingApp.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp.BusinessLogicLayer
{
    public class OrderBLL
    {
        private OrderDAL _orderDAL;

        public OrderBLL()
        {
            _orderDAL = new OrderDAL();
        }

        public List<Order> GetOrdersByUserID(Guid id)
        {
            return _orderDAL.GetDefault(o => o.UserID == id);
        }

        public Order GetOrderByID(Guid id)
        {
            return _orderDAL.GetByID(id);
        }
    }
}
