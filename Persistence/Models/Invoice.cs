using System;
using System.Collections.Generic;

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
        public IList<Lesson> Lessons { get; set; }
        public DateTime CreatedDate { get; set; }
        public string InvoiceUrl { get; set; }
    }
}