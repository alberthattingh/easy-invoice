using System;
using System.Collections;
using System.Collections.Generic;
using EasyInvoice.DTOs;
using Persistence.Models;

namespace Persistence.Repositories
{
    public interface IInvoiceRepository
    {
        Invoice CreateNewInvoice(Invoice invoiceDetails, int[] studentIds);
        IList<Invoice> GetAllInvoicesByTeacher(int teacherId);
        Invoice GetInvoice(int invoiceId);
        IList<Invoice> GetInvoices(InvoiceFilter filter);
        IList<Invoice> GetRecentInvoices(int userId, int skip, int take);
    }
}