using System.ComponentModel.DataAnnotations;

namespace ClassroomApp.Model
{
    public class Course
    {
        [Key]
        public int Code{ get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new();
    }
}
