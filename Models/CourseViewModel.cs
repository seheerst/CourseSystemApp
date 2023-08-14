using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CourseSystemApp.Data;

namespace CourseSystemApp.Models;

public class CourseViewModel
{
    [Key]
    [DisplayName("Course Id")]
    public int CourseId { get; set; }

    [DisplayName("Course Name")]
    [Required]
    public string Title { get; set; }
    
    [DisplayName("Course Description")]
    [Required]
    public string Description { get; set; }

    public ICollection<CourseSave> CourseRegistration { get; set; }= new List<CourseSave>();
    
    public int TeacherId { get; set; }
    


}