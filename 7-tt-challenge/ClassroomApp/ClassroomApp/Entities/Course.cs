using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClassroomApp.Entities
{
    public class Course
    {
        [Key]
        public int Id{ get; set; }
        public string Name { get; set; }
        [JsonIgnore] //ideally i should use a DTO.
        public List<Student> Students { get; set; } = new();
    }
}
