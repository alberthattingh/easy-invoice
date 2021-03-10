﻿namespace Persistence.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName  { get; set; }
        public string LastName { get; set; }
        public string Email  { get; set; }
        public string Cell  { get; set; }
        public decimal FeePayable { get; set; }
    }
}