using ClassroomApp.Data;
using ClassroomApp.Entities;
using ClassroomApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClassroomApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _student;

        public StudentsController(IStudentService student)
        {
            _student = student;
        }

        // it shows students with their courses
        [HttpGet]
        public async Task<ActionResult> GetStudentsWithCourses()
        {
            var allStudents = await _student.GetAllAsync();

            if (allStudents == null)
            {
                return NotFound();
            }

            return Ok(allStudents);
        }

        // student with their courses
        [HttpGet("getStudentById/{id}")]
        public async Task<ActionResult> GetStudent(int id)
        {
            var student = await _student.GetByIdAsync(id);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        // POST: api/students - Crear un nuevo estudiante
        [HttpPost("createStudent")]
        public async Task<ActionResult> CreateStudent([FromBody] Student student)
        {
            var newStudent = await _student.CreateStudentAsync(student);
            return Ok(newStudent);
        }

        [HttpDelete("deleteStudent/{id}")]
        public async Task<bool> DeleteStudent(int id)
        {
            var result = await _student.DeleteAsync(id);

            return result;
        }

        [HttpPut("UpdateStudent/{id}")]
        public async Task<ActionResult> UpdateStudent([FromBody] Student student, int id)
        {
            var studentResult = await _student.UpdateStudentAsync(id, student);

            if(studentResult != null)
            {
                return Ok(studentResult);
            }

            return NotFound();
        }
    }
}
