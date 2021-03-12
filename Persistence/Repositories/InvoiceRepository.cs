using System.Collections.Generic;
using Persistence.Models;

namespace Persistence.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public Invoice CreateNewInvoice(Invoice invoice)
        {
            throw new System.NotImplementedException();
        }

        public IList<Invoice> GetAllIncoicesByTeacher(int teacherId)
        {
            throw new System.NotImplementedException();
        }
    }
}