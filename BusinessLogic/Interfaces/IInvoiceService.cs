using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IInvoiceService
    {
        Invoice CreateNewInvoice(int[] studentIds, DateTime? startDate, DateTime? endDate, string userId);
    }
}
