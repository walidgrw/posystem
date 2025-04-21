using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POSystem.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public decimal Subtotal { get; set; }

        public decimal VAT { get; set; }

        public decimal Total { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public string Status { get; set; } = "Completed";

        public string CreatedBy { get; set; }

        public List<Payment> Payments { get; set; }

    }
}
