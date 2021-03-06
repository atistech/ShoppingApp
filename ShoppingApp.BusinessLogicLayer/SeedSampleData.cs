﻿using Microsoft.EntityFrameworkCore;
using ShoppingApp.CoreLayer.EntitiesLayer;
using ShoppingApp.DataAccessLayer.Context;
using ShoppingApp.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp.BusinessLogicLayer
{
    public class SeedSampleData
    {
        private RepositoryContext _context = new RepositoryContext();
        public SeedSampleData()
        {
            #region Sample User Data
            User user1 = new User();
            user1.ID = Guid.NewGuid();
            user1.Status = Status.Active;
            user1.UserName = "blue.atakan";
            user1.Password = "35933593";
            user1.FirstName = "Atakan";
            user1.LastName = "Senturk";
            user1.Age = 23;
            #endregion

            #region Sample Category Data
            string[] category_names = { "Telefon", "Bilgisayar", "Televizyon" };
            Category[] categories = new Category[3];
            for (int i = 0; i < 3; i++)
            {
                categories[i] = new Category
                {
                    ID = Guid.NewGuid(),
                    Status = Status.Active,
                    CategoryName = category_names[i]
                };
            }
            #endregion

            #region Sample Product Data
            string[] product_names = { "LG G4", "Huawei", "Apple IPhone",
                "Lenovo Laptop", "Asus Laptop", "Casper PC", 
                "Arçelik TV", "Vestel TV", "Samsung Smart TV"};
            int[] product_prices = { 1500, 3000, 4500,
                5000, 7000, 3500,
                1500, 2500, 5500};
            int[] product_codes = { 654321, 654321, 654321,
                123456, 123456, 123456,
                0, 0, 0};
            Product[] products = new Product[9];
            int category_index = 0;
            for (int i = 0; i < 9; i++)
            {
                products[i] = new Product
                {
                    ID = Guid.NewGuid(),
                    Status = Status.Active,
                    ProductName = product_names[i],
                    ProductCode = product_codes[i].ToString(),
                    ProductPrice = product_prices[i],
                    CategoryID = categories[category_index].ID,
                    Category = categories[category_index],
                };

                if (i == 2 || i == 5)
                    category_index++;
            }
            #endregion

            #region Sample Order Data
            Order order1 = new Order();
            order1.ID = Guid.NewGuid();
            order1.Status = Status.Active;
            order1.OrderDescription = "Siparişlerim zamanında elime ulaşmıştır. Teşekkürler...";
            order1.OrderDate = new DateTime(2021, 1, 18);
            order1.UserID = user1.ID;
            order1.User = user1;
            order1.OrderPrice = 9000;
            #endregion

            #region Sample OrderDetail Data
            OrderDetail[] order_details = new OrderDetail[3];
            for (int i = 0; i < 2; i++)
            {
                order_details[i] = new OrderDetail()
                {
                    ID = Guid.NewGuid(),
                    Status = Status.Active,
                    OrderPrice = 2 * products[i].ProductPrice,
                    Quantity = 2,
                    OrderID = order1.ID,
                    Order = order1,
                    ProductID = products[i].ID,
                    Product = products[i]
                };
            }
            #endregion

            _context.Users.Add(user1);
            _context.Categories.AddRange(categories);
            _context.Products.AddRange(products);
            _context.Orders.Add(order1);
            _context.OrderDetails.AddRange(order_details);
            _context.SaveChanges();
        }
    }
}
