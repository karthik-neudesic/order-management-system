using OrderManagement.Business.Interfaces;
using OrderManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OrderManagement.Api.Controllers
{
    public class OrderController : ApiController
    {
        private IOrderManager service;

        public OrderController(IOrderManager service)
        {
            this.service = service;
        }

        [Route("api/order/createOrder")]
        [HttpPost]
        public int CreateOrder([FromBody] OrderDetails orderDetails)
        {
            return service.CreateOrder(orderDetails);
        }

        [Route("api/order/deleteOrder/{id}")]
        [HttpDelete]
        public bool DeleteOrder(int id)
        {
            service.DeleteOrder(id);
            return true;
        }

        [Route("api/order/getOrders/{userId}")]
        [HttpGet]
        public ICollection<OrderDetails> GetOrders(int userId)
        {
            var orderDetails = service.GetOrderDetails(userId);
            return orderDetails;
        }
    }
}