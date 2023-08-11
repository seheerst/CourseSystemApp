using System.ComponentModel.DataAnnotations;

namespace CourseSystemApp.Data;

public class Course
{
    [Key]
    public int CourseId { get; set; }

    public string? Title { get; set; }
    
    public string? Description { get; set; }
}