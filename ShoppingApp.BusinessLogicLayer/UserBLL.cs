using ShoppingApp.DataAccessLayer.Concrete;
using ShoppingApp.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp.BusinessLogicLayer
{
    public class UserBLL
    {
        private UserDAL _userDAL;

        public UserBLL()
        {
            _userDAL = new UserDAL();
        }

        public User GetUserByID(Guid id)
        {
            return _userDAL.GetByID(id);
        }

        public User Login(string username)
        {
            User u = _userDAL.GetByDefault(u => u.UserName == username);
            if (u != null)
                return u;
            else
                return null;
        }
    }
}
