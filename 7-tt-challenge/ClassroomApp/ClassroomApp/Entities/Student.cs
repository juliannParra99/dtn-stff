using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClassroomApp.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        [JsonIgnore] //this avoid cycle references
        public List<Course> Courses { get; set; } = new();
    }
}
