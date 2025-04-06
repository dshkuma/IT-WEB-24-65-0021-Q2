namespace StudentInfoWebApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string Name { get; set; }

        public string LecturerName { get; set; }

        public ICollection<Student> Students { get; set; }
    }

}
