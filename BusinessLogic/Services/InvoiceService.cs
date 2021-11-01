using Persistence.Models;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using EasyInvoice.DTOs;
using BusinessLogic.Enums;
using System.IO;
using BusinessLogic.Extensions;

namespace BusinessLogic.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository InvoiceRepository;
        private readonly ILessonsRepository LessonsRepository;
        private readonly IPdfService PdfService;
        private readonly IHandlebarsService HandlebarsService;

        public InvoiceService(IInvoiceRepository invoiceRepository, ILessonsRepository lessonsRepository, IPdfService pdfService, IHandlebarsService handlebarsService)
        {
            InvoiceRepository = invoiceRepository;
            LessonsRepository = lessonsRepository;
            PdfService = pdfService;
            HandlebarsService = handlebarsService;
        }

        public Invoice CreateNewInvoice(int[] studentIds, DateTime? startDate, DateTime? endDate, string userId)
        {
            DateTime start = startDate ?? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime end = endDate ?? DateTime.Now;

            IList<Lesson> lessons = LessonsRepository.GetLessons(studentIds, start, end, int.Parse(userId));

            Invoice invoice = InvoiceRepository.CreateNewInvoice(new Invoice()
            {
                StartDate = new DateTime(start.Year, start.Month, start.Day, 0, 0, 0),
                EndDate = new DateTime(end.Year, end.Month, end.Day, 23, 59, 59),
                UserId = int.Parse(userId),
                Total = lessons.Sum(lesson => (decimal)lesson.Duration * (decimal)lesson.Student.FeePayable),
                CreatedDate = DateTime.Now,
                Lessons = lessons
            }, studentIds);

            var invoiceHtml = HandlebarsService.InvoiceToHtml(invoice, Template.InvoiceTemplate1);
            var invoiceUrl = PdfService.GeneratePdf(invoiceHtml);
            invoice.InvoiceUrl = invoiceUrl;

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
