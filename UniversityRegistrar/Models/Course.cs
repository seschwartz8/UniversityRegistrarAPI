using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
  public class Course
  {
    public Course()
    {
      this.Students = new HashSet<StudentCourse> {};
    }
    public int CourseId { get; set; }
    public string Name { get; set; }
    public int Number { get; set; }
    public ICollection<StudentCourse> Students { get; set; }
  }
}
