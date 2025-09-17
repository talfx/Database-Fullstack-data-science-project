﻿namespace MyStoreApi.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public int? Age { get; set; }
        public DateOnly RegisterDate { get; set; }
        public DateTime? LastOnlineDate { get; set; }
    }
}