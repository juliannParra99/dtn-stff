using ClassroomApp.Entities;

namespace ClassroomApp.Services
{
    public interface IStudentService
    {
        Task<Student?> GetByIdAsync(int id);
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> CreateStudentAsync(Student student);
        Task<bool> DeleteAsync(int id);

        Task<Student> UpdateStudentAsync(int id, Student student);

        // Specific ones of the domain
        //Task<Student> GetStudentWithCoursesAsync(int studentId);
        //Task<IEnumerable<Student>> GetAllStudentsWithCoursesAsync();
        //Task EnrollInCourseAsync(int studentId, int courseId);
        //Task UnenrollFromCourseAsync(int studentId, int courseId);
    }
}
