using System.Collections;
using System.Collections.Generic;
using Persistence.Models;

namespace Persistence.Repositories
{
    public interface IInvoiceRepository
    {
        Invoice CreateNewInvoice(Invoice invoice);
        IList<Invoice> GetAllIncoicesByTeacher(int teacherId);
    }
}