using Persistence.Models;

namespace Persistence.Repositories
{
    public interface IClassRepository
    {
        Class AddStudentToTeachersClass(int studentId, int teacherId);
    }
}