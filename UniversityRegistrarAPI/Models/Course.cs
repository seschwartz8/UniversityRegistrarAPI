using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityRegistrar.Models
{
  public class Course
  {
    public Course()
    {
      this.Students = new HashSet<CourseStudent> { };
    }

    [Key]
    public int CourseId { get; set; }

    [ForeignKey("DepartmentId")]
    public int DepartmentId { get; set; }
    public virtual Department Department { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string Name { get; set; }

    public int Number { get; set; }
    public ICollection<CourseStudent> Students { get; set; }
    // public virtual ApplicationUser User { get; set; }
  }
}