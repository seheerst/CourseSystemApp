using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CourseSystemApp.Data;

public class Course
{
    [Key]
    [DisplayName("Course Id")]
    public int CourseId { get; set; }

    [DisplayName("Course Name")]
    public string? Title { get; set; }
    
    [DisplayName("Course Description")]
    public string? Description { get; set; }

    public ICollection<CourseSave> CourseRegistration { get; set; }= new List<CourseSave>();
    
    public int TeacherId { get; set; }

    public Teacher Teacher { get; set; } = null!;


}