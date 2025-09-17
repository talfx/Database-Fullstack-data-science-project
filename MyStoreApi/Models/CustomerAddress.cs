namespace MyStoreApi.Models
{
    public class CustomerAddress
    {
        public int CustomerId { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? FullAddress { get; set; }

        // Navigation property
        public Customer Customer { get; set; } = null!;
    }
}