using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Models
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public int OrderStatus { get; set; }
        public int AddressId { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
