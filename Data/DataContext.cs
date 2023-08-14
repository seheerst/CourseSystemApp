using Microsoft.EntityFrameworkCore;

namespace CourseSystemApp.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options ): base(options)
    {
        
    }
    
    public DbSet<Course>? Courses { get; set; }

    public DbSet<Student> Students => Set<Student>();
    
    public DbSet<CourseSave> CourseSaves => Set<CourseSave>();
    
    public DbSet<Teacher> Teachers => Set<Teacher>();
}