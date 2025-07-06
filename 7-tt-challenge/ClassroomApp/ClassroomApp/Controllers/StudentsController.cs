using ClassroomApp.Data;
using ClassroomApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClassroomApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ClassRoomContext _context;

        public StudentsController(ClassRoomContext context)
        {
            _context = context;
        }

        // it shows students with their courses
        [HttpGet]
        public async Task<ActionResult> GetStudentsWithCourses()
        {
            var studentsWithCourses = await _context.Students
                .Include(s => s.Courses)
                .Select(s => new
                {
                    StudentId = s.Id,
                    StudentName = s.Name,
                    StudentLastName = s.LastName,
                    Courses = s.Courses.Select(c => new
                    {
                        CourseCode = c.Code,
                        CourseName = c.Name
                    }).ToList()
                })
                .ToListAsync();

            return Ok(studentsWithCourses);
        }

        // student with their courses
        [HttpGet("{id}")]
        public async Task<ActionResult> GetStudent(int id)
        {
            var student = await _context.Students
                .Include(s => s.Courses)
                .Where(s => s.Id == id)
                .Select(s => new
                {
                    StudentId = s.Id,
                    StudentName = s.Name,
                    StudentLastName = s.LastName,
                    Courses = s.Courses.Select(c => new
                    {
                        CourseCode = c.Code,
                        CourseName = c.Name
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        // POST: api/students - Crear un nuevo estudiante
        [HttpPost]
        public async Task<ActionResult> CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }
    }
}
