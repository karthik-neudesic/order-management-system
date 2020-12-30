using OrderManagement.Business.Interfaces;
using OrderManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OrderManagement.Api.Controllers
{
    public class OrderController : ApiController
    {
        private IOrderManager service;

        public OrderController(IOrderManager service)
        {
            this.service = service;
        }

        public int Post([FromBody] OrderDetails orderDetails)
        {
            return service.CreateOrder(orderDetails);
        }

        public bool Delete(int id)
        {
            service.DeleteOrder(id);
            return true;
        }
    }
}