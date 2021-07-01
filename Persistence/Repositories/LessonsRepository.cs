using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence.Repositories
{
    public class LessonsRepository : ILessonsRepository
    {
        private readonly DbContext Context;

        public LessonsRepository(DbContext context)
        {
            Context = context;
        }

        public Lesson GetLessonById(int lessonId)
        {
            var lesson = Context.Set<Lesson>()
                .Include(l => l.Student)
                .Include(l => l.User)
                .FirstOrDefault(l => l.LessonId == lessonId);
            
            return lesson;
        }

        public Lesson CreateNewLesson(Lesson lessonDetails)
        {
            lessonDetails.LessonId = null;

            Context.Set<Lesson>().Add(lessonDetails);
            Context.SaveChanges();

            return lessonDetails;
        }

        public void DeleteLesson(int lessonId)
        {
            Lesson lesson = GetLessonById(lessonId);

            Context.Set<Lesson>().Remove(lesson);
            Context.SaveChanges();
        }

        public IList<Lesson> GetAllLessonsByTeacher(int teacherId)
        {
            var lessons = Context.Set<Lesson>()
                .Include(l => l.Student)
                .Where(l => l.UserId == teacherId);

            return lessons.ToList();
        }

        public IList<Lesson> GetLessons(int[] studentIds, DateTime startDate, DateTime endDate, int userId)
        {
            var lessons = Context.Set<Lesson>()
                .Include(l => l.Student)
                .Where(l => l.UserId == userId)
                .Where(l => studentIds.Contains(l.Student.StudentId))
                .Where(l => l.LessonDate > startDate)
                .Where(l => l.LessonDate < endDate);

            return lessons.ToList();
        }
    }
}