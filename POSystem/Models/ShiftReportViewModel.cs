using System;
using System.Collections.Generic;

namespace POSystem.Models
{
    public class ShiftReportViewModel
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public int TotalOrders { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalVAT { get; set; }
        public decimal TotalSubtotal { get; set; }

        public Dictionary<string, decimal> PaymentSummary { get; set; }
        public List<string> Staff { get; set; }
    }
}
