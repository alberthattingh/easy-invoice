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
    public class StudentsController : Controller
    {
        private readonly IStudentService StudentService;

        public StudentsController(IStudentService studentService)
        {
            StudentService = studentService;
        }

        [HttpGet]
        public ActionResult<IList<StudentDTO>> GetAllStudentsForTeacher()
        {
            string userId = User?.Identity?.Name;
            if (string.IsNullOrEmpty(userId))
                return Forbid();

            IList<Student> students = StudentService.GetAllStudentsByTeacher(int.Parse(userId));
            IList<StudentDTO> dtos = new List<StudentDTO>();
            foreach (var entity in students)
            {
                dtos.Add(new StudentDTO(entity));
            }

            return Ok(dtos);
        }

        [HttpPost]
        public ActionResult<StudentDTO> AddNewStudentToClassList([FromBody] Student student)
        {
            string userId = User?.Identity?.Name;
            if (string.IsNullOrEmpty(userId))
                return Forbid();
            
            bool invalidRequest = string.IsNullOrEmpty(student.FirstName) ||
                                  string.IsNullOrEmpty(student.LastName) || 
                                  student.FeePayable == null;
            
            if (invalidRequest)
                return BadRequest("One or more required fields were not supplied.");

            Student createdStudent = StudentService.AddStudentToClassList(student, int.Parse(userId));
            StudentDTO dto = new StudentDTO(createdStudent);

            return Ok(dto);
        }

        [HttpDelete("{studentId}")]
        public ActionResult DeleteStudent(int studentId)
        {
            string userId = User?.Identity?.Name;
            if (string.IsNullOrEmpty(userId))
                return Forbid();
            
            var deleted = StudentService.DeleteStudent(studentId, int.Parse(userId));
            return deleted ? Ok() : NotFound();
        }
    }
}