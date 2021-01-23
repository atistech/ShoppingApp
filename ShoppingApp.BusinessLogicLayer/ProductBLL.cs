using ShoppingApp.DataAccessLayer.Concrete;
using ShoppingApp.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp.BusinessLogicLayer
{
    public class ProductBLL
    {
        private ProductDAL _productDAL;

        public ProductBLL()
        {
            _productDAL = new ProductDAL();
        }

        public List<Product> GetAllProducts()
        {
            //SeedSampleData d = new SeedSampleData();
            return _productDAL.GetActive();
        }

        public List<Product> GetProductsByCategoryID(Guid id)
        {
            return _productDAL.GetDefault(p => p.CategoryID == id);
        }

        public Product GetProductByID(Guid id)
        {
            return _productDAL.GetByID(id);
        }
    }
}
