using Microsoft.EntityFrameworkCore;
using ShoppingApp.CoreLayer.EntitiesLayer;
using ShoppingApp.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingApp.DataAccessLayer.Context
{
    public class RepositoryContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User -One To Many-> Order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserID);

            // Category -One To Many-> Product
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryID);

            // Order -One To Many-> OrderDetail
            modelBuilder.Entity<OrderDetail>()
                .HasOne(d => d.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(d => d.OrderID);

            // Product -One To MAny-> OrderDetail
            modelBuilder.Entity<OrderDetail>()
                .HasOne(d => d.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductID);

            //new SeedSampleData();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=.\\SQLExpress;Database=ShoppingApp;Trusted_Connection=True;");
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var item in modifiedEntries)
            {
                CoreEntity entity = item.Entity as CoreEntity;
                if (item != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        entity.Status = Status.Active;
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        if (entity.Status != Status.Deleted)
                            entity.Status = Status.Updated;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
