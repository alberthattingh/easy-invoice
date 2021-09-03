using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly DbContext Context;

        public StudentsRepository(DbContext context)
        {
            Context = context;
        }

        public IList<Student> GetAllStudentsByTeacher(int teacherId)
        {
            var students = Context.Set<Class>()
                .Where(c => c.UserId == teacherId && c.IsActive)
                .Include(c => c.Student)
                .Select(c => c.Student);

            return students.ToList();
        }

        public Student CreateNewStudent(Student student)
        {
            Context.Set<Student>().Add(student);
            Context.SaveChanges();

            return student;
        }

        public Student UpdateStudentDetails(int studentId, Student updatedStudentDetails)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveStudent(int studentId, int userId)
        {
            var studentClass = Context.Set<Class>()
                .FirstOrDefault(c => c.StudentId == studentId && c.UserId == userId);

            if (studentClass == default) return false;
            
            studentClass.IsActive = false;
            Context.Set<Class>().Update(studentClass);
            Context.SaveChanges();
            return true;
        }

        public Student GetStudentById(int studentId, int userId)
        {
            var student = Context.Set<Class>()
                .Include(c => c.Student)
                .FirstOrDefault(c => c.StudentId == studentId && c.UserId == userId && c.IsActive)
                ?.Student;

            return student;
        }
    }
}