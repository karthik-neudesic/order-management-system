using OrderManagement.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> CreateOrder(Order order, ICollection<OrderItem> orderItems);
        Task DeleteOrder(int orderId);
        Task<ICollection<OrderDetails>> GetOrderDetails(int userId);
        Task UpdateOrder(int orderId, int status);
    }
}
