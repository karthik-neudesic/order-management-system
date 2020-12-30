using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Repository.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string ImageUrl { get; set; }
        public string Sku { get; set; }
        public string BarCode { get; set; }
        public int AvailableQuantity { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
