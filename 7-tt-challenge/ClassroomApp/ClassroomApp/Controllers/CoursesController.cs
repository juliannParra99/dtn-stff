using ClassroomApp.Data;
using ClassroomApp.Entities;
using ClassroomApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassroomApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ClassRoomContext _context;
        private readonly ICourseService _courseS;


        public CoursesController(ClassRoomContext context, ICourseService courseService)
        {
            _context = context;
            _courseS = courseService;
        }

        // it shows all courses with their students 
        [HttpGet]
        public async Task<ActionResult> GetCoursesWithStudents()
        {
            var coursesWithStudents = await _context.Courses
                .Include(c => c.Students)
                .Select(c => new
                {
                    CourseCode = c.Id,
                    CourseName = c.Name,
                    Students = c.Students.Select(s => new
                    {
                        StudentId = s.Id,
                        StudentName = s.Name,
                        StudentLastName = s.LastName
                    }).ToList()
                })
                .ToListAsync();

            return Ok(coursesWithStudents);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCourse( [FromBody] Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return Ok(course);
        }

        [HttpDelete("delete-course/{id}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            bool result = await _courseS.DeleteAsync(id);
            return Ok(result);
        }


        // - enroll student into course
        [HttpPost("enroll")]
        public async Task<ActionResult> EnrollStudent([FromBody] EnrollRequest request)
        {
            var student = await _context.Students.Include(s => s.Courses).FirstOrDefaultAsync(s => s.Id == request.StudentId);
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == request.CourseCode);

            if (student == null || course == null)
                return NotFound();

            if (!student.Courses.Any(c => c.Id == request.CourseCode))
            {
                student.Courses.Add(course);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }

    public class EnrollRequest
    {
        public int StudentId { get; set; }
        public int CourseCode { get; set; }
    }
}
