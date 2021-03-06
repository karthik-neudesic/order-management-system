﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Business.Models
{
    public class OrderItem
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string ImageUrl { get; set; }
        public string Sku { get; set; }
        public string BarCode { get; set; }
    }
}
