using ClassroomApp.Data;
using ClassroomApp.Entities;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace ClassroomApp.Services
{
    public class CourseService : ICourseService
    {
        private readonly ClassRoomContext _context;

        public CourseService(ClassRoomContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            var courses = await _context.Courses.ToListAsync();
            return courses;
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);

            return course;
        }

        public async Task<Course> CreateCourseAsync(Course course)
        {
            _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return course;

        }
        public async Task<Course> UpdateCourseAsync(int id, Course course)
        {
            var currentCourse = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (currentCourse != null)
            {
                currentCourse.Name = course.Name;
                await _context.SaveChangesAsync();
                return currentCourse;
            }

            return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if( course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
