using ClassroomApp.Data;
using ClassroomApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace ClassroomApp.Services
{
    public class StudentService : IStudentService
    {
        private readonly ClassRoomContext _context; 

        public StudentService(ClassRoomContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>>GetAllAsync()
        {
            var allStudents = await _context.Students.ToListAsync();
            return allStudents;
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            var result = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            return result;
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudentAsync(int id, Student student)
        {
            var currentStudent = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);

            if(currentStudent != null)
            {
                currentStudent.Name = student.Name;
                currentStudent.LastName = student.LastName;
                await _context.SaveChangesAsync();
                return student;
            }

            return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);

            if(student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }
    }
}
