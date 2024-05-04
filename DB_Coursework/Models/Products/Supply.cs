using DB_Coursework.Models.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Coursework.Models.Products
{
    public class Supply
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public double Quantity { get; set; }
        public DateTime SupplyTime { get; set; }
        public Supply () { }    
        public Supply(Product product, double quantity, DateTime dateTime)
        {
            Product = product;
            Quantity = quantity;
            SupplyTime = dateTime;
        }
    }
}
