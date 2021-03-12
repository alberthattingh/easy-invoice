using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly DbContext Context;

        public ClassRepository(DbContext context)
        {
            Context = context;
        }

        public Class AddStudentToTeachersClass(int studentId, int teacherId)
        {
            Class c = new Class()
            {
                StudentId = studentId,
                UserId = teacherId,
                IsActive = true
            };

            Context.Set<Class>().Add(c);
            Context.SaveChanges();

            return c;
        }
    }
}