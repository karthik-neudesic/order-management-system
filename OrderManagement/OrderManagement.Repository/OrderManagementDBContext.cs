using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OrderManagement.Repository.Models;

namespace OrderManagement.Repository
{
    public class OrderManagementDBContext : DbContext
    {
        public OrderManagementDBContext() : base("name=OrderManagementConnectionString")
        {
            Database.SetInitializer(new OrderManagementDBInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
