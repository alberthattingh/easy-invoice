namespace Persistence.Models
{
    public class AccountDetails
    {
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string AccountType { get; set; }
        public string Bank { get; set; }
        public string AccountHolder { get; set; }
        public string AccountNumber { get; set; }
        public string BranchCode { get; set; }
        public string PaymentInstruction { get; set; }
        public bool IsActive { get; set; }
    }
}