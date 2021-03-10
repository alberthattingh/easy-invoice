namespace Persistence.Models
{
    public class StudentsPerInvoice
    {
        public int StudentGroupId { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}