namespace Northwind.Shared
{
    public class Product : BaseEntity
    {
        public string QuantityPerUnit { get; set; }
        public double UnitPrice { get; set; }
        public double UnitInStock { get; set; }
        public Category Category { get; set; }
    }
}
