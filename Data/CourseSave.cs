using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CourseSystemApp.Data;

public class CourseSave
{
    [Key]
    [DisplayName("Student Id")]
    public int SaveId { get; set; }

    [DisplayName("Student Id")]
    public int StudentId { get; set; }
    
    public Student Student { get; set; } = null!;
    [DisplayName("Course Id")]
    public int CourseId { get; set; }

    public Course Course { get; set; } = null!;
    [DisplayName("Registration day")]
    public DateTime SaveDate { get; set; }
}