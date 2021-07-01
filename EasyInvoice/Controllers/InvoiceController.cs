using BusinessLogic.Services;
using EasyInvoice.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Exceptions;
using Persistence.Models;
using System.Threading.Tasks;

namespace EasyInvoice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService InvoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            InvoiceService = invoiceService;
        }

        [HttpPost]
        public ActionResult<InvoiceDTO> CreateNewInvoice(CreateInvoiceDTO invoiceDetails)
        {
            string userId = User?.Identity?.Name;
            if (string.IsNullOrEmpty(userId))
                return Forbid();

            if (invoiceDetails.StudentIds?.Length < 1)
                return BadRequest("One or more required fields were not supplied.");

            try
            {
                Invoice invoice = InvoiceService.CreateNewInvoice(invoiceDetails.StudentIds, invoiceDetails.StartDate, invoiceDetails.EndDate, userId);
                return Ok(new InvoiceDTO(invoice));
            }
            catch (StudentNotFoundException)
            {
                return BadRequest("One or more students could not be found.");
            }
            
        }
    }
}