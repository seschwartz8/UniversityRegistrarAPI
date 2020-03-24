using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
  public class Course
  {
    public Course()
    {
      this.Students = new HashSet<CourseStudent> { };
    }
    public int CourseId { get; set; }
    public int DepartmentId { get; set; }
    public virtual Department Department { get; set; }
    public string Name { get; set; }
    public int Number { get; set; }
    public ICollection<CourseStudent> Students { get; set; }
  }
}