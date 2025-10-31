using ClassroomApp.Entities;

namespace ClassroomApp.Services
{
    public interface ICourseService
    {
        Task<Course?> GetByIdAsync(int id);
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course> CreateCourseAsync(Course course);
        Task<bool> DeleteAsync(int id);

        Task<Course> UpdateCourseAsync(int id, Course course );
    }
}
