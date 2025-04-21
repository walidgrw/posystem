using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POSystem.Models
{
    public class OrderViewModel
    {
        // Selected items and their quantities
        public List<int> ItemIds { get; set; }
        public List<int> Quantities { get; set; }

        // Optional: used on the payment page
        public List<string> PaymentMethods { get; set; }
        public List<decimal> PaymentAmounts { get; set; }

        // Displayed back to the user
        public decimal Total { get; set; }
        public decimal Subtotal { get; set; }
        public decimal VAT { get; set; }

        // Used for summary display
        public List<MenuItemSelection> SelectedItems { get; set; } = new();
    }

    public class MenuItemSelection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public decimal Total => Quantity * Price;
    }
}
