using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyInvoice.DTOs
{
    public class InvoiceDTO
    {
        public int InvoiceId { get; set; }
        public int InvoiceNumber { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<LessonDTO> Lessons { get; set; }
        public string InvoiceUrl { get; set; }

        public InvoiceDTO(Invoice invoice)
        {
            InvoiceId = invoice.InvoiceId;
            InvoiceNumber = invoice.InvoiceNumber;
            UserId = invoice.UserId;
            StartDate = invoice.StartDate;
            EndDate = invoice.EndDate;
            Total = invoice.Total;
            CreatedDate = invoice.CreatedDate;
            InvoiceUrl = invoice.InvoiceUrl;

            if (invoice.User != null)
                User = new UserDTO(invoice.User);

            if (invoice.Lessons != null)
                Lessons = invoice.Lessons.Select(lesson => new LessonDTO(lesson)).ToList();
        }
    }
}
