using Persistence.Models;

namespace Persistence.Repositories
{
    public interface ILessonsRepository
    {
        Lesson BookNewLesson(Lesson lessonDetails);
        void CancelLesson(int lessonId);
    }
}