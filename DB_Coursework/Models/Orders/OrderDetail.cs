using DB_Coursework.Models.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Coursework.Models.Orders
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public double Quantity { get; set; }
        public Order Order { get; set; }
        public OrderDetail() { }
        public OrderDetail(Product product, double quantity, Order order)
        {
            Product = product;
            Quantity = quantity;    
            Order = order;
        }
    }
}
