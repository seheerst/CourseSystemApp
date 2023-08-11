using CourseSystemApp.Data;
using Microsoft.EntityFrameworkCore;

namespace CourseSystemApp.Services;

public class DataContext : DbContext
{
    public DbSet<Course>? Courses { get; set; }

    public DbSet<Student> Students => Set<Student>();
    
    public DbSet<CourseSave> CourseSaves => Set<CourseSave>();
}