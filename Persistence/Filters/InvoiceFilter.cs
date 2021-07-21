using System;

namespace EasyInvoice.DTOs
{
    public class InvoiceFilter
    {
        public int? TeacherId { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}