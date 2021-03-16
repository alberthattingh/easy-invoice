using System.Collections.Generic;
using Persistence.Models;

namespace BusinessLogic.Services
{
    public interface ILessonService
    {
        Lesson BookNewLesson(Lesson lessonDetails, int teacherId);
        void CancelLesson(int lessonId, int teacherId);
        IList<Lesson> GetAllLessonsByTeacher(int teacherId);
    }
}