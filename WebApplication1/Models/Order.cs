namespace WebApplication1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Amount { get; set; }

        // Foreign key for Product relationship
        public int ProductId { get; set; }

        // Navigation property to Product (Required reference navigation to principal)
        public Product? Product { get; set; }

    }
}
