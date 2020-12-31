using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Repository.Models
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string ImageUrl { get; set; }
        public string Sku { get; set; }
        public string BarCode { get; set; }
        public int AddressId { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
    }
}
