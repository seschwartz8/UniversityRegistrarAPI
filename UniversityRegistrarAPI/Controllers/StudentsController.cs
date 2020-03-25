using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityRegistrar.Models;

namespace UniversityRegistrar.Controllers
{
  [Route("[controller]")]
  public class StudentsController : Controller
  {
    private readonly UniversityRegistrarContext _context;

    public StudentsController(UniversityRegistrarContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
    {
      return await _context.Students.ToListAsync();
    }

    //Display student info and courses
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudent(int id)
    {
      var student = await _context.Students.FindAsync(id);

      if (student == null)
      {
        return NotFound();
      }

      return student;
    }

    //Update
    [HttpPut("{id}")]
    public async Task<IActionResult> PutStudent(int id, Student student)
    {
      student.StudentId = id;

      _context.Entry(student).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!StudentExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }
    //Create student
    [HttpPost]
    public async Task<ActionResult<Student>> PostStudent(Student student)
    {
      _context.Students.Add(student);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetStudent", new { id = student.StudentId }, student);
    }

    // [HttpPost]
    // public async Task<ActionResult<CourseStudent>> PostCourseStudent(CourseStudent courseStudent)
    // {
    //   _context.CourseStudent.Add(courseStudent);
    //   await
    // }

    // DELETE: api/DCandidate/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Student>> DeleteStudent(int id)
    {
      var student = await _context.Students.FindAsync(id);
      if (student == null)
      {
        return NotFound();
      }

      _context.Students.Remove(student);
      await _context.SaveChangesAsync();

      return student;
    }

    private bool StudentExists(int id)
    {
      return _context.Students.Any(e => e.StudentId == id);
    }
  }
}

//   public ActionResult Create()
//   {
//     ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "Name");
//     return View();
//   }

//   public ActionResult Details(int id)
//   {
//     Student thisStudent = _db.Students
//       .Include(student => student.Courses)
//       .ThenInclude(join => join.Course)
//       .FirstOrDefault(student => student.StudentId == id);
//     if (thisStudent.DepartmentId != null)
//     {
//       var thisDepartment = _db.Departments.FirstOrDefault(departments => departments.DepartmentId == thisStudent.DepartmentId);
//       ViewBag.DepartmentName = thisDepartment.Name;
//     }
//     return View(thisStudent);
//   }

//   public ActionResult AddCourse(int id)
//   {
//     var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
//     var courseList = _db.Courses
//       .Select(n => n)
//       .ToList();
//     ViewBag.CourseId = new SelectList(courseList, "CourseId", "Name");
//     return View(thisStudent);
//   }

//   [HttpPost]
//   public ActionResult AddCourse(Student student, int CourseId)
//   {
//     if (CourseId != 0)
//     {
//       _db.CourseStudent.Add(new CourseStudent() { StudentId = student.StudentId, CourseId = CourseId });
//     }
//     _db.SaveChanges();
//     return RedirectToAction("Index");
//   }

//   public ActionResult Delete(int id)
//   {
//     var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
//     return View(thisStudent);
//   }

//   [HttpPost, ActionName("Delete")]
//   public ActionResult DeleteConfirmed(int id)
//   {
//     var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
//     _db.Students.Remove(thisStudent);
//     _db.SaveChanges();
//     return RedirectToAction("Index");
//   }

//   [HttpPost]
//   public ActionResult RemoveCourse(int joinId)
//   {
//     var joinEntry = _db.CourseStudent.FirstOrDefault(entry => entry.CourseStudentId == joinId);
//     _db.CourseStudent.Remove(joinEntry);
//     _db.SaveChanges();
//     return RedirectToAction("Index");
//   }

//   public ActionResult EditCourse(int joinId)
//   {
//     CourseStudent thisCourseStudent = _db.CourseStudent.FirstOrDefault(courseStudent => courseStudent.CourseStudentId == joinId);

//     Course thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == thisCourseStudent.CourseId);
//     ViewBag.CourseName = thisCourse.Name;
//     SelectListItem item1 = new SelectListItem();
//     item1.Text = "True";
//     item1.Value = "true";
//     SelectListItem item2 = new SelectListItem();
//     item2.Text = "False";
//     item2.Value = "false";
//     ViewBag.IsComplete = new List<SelectListItem>() { item1, item2 };

//     return View(thisCourseStudent);
//   }

//   [HttpPost]
//   public ActionResult EditCourse(int joinId, bool IsComplete)
//   {
//     var thisCourseStudent = _db.CourseStudent.FirstOrDefault(entries => entries.CourseStudentId == joinId);

//     thisCourseStudent.IsComplete = IsComplete;
//     _db.Entry(thisCourseStudent).State = EntityState.Modified;
//     _db.SaveChanges();

//     return RedirectToAction("Index");
//   }

//   public ActionResult Edit(int id)
//   {
//     var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
//     ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "Name");
//     return View(thisStudent);
//   }

//   [HttpPost]
//   public ActionResult Edit(Student student, int DepartmentId)
//   {
//     student.DepartmentId = DepartmentId;
//     _db.Entry(student).State = EntityState.Modified;
//     _db.SaveChanges();
//     return RedirectToAction("Index");
//   }
// }

// }