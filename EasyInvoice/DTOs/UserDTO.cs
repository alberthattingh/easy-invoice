using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Persistence.Models;

namespace EasyInvoice.DTOs
{
    public class UserDTO
    {
        public int? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Cell { get; set; }
        public decimal? DefaultFee { get; set; }
        public string LogoUrl { get; set; }
        public string LogoName { get; set; }
        public string Token { get; set; }
        public IList<BankingDetailsDto> BankingDetails { get; set; }

        public UserDTO(User user)
        {
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Cell = user.Cell;
            DefaultFee = user.DefaultFee;
            LogoUrl = user.LogoUrl;
            LogoName = user.LogoName;

            if (user.AccountDetails != null && user.AccountDetails.Any())
                BankingDetails = user.AccountDetails
                    .Select(account => new BankingDetailsDto(account))
                    .ToList();
        }
    }
}