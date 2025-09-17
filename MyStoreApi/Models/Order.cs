namespace MyStoreApi.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateOnly OrderDate { get; set; }
        public decimal? OrderTotal { get; set; }
        public string Status { get; set; } = string.Empty;

        // Navigation property
        public Customer Customer { get; set; } = null!;
    }
}