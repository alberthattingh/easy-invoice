using Persistence.Models;

namespace EasyInvoice.DTOs
{
    public class BankingDetailsDto
    {
        public int AccountId { get; set; }
        public string AccountType { get; set; }
        public string Bank { get; set; }
        public string AccountHolder { get; set; }
        public string AccountNumber { get; set; }
        public string BranchCode { get; set; }
        public string PaymentInstruction { get; set; }
        public bool IsActive { get; set; }
        
        public BankingDetailsDto(AccountDetails details)
        {
            AccountId = details.AccountId;
            AccountType = details.AccountType;
            Bank = details.Bank;
            AccountHolder = details.AccountHolder;
            AccountNumber = details.AccountNumber;
            BranchCode = details.BranchCode;
            PaymentInstruction = details.PaymentInstruction;
            IsActive = details.IsActive;
        }
    }
}