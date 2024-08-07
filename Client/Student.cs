using System.ComponentModel.DataAnnotations;

namespace Client
{
    public class Student
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Age { get; set; }
        public string? Mobile { get; set; }
    }
}
