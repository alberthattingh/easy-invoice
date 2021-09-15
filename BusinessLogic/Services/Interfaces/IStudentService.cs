using System.Collections.Generic;
using Persistence.Models;

namespace BusinessLogic.Services
{
    public interface IStudentService
    {
        IList<Student> GetAllStudentsByTeacher(int teacherId);
        Student AddStudentToClassList(Student student, int teacherId);
        bool DeleteStudent(int studentId, int userId);
    }
}