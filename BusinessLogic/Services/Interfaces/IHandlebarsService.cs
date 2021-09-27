using BusinessLogic.Enums;
using Persistence.Models;

namespace BusinessLogic.Services
{
    public interface IHandlebarsService
    {
        string InvoiceToHtml(Invoice invoice, Template templateId);
    }
}