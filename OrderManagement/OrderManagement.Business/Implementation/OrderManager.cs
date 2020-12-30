using OrderManagement.Business.Interfaces;
using OrderManagement.Business.Models;
using OrderManagement.Repository.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using models = OrderManagement.Repository.Models;

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
            orderDetails.OrderStatus = 1;
            var order = new models.Order();
            var orderItems = new List<models.OrderItem>();
            order.OrderStatusId = orderDetails.OrderStatus;
            order.AddressId = orderDetails.AddressId;
            order.Active = true;
            order.CreateDate = DateTime.Now;
            foreach (var orderItem in orderDetails.OrderItems)
            {
                var item = new models.OrderItem();
                item.ProductId = orderItem.ProductId;
                item.Quantity = orderItem.Quantity;
                item.CreateDate = DateTime.Now;
                orderItems.Add(item);
            }

            return service.CreateOrder(order, orderItems);
        }

        public void DeleteOrder(int orderId)
        {
            service.DeleteOrder(orderId);
        }
    }
}
