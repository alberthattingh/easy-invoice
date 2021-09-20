using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Persistence.Models
{
    public class User
    {
        public int? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public string Cell { get; set; }
        public decimal? DefaultFee { get; set; }
        public IList<AccountDetails> AccountDetails { get; set; }
        public string LogoUrl { get; set; }
        public string LogoName { get; set; }
        public IFormFile LogoImage { get; set; }
    }
}
