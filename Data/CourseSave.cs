using System.ComponentModel.DataAnnotations;

namespace CourseSystemApp.Data;

public class CourseSave
{
    [Key]
    public int SaveId { get; set; }

    public int StudentId { get; set; }
    
    public int CourseId { get; set; }

    public DateTime SaveDate { get; set; }
}