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
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OrderManagementDBContext>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
