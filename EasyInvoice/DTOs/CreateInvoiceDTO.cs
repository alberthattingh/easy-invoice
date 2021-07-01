using System;

namespace EasyInvoice.Controllers
{
    public class CreateInvoiceDTO
    {
        public int[] StudentIds { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}