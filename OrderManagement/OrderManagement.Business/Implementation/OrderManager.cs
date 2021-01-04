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

        public async Task<int> CreateOrder(OrderDetails orderDetails)
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

            return await service.CreateOrder(order, orderItems);
        }

        public async Task DeleteOrder(int orderId)
        {
            await service.DeleteOrder(orderId);
        }

        public async Task<ICollection<OrderDetails>> GetOrderDetails(int userId)
        {
            var orders = await service.GetOrderDetails(userId);
            var orderDetails = new List<OrderDetails>();
            var orderIds = orders.Select(x=>x.OrderId).Distinct().ToList();
            foreach (var orderId in orderIds)
            {
                var ordersById = orders.Where(x => x.OrderId == orderId).ToList();
                var orderData = ordersById.First();
                var order = new OrderDetails();
                order.OrderId = orderData.OrderId;
                order.Status = orderData.Status;
                order.UserName = orderData.UserName;
                order.EmailAddress = orderData.EmailAddress;
                order.AddressId = orderData.AddressId;
                foreach (var item in ordersById)
                {
                    order.OrderItems.Add(new OrderItem()
                    {
                        Quantity = item.Quantity,
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        Weight = item.Weight,
                        Height = item.Height,
                        ImageUrl = item.ImageUrl,
                        BarCode = item.BarCode,
                        Sku = item.Sku
                    });
                }

                orderDetails.Add(order);
            }

            return orderDetails;
        }

        public async Task UpdateOrder(int orderId, int status)
        {
            await service.UpdateOrder(orderId, status);
        }
    }
}
