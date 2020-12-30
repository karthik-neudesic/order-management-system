using OrderManagement.Business.Interfaces;
using OrderManagement.Business.Models;
using OrderManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Business.Implementation
{
    public class OrderManager : IOrderManager
    {
        private IOrderRepository service;

        public OrderManager(IOrderRepository service)
        {
            this.service = service;
        }

        public int CreateOrder(OrderDetails orderDetails)
        {
            return service.CreateOrder(null);
        }
    }
}
