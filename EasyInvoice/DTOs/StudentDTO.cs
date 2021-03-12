using Persistence.Models;

namespace EasyInvoice.DTOs
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Cell { get; set; }
        public decimal? FeePayable { get; set; }

        public StudentDTO(Student studentEntity)
        {
            StudentId = studentEntity.StudentId;
            FirstName = studentEntity.FirstName;
            LastName = studentEntity.LastName;
            Email = studentEntity.Email;
            Cell = studentEntity.Cell;
            FeePayable = studentEntity.FeePayable;
        }
    }
}