using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Coursework.Models.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Table Table { get; set; }
    }
}
