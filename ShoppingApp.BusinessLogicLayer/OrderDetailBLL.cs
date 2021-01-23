﻿using ShoppingApp.DataAccessLayer.Concrete;
using ShoppingApp.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp.BusinessLogicLayer
{
    public class OrderDetailBLL
    {
        private OrderDetailDAL _orderDetailDAL;

        public OrderDetailBLL()
        {
            _orderDetailDAL = new OrderDetailDAL();
        }
        
        public List<OrderDetail> GetOrderDetailsByOrderID(Guid id)
        {
            List<OrderDetail> list = new List<OrderDetail>();
            list = _orderDetailDAL.GetDefault(d => d.OrderID == id );
            return list;
        }
    }
}
