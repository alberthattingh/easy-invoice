using Persistence.Models;

namespace EasyInvoice.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Cell { get; set; }
        public decimal? DefaultFee { get; set; }
        public string Logo { get; set; }

        public UserDTO(User user)
        {
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Cell = user.Cell;
            DefaultFee = user.DefaultFee;
            Logo = user.Logo;
        }
    }
}