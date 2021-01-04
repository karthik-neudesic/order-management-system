using OrderManagement.Repository.Interfaces;
using OrderManagement.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<int> CreateOrder(Order order, ICollection<OrderItem> orderItems)
        {
            using (var context = new OrderManagementDBContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Orders.Add(order);
                        await context.SaveChangesAsync();

                        foreach (var item in orderItems)
                        {
                            item.OrderId = order.Id;
                        }

                        context.OrderItems.AddRange(orderItems);
                        await context.SaveChangesAsync();

                        transaction.Commit();
                        return order.Id;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;

                    }
                }
            }
        }

        public async Task DeleteOrder(int orderId)
        {
            using (var context = new OrderManagementDBContext())
            {
                var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == orderId);
                if (order == null)
                {
                    throw new KeyNotFoundException($"{orderId} not found.");
                }

                order.Active = false;
                await context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<OrderDetails>> GetOrderDetails(int userId)
        {
            using (var context = new OrderManagementDBContext())
            {
                var param1 = new SqlParameter("@userId", userId);
                var orderDetails = await context.Database.SqlQuery<OrderDetails>("GetOrderDetails @userId", param1).ToListAsync();
                return orderDetails;
            }
        }

        public async Task UpdateOrder(int orderId, int status)
        {
            using (var context = new OrderManagementDBContext())
            {
                var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == orderId);
                if (order == null)
                {
                    throw new KeyNotFoundException($"{orderId} not found.");
                }

                order.OrderStatusId = status;
                await context.SaveChangesAsync();
            }
        }
    }
}
