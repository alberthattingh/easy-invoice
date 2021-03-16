using System;
using System.Collections.Generic;
using System.Linq;
using Persistence.Models;
using Persistence.Repositories;

namespace BusinessLogic.Services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonsRepository LessonsRepository;
        private readonly IStudentsRepository StudentsRepository;

        public LessonService(ILessonsRepository lessonsRepository, IStudentsRepository studentsRepository)
        {
            LessonsRepository = lessonsRepository;
            StudentsRepository = studentsRepository;
        }

        public Lesson BookNewLesson(Lesson lessonDetails, int teacherId)
        {
            if (lessonDetails.StudentId == null)
                throw new Exception("StudentId cannot be null.");
            
            int studentId = lessonDetails.StudentId.Value;
            IList<Student> studentsInClass = StudentsRepository.GetAllStudentsByTeacher(teacherId);
            IList<int> studentIdsList = studentsInClass.Select(s => s.StudentId).ToList();

            if (!studentIdsList.Contains(studentId))
                throw new Exception("You cannot book a lesson for this student.");

            lessonDetails.UserId = teacherId;
            Lesson bookedLesson = LessonsRepository.CreateNewLesson(lessonDetails);
            return bookedLesson;
        }

        public void CancelLesson(int lessonId, int teacherId)
        {
            Lesson toDelete = LessonsRepository.GetLessonById(lessonId);
            if (toDelete.UserId != teacherId)
                throw new Exception("You do not have permission to delete this lesson.");
            
            LessonsRepository.DeleteLesson(lessonId);
        }

        public IList<Lesson> GetAllLessonsByTeacher(int teacherId)
        {
            return LessonsRepository.GetAllLessonsByTeacher(teacherId);
        }
    }
}