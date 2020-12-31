using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Business.Models
{
    public class OrderDetails
    {
        public OrderDetails()
        {
            OrderItems = new List<OrderItem>();
        }

        public int OrderId { get; set; }
        public int OrderStatus { get; set; }
        public string Status { get; set; }
        public int AddressId { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
