using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityRegistrar.Models
{
  public class Department
  {
    public Department()
    {
      this.Courses = new HashSet<Course> { };
      this.Students = new HashSet<Student> { };
    }

    [Key]
    public int DepartmentId { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string Name { get; set; }
    public virtual ICollection<Course> Courses { get; set; }
    public virtual ICollection<Student> Students { get; set; }
  }
}