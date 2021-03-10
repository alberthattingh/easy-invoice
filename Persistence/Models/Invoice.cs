using System;

namespace Persistence.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Total { get; set; }
    }
}