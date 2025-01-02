namespace PanchaMukhiMarbles.API1.Models.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string? Thickness { get; set; }
        public string ImageUrl {  get; set; }
        public float Price { get; set; }
        public string? Stock { get; set; }
        public string Category { get; set; } 
    }
}
