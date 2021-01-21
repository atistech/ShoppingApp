using ShoppingApp.DataAccessLayer.Concrete;
using ShoppingApp.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp.BusinessLogicLayer
{
    public class CategoryBLL
    {
        private CategoryDAL _categoryDAL;

        public CategoryBLL()
        {
            _categoryDAL = new CategoryDAL();
        }

        public List<Category> GetCategoriesAll()
        {
            return _categoryDAL.GetActive();
        }
    }
}
