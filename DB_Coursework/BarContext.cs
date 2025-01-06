using DB_Coursework.Models.BaseClasses;
using DB_Coursework.Models.Orders;
using DB_Coursework.Models.Products;
using DB_Coursework.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Coursework
{
    public class BarContext : DbContext
    {
        public BarContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer
                (@"data source=(localdb)\MSSQLLocalDB;initial catalog=Bar_DB;integrated security=True;MultipleActiveResultSets=true");

        //LOCAL
        //@"data source=(localdb)\MSSQLLocalDB;initial catalog=Bar_DB;integrated security=True;MultipleActiveResultSets=true"
        // CLOUD
        //@"data source=sql.bsite.net\MSSQL2016;initial catalog=sannido_Bar_DB;User ID=sannido_Bar_DB;Password=1234; Trust Server Certificate=True;"

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().UseTpcMappingStrategy();
        }
        // Father classes
        public virtual DbSet<Product> Products { get; set; }

        // Orders
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Table> Tables { get; set; }

        // Products
        public virtual DbSet<AlcoholDrink> AlcoholDrinks { get; set; }
        public virtual DbSet<Snack> Snacks { get; set; }
        public virtual DbSet<Supply> Supplies { get; set; }

        // Users
        public virtual DbSet<User> Users { get; set; }
    }
}
