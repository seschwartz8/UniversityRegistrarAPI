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

    public static void SeedCourses(this UniversityRegistrarContext context)
    {
      if (context.Courses.Any())
      {
        return; // DB has been seeded
      }

      context.Courses.AddRange(
        new Course
        {
          Name = "Intro To Biology",
            Number = 101,
            DepartmentId = 1
        },
        new Course
        {
          Name = "Molecular Biology",
            Number = 223,
            DepartmentId = 1
        },
        new Course
        {
          Name = "Quantum Physics And The Universe",
            Number = 102,
            DepartmentId = 2
        },
        new Course
        {
          Name = "Physics",
            Number = 100,
            DepartmentId = 2
        },
        new Course
        {
          Name = "Physics",
            Number = 200,
            DepartmentId = 2
        }
      );
      context.SaveChanges();
    }

    public static void SeedStudents(this UniversityRegistrarContext context)
    {
      if (context.Students.Any())
      {
        return; // DB has been seeded
      }

      context.Students.AddRange(
        new Student
        {
          Name = "Andrew",
            EnrollmentDate = "5/23/2020"
        },
        new Student
        {
          Name = "Sasa",
            EnrollmentDate = "2/23/2020"
        },
        new Student
        {
          Name = "Oliver",
            EnrollmentDate = "3/23/2020"
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
      // SeedData.SeedCourses(this);
      SeedData.SeedStudents(this);
    }

  }
}