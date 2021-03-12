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
                .Where(c => c.UserId == teacherId)
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

        public void DeregisterStudentFromClass(int studentId, int teacherId)
        {
            throw new System.NotImplementedException();
        }
    }
}