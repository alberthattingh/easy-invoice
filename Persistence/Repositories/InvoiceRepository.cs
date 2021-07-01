using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Persistence.Exceptions;
using Persistence.Models;

namespace Persistence.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DbContext Context;

        public InvoiceRepository(DbContext context)
        {
            Context = context;
        }

        public Invoice CreateNewInvoice(Invoice invoiceDetails, int[] studentIds)
        {
            var invoice = new Invoice()
            {
                StartDate = invoiceDetails.StartDate,
                EndDate = invoiceDetails.EndDate,
                UserId = invoiceDetails.UserId,
                Total = invoiceDetails.Total
            };

            Context.Set<Invoice>().Add(invoice);
            Context.SaveChanges();

            try
            {
                foreach (var id in studentIds)
                {
                    var studentInvoice = new StudentsPerInvoice()
                    {
                        InvoiceId = invoice.InvoiceId,
                        StudentId = id
                    };
                    Context.Set<StudentsPerInvoice>().Add(studentInvoice);
                }
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                Context.Set<Invoice>().Remove(invoice);
                Context.SaveChanges();
                throw new StudentNotFoundException("A student could not be found.", e);
            }
            

            return invoice;
        }

        public IList<Invoice> GetAllIncoicesByTeacher(int teacherId)
        {
            throw new System.NotImplementedException();
        }
    }
}