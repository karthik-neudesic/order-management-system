﻿using OrderManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Business.Interfaces
{
    public interface IOrderManager
    {
        int CreateOrder(OrderDetails orderDetails);
    }
}