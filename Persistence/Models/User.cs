using System.Collections.Generic;

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
        public string Logo { get; set; }
    }
}
