using Persistence.Models;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository InvoiceRepository;
        private readonly ILessonsRepository LessonsRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository, ILessonsRepository lessonsRepository)
        {
            InvoiceRepository = invoiceRepository;
            LessonsRepository = lessonsRepository;
        }

        public Invoice CreateNewInvoice(int[] studentIds, DateTime? startDate, DateTime? endDate, string userId)
        {
            DateTime start = startDate ?? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime end = endDate ?? DateTime.Now;

            IList<Lesson> lessons = LessonsRepository.GetLessons(studentIds, start, end, int.Parse(userId));

            Invoice invoice = InvoiceRepository.CreateNewInvoice(new Invoice()
            {
                StartDate = start,
                EndDate = end,
                UserId = int.Parse(userId),
                Total = lessons.Sum(lesson => (decimal) lesson.Duration * (decimal) lesson.Student.FeePayable)
            }, studentIds);

            invoice.Lessons = lessons;
            return invoice;
        }
    }
}
