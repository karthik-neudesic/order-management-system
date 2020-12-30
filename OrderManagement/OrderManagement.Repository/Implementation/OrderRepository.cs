using OrderManagement.Repository.Interfaces;
using OrderManagement.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        public int CreateOrder(Order order, ICollection<OrderItem> orderItems)
        {
            using (var context = new OrderManagementDBContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Orders.Add(order);
                        context.SaveChanges();

                        foreach (var item in orderItems)
                        {
                            item.OrderId = order.Id;
                        }

                        context.OrderItems.AddRange(orderItems);
                        context.SaveChanges();

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
    }
}
