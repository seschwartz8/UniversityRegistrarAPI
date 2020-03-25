using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UniversityRegistrar.Models
{
  public static class SeedData
  {
    public static void SeedDepartments(this UniversityRegistrarContext context)
    {
      if (context.Departments.Any())
      {
        return; // DB has been seeded
      }

      context.Departments.AddRange(
        new Department
        {
          Name = "Biology"
        },
        new Department
        {
          Name = "Physics"
        },
        new Department
        {
          Name = "English"
        }
      );
      context.SaveChanges();
    }
  }
  public class UniversityRegistrarContext : DbContext
  {
    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<CourseStudent> CourseStudent { get; set; }
    public DbSet<Department> Departments { get; set; }

    public UniversityRegistrarContext(DbContextOptions options) : base(options)
    {
      SeedData.SeedDepartments(this);
    }

  }
}