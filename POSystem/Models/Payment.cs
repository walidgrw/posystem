using System;
using System.ComponentModel.DataAnnotations;

namespace POSystem.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        public Order Order { get; set; }

        [Required]
        [Display(Name = "Payment Method")]
        public string Method { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        public DateTime PaidAt { get; set; } = DateTime.Now;
    }
}
