using System.ComponentModel.DataAnnotations;

namespace ClassroomApp.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Course> Courses { get; set; } = new();
    }
}
