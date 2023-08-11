using System.ComponentModel.DataAnnotations;

namespace CourseSystemApp.Data;

public class Student
{
    
    [Key]
    public int StudentId { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }
    
    public string? Email { get; set; }
    
    public string? Phone { get; set; }
}