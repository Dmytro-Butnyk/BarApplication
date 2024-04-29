namespace DB_Coursework.Models.BaseClasses
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public double Quantity { get; set; }
        
        public Product() { }
        public Product(string name, decimal? price)
        {
            Name = name;
            Price = price;
            Quantity = 0;
        }
    }
}
