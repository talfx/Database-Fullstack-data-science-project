﻿namespace MyStoreApi.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int AmountInStock { get; set; }
    }
}