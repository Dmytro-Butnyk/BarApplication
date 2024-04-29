using DB_Coursework.Models.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Coursework.Models.Products
{
    public class Snack : Product
    {
        public string Type { get; set; }
        public Snack (): base() { }
        public Snack(string name, decimal price, string type)
           : base(name, price)
        {
            Type = type;
        }
    }
}