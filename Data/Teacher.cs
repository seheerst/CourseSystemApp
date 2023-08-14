using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CourseSystemApp.Data;

public class Teacher
{
    

    [Key]
    [DisplayName("Teacher Id")]
    public int TeacherId { get; set; }
    [DisplayName(" Name")]
    public string? Name { get; set; }
    
    [DisplayName(" Last Name")]
    public string? LastName { get; set; }
    
    public string FullName
    {
        get
        {
            return this.Name + " "+this.LastName;
        }
    }
    
    [DisplayName("Teacher Email")]
    public string? Email { get; set; }
    [DisplayName("Teacher Phone")]
    public string? Phone { get; set; }
    
    [DisplayName("Start Date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime StartDate { get; set; }
    
    public ICollection<Course> Courses { get; set; } = new List<Course>();

}
