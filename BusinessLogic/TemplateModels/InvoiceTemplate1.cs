using System;
using System.Collections.Generic;
using Persistence.Models;

public class InvoiceTemplate1
{
    public int InvoiceId { get; set; }
    public int InvoiceNumber { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Total { get; set; }
    public IList<Lesson> Lessons { get; set; }
    public DateTime CreatedDate { get; set; }
    public string InvoiceUrl { get; set; }
    public string Logo { get; set; }

    public InvoiceTemplate1(Invoice invoice)
    {
        InvoiceUrl = invoice.InvoiceUrl;
        UserId = invoice.UserId;
        InvoiceId = invoice.InvoiceId;
        StartDate = invoice.StartDate;
        EndDate = invoice.EndDate;
        Total = invoice.Total;
        CreatedDate = invoice.CreatedDate;
        InvoiceNumber = invoice.InvoiceNumber;

        if (invoice.User != null)
        {
            User = invoice.User;
            Logo = invoice.User.LogoUrl;
        }

        if (invoice.Lessons != null)
            Lessons = invoice.Lessons;
    }
}