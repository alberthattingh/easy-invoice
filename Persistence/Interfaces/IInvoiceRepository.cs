using System;
using System.Collections;
using System.Collections.Generic;
using Persistence.Models;

namespace Persistence.Repositories
{
    public interface IInvoiceRepository
    {
        Invoice CreateNewInvoice(Invoice invoiceDetails, int[] studentIds);
        IList<Invoice> GetAllIncoicesByTeacher(int teacherId);
    }
}