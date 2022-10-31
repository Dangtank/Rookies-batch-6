namespace Day2.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Manufacture { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
    }
}