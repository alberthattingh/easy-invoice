using Persistence.Models;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using EasyInvoice.DTOs;

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
                Total = lessons.Sum(lesson => (decimal) lesson.Duration * (decimal) lesson.Student.FeePayable),
                CreatedDate = DateTime.Now,
                Lessons = lessons
            }, studentIds);

            return invoice;
        }

        public Invoice GetInvoice(int invoiceId)
        {
            return InvoiceRepository.GetInvoice(invoiceId);
        }

        public IList<Invoice> GetInvoices(InvoiceFilter filter)
        {
            return InvoiceRepository.GetInvoices(filter);
        }

        public IList<Invoice> GetRecentInvoices(int userId, int skip, int take)
        {
            return InvoiceRepository.GetRecentInvoices(userId, skip, take);
        }
    }
}
