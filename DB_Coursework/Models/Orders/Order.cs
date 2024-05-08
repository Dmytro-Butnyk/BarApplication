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
        public bool IsOpened { get; set; }

        public Order() { }
        public Order(DateTime date, Table table, bool isOpened)
        {
            Date = date;
            Table = table;
            IsOpened = isOpened;
        }
        public override string ToString()
        {
           return  $"Id: {Id} | Date: {Date} | Table: {Table.Number} | IsOpened: {IsOpened}";
        }
    }
}
