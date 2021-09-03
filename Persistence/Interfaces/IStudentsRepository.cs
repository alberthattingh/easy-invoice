using System.Collections;
using System.Collections.Generic;
using Persistence.Models;

namespace Persistence.Repositories
{
    public interface IStudentsRepository
    {
        IList<Student> GetAllStudentsByTeacher(int teacherId);
        Student CreateNewStudent(Student student);
        Student UpdateStudentDetails(int studentId, Student updatedStudentDetails);
        bool RemoveStudent(int studentId, int userId);
        Student GetStudentById(int studentId, int userId);
    }
}