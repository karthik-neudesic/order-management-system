using OrderManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Business.Interfaces
{
    public interface IOrderManager
    {
        Task<int> CreateOrder(OrderDetails orderDetails);
        Task DeleteOrder(int orderId);
        Task<ICollection<OrderDetails>> GetOrderDetails(int userId);
        Task UpdateOrder(int orderId, int status);
    }
}
