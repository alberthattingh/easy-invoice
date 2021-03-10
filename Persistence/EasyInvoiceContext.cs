using Microsoft.EntityFrameworkCore;
using Persistence.ModelConfig;
using Persistence.Models;

namespace Persistence
{
    public class EasyInvoiceContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<AccountDetails> AccountDetails { get; set; }
        public DbSet<StudentsPerInvoice> StudentsPerInvoices { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        
        public EasyInvoiceContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new InvoiceConfig());
            modelBuilder.ApplyConfiguration(new LessonConfig());
            modelBuilder.ApplyConfiguration(new QualificationConfig());
            modelBuilder.ApplyConfiguration(new StudentConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new AccountDetailsConfig());
            modelBuilder.ApplyConfiguration(new StudentsPerInvoiceConfig());
        }
    }
}