﻿using DB_Coursework.Models.BaseClasses;
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
    }
}
