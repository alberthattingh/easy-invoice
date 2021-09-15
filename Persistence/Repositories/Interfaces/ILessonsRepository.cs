using System;
using System.Collections.Generic;
using Persistence.Models;

namespace Persistence.Repositories
{
    public interface ILessonsRepository
    {
        Lesson GetLessonById(int lessonId);
        Lesson CreateNewLesson(Lesson lessonDetails);
        void DeleteLesson(int lessonId);
        IList<Lesson> GetAllLessonsByTeacher(int teacherId);
        IList<Lesson> GetLessons(int[] studentIds, DateTime startDate, DateTime endDate, int userId);
    }
}