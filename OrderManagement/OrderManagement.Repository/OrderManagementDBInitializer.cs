using OrderManagement.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Repository
{
    public class OrderManagementDBInitializer : DropCreateDatabaseIfModelChanges<OrderManagementDBContext>
    {
        protected override void Seed(OrderManagementDBContext context)
        {
            var orderStatuses = new List<OrderStatus>();
            orderStatuses.Add(new OrderStatus() { Status = "Placed" });
            orderStatuses.Add(new OrderStatus() { Status = "Approved" });
            orderStatuses.Add(new OrderStatus() { Status = "Cancelled" });
            orderStatuses.Add(new OrderStatus() { Status = "In Delivery" });
            orderStatuses.Add(new OrderStatus() { Status = "Completed" });


            var roles = new List<Role>();
            roles.Add(new Role() { Id = 1, Name = "Administrator" });
            roles.Add(new Role() { Id =2, Name = "Buyer" });

            var users = new List<User>();
            users.Add(new User() { Id = 1, Name = "Test user 1", EmailAddress = "test.user1@gmail.com", RoleId = 1 });
            users.Add(new User() { Id = 2, Name = "Test user 2", EmailAddress = "test.user2@gmail.com", RoleId = 2 });

            var addresses = new List<Address>();
            addresses.Add(new Address() { UserId = 1, Address1 = "Address 1", Address2 = "Address 2", PostalCode = "12345" });
            addresses.Add(new Address() { UserId = 2, Address1 = "Address 1 data", Address2 = "Address 2 data", PostalCode = "98765" });

            var products = new List<Product>();
            products.Add(new Product() { Name = "Product 1", Weight = 100, Height = 100, ImageUrl = "Image url", Sku = "12345", BarCode = "12345", AvailableQuantity = 100 });
            products.Add(new Product() { Name = "Product 2", Weight = 100, Height = 100, ImageUrl = "Image url", Sku = "98765", BarCode = "234234", AvailableQuantity = 100 });
            products.Add(new Product() { Name = "Product 3", Weight = 100, Height = 100, ImageUrl = "Image url", Sku = "124234", BarCode = "22535", AvailableQuantity = 100 });
            products.Add(new Product() { Name = "Product 4", Weight = 100, Height = 100, ImageUrl = "Image url", Sku = "22222", BarCode = "66666", AvailableQuantity = 100 });
            products.Add(new Product() { Name = "Product 5", Weight = 100, Height = 100, ImageUrl = "Image url", Sku = "33333", BarCode = "77777", AvailableQuantity = 100 });

            context.OrderStatuses.AddRange(orderStatuses);
            context.Roles.AddRange(roles);
            context.Users.AddRange(users);
            context.Addresses.AddRange(addresses);
            context.Products.AddRange(products);

            base.Seed(context);
        }
    }
}
