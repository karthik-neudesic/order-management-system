using OrderManagement.Business.Interfaces;
using OrderManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace OrderManagement.Api.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        private IOrderManager service;

        public OrderController(IOrderManager service)
        {
            this.service = service;
        }

        [Route("createOrder")]
        [HttpPost]
        public async Task<int> CreateOrder([FromBody] OrderDetails orderDetails)
        {
            return await service.CreateOrder(orderDetails);
        }

        [Route("deleteOrder/{orderId}")]
        [HttpDelete]
        public async Task<bool> DeleteOrder(int orderId)
        {
            await service.DeleteOrder(orderId);
            return true;
        }

        [Route("getOrders/{userId}")]
        [HttpGet]
        public async Task<ICollection<OrderDetails>> GetOrders(int userId)
        {
            var orderDetails = await service.GetOrderDetails(userId);
            return orderDetails;
        }

        [Route("updateOrder/{orderId}/{status}")]
        [HttpPut]
        public async Task<bool> UpdateOrder(int orderId, int status)
        {
            await service.UpdateOrder(orderId, status);
            return true;
        }
    }
}