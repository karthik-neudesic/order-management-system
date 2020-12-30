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
        int CreateOrder(Order order);
    }
}
