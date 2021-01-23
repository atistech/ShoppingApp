using ShoppingApp.DataAccessLayer.Concrete;
using ShoppingApp.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp.BusinessLogicLayer
{
    class OrderDetailBLL
    {
        private OrderDetailDAL _orderDetailDAL;

        public OrderDetailBLL()
        {
            _orderDetailDAL = new OrderDetailDAL();
        }
        /*
        public OrderDetail GetOrderDetailByID()
        {

        }*/
    }
}
