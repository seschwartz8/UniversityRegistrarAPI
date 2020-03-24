using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace UniversityRegistrar.Models
{
  public class CourseCourseStudent
  {
    public string CourseName { get; set; }
    public int Number { get; set; }
    public string StudentName { get; set; }
    public int StudentId { get; set; }
    public bool IsComplete { get; set; }
  }
  public class DepartmentStudent
  {
    public string CourseName { get; set; }
    public int Number { get; set; }
    public string StudentName { get; set; }
  }

  // public static List<DepartmentStudent> GetAll()
  // {
  //   List<DepartmentStudent> departmentStudents = new List<DepartmentStudent> { };
  //   MySqlConnection conn = DB.Connection();
  //   conn.Open();
  //   MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
  //   cmd.CommandText = @"SELECT Students.Name, Courses.Name, Courses.Number, CourseStudent.IsComplete FROM Students, Courses, CourseStudent, Departments WHERE Courses.DepartmentId Courses.CourseId = CourseStudent.CourseId and Students.StudentId = CourseStudent.StudentId;";
  //   MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
  //   while (rdr.Read())
  //   {
  //     string studentName = rdr.GetString(0);
  //     string courseName = rdr.GetString(1);
  //     string
  //     Item newItem = new Item(itemDescription, itemId);
  //     allItems.Add(newItem);
  //   }
  //   conn.Close();
  //   if (conn != null)
  //   {
  //     conn.Dispose();
  //   }
  //   return allItems;
  // }
}