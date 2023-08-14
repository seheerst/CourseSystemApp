using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CourseSystemApp.Data;

public class Student
{
    
    [Key]
    [DisplayName("Student Id")]
    public int StudentId { get; set; }
    [DisplayName("Student Name")]
    public string? Name { get; set; }
    [DisplayName("Student Last Name")]
    public string? LastName { get; set; }

    [DisplayName("Student Name")]
    public string FullName
    {
        get
        {
            return this.Name + " "+this.LastName;
        }
    }

    [DisplayName("Student Email")]
    public string? Email { get; set; }
    [DisplayName("Student Phone")]
    public string? Phone { get; set; }

    public ICollection<CourseSave> CourseRegistration  { get; set; } = new List<CourseSave>();
    
    
}