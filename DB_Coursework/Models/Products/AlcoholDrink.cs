using DB_Coursework.Models.BaseClasses;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Coursework.Models.Products
{
    public class AlcoholDrink : Product
    {
        public double ABV { get; set; }

        public AlcoholDrink():base() { }
        public AlcoholDrink(string name, decimal price, double abv)
            :base(name, price)
        { 
            ABV = abv;
        }
    }
}
