using System;
using System.Collections.Generic;
using BusinessLogic.Services;
using EasyInvoice.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Models;

namespace EasyInvoice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class LessonsController : Controller
    {
        private readonly ILessonService LessonService;

        public LessonsController(ILessonService lessonService)
        {
            LessonService = lessonService;
        }

        [HttpGet]
        public ActionResult<IList<LessonDTO>> GetAllLessonsByTeacher()
        {
            string userId = User?.Identity?.Name;
            if (string.IsNullOrEmpty(userId))
                return Forbid();

            IList<Lesson> lessons = LessonService.GetAllLessonsByTeacher(int.Parse(userId));
            IList<LessonDTO> dtos = new List<LessonDTO>();
            foreach (var entity in lessons)
            {
                dtos.Add(new LessonDTO(entity));
            }

            return Ok(dtos);
        }

        [HttpPost]
        public ActionResult<LessonDTO> BookNewLesson(Lesson lesson)
        {
            string userId = User?.Identity?.Name;
            if (string.IsNullOrEmpty(userId))
                return Forbid();

            if (lesson.Duration == null || lesson.StudentId == null || lesson.LessonDate == null)
                return BadRequest("One or more required fields were not supplied.");

            Lesson bookedLesson = LessonService.BookNewLesson(lesson, int.Parse(userId));
            LessonDTO dto = new LessonDTO(bookedLesson);

            return Ok(dto);
        }

        [HttpDelete]
        [Route("{lessonId}")]
        public ActionResult CancelLesson([FromRoute] int lessonId)
        {
            string userId = User?.Identity?.Name;
            if (userId == null) return BadRequest("An error occurred. The lesson could not be deleted.");

            try
            {
                LessonService.CancelLesson(lessonId, int.Parse(userId));
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return Forbid();
            }
        }
    }
}