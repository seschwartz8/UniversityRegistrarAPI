namespace UniversityRegistrar.Models
{
  public class CourseStudent
  {
    public int CourseStudentId { get; set; }

    public int CourseId { get; set; }
    public int StudentId { get; set; }
    public bool IsComplete { get; set; }
    public Student Student { get; set; }
    public Course Course { get; set; }
  }
}