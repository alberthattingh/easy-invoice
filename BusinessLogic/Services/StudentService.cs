
using System.Collections.Generic;
using Persistence.Models;
using Persistence.Repositories;

namespace BusinessLogic.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentsRepository StudentsRepository;
        private readonly IClassRepository ClassRepository;

        public StudentService(IStudentsRepository studentsRepository, IClassRepository classRepository)
        {
            StudentsRepository = studentsRepository;
            ClassRepository = classRepository;
        }

        public IList<Student> GetAllStudentsByTeacher(int teacherId)
        {
            return StudentsRepository.GetAllStudentsByTeacher(teacherId);
        }

        public Student AddStudentToClassList(Student student, int teacherId)
        {
            Student createdStudent = StudentsRepository.CreateNewStudent(student);
            Class createdClassEntry = ClassRepository.AddStudentToTeachersClass(createdStudent.StudentId, teacherId);

            return createdStudent;
        }
    }
}