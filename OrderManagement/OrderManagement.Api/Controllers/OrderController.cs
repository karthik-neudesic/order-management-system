using OrderManagement.Business.Interfaces;
using OrderManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public int CreateOrder([FromBody] OrderDetails orderDetails)
        {
            return service.CreateOrder(orderDetails);
        }

        [Route("deleteOrder/{orderId}")]
        [HttpDelete]
        public bool DeleteOrder(int orderId)
        {
            service.DeleteOrder(orderId);
            return true;
        }

        [Route("getOrders/{userId}")]
        [HttpGet]
        public ICollection<OrderDetails> GetOrders(int userId)
        {
            var orderDetails = service.GetOrderDetails(userId);
            return orderDetails;
        }

        [Route("updateOrder/{orderId}/{status}")]
        [HttpPut]
        public bool UpdateOrder(int orderId, int status)
        {
            service.UpdateOrder(orderId, status);
            return true;
        }
    }
}