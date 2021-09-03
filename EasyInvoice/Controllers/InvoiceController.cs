using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Services;
using EasyInvoice.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Exceptions;
using Persistence.Models;
using Microsoft.AspNetCore.Http;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvoiceDTO))]
        public ActionResult<IList<InvoiceDTO>> GetInvoices(InvoiceFilter filter)
        {
            string userId = User?.Identity?.Name;
            if (string.IsNullOrEmpty(userId))
                return Forbid();

            var invoices = InvoiceService.GetInvoices(filter);
            return invoices.Select((invoice) => new InvoiceDTO(invoice)).ToList();
        }

        [HttpGet("{invoiceId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvoiceDTO))]
        public ActionResult<InvoiceDTO> GetInvoice(int invoiceId)
        {
            string userId = User?.Identity?.Name;
            if (string.IsNullOrEmpty(userId))
                return Forbid();

            InvoiceDTO invoice = new InvoiceDTO(InvoiceService.GetInvoice(invoiceId));
            return Ok(invoice);
        }

        [HttpPost("Recent")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvoiceDTO))]
        public ActionResult<IList<InvoiceDTO>> GetRecentInvoices(SkipTake skipTake)
        {
            string userId = User?.Identity?.Name;
            if (string.IsNullOrEmpty(userId))
                return Forbid();

            var invoices = InvoiceService.GetRecentInvoices(int.Parse(userId), skipTake.Skip, skipTake.Take);
            return invoices.Select((invoice) => new InvoiceDTO(invoice)).ToList();
        }

        [HttpPost("New")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvoiceDTO))]
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