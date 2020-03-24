using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
  public class Department
  {
    public Department()
    {
      this.Courses = new HashSet<Course> { };
      this.Students = new HashSet<Student> { };
    }
    public int DepartmentId { get; set; }
    public string Name { get; set; }
    // public string DepartmentChair { get; set; }
    public virtual ICollection<Course> Courses { get; set; }
    public virtual ICollection<Student> Students { get; set; }
    public virtual ApplicationUser User { get; set; }
  }
}