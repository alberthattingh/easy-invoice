using System;
using Persistence.Models;

namespace EasyInvoice.Controllers
{
    public class CreatedInvoiceDTO
    {
        public int InvoiceId { get; set; }
        public int InvoiceNumber { get; set; }
        public string InvoiceUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Total { get; set; }

        public CreatedInvoiceDTO(Invoice invoice)
        {
            InvoiceUrl = invoice.InvoiceUrl;
            InvoiceId = invoice.InvoiceId;
            StartDate = invoice.StartDate;
            EndDate = invoice.EndDate;
            Total = invoice.Total;
            CreatedDate = invoice.CreatedDate;
            InvoiceNumber = invoice.InvoiceNumber;
        }
    }
}