using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityRegistrar.Models;

namespace UniversityRegistrar.Controllers
{
  [Authorize]
  public class StudentsController : Controller
  {
    private readonly UniversityRegistrarContext _db;
    // private readonly UserManager<ApplicationUser> _userManager;

    public StudentsController(UniversityRegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Student> model = _db.Students.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Student student)
    {
      _db.Students.Add(student);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Student thisStudent = _db.Students
        .Include(student => student.Courses)
        .ThenInclude(join => join.Course)
        .FirstOrDefault(student => student.StudentId == id);
      if (thisStudent.DepartmentId != null)
      {
        var thisDepartment = _db.Departments.FirstOrDefault(departments => departments.DepartmentId == thisStudent.DepartmentId);
        ViewBag.DepartmentName = thisDepartment.Name;
      }
      return View(thisStudent);
    }

    public ActionResult AddCourse(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
      var courseList = _db.Courses
        .Select(n => n)
        .ToList();
      ViewBag.CourseId = new SelectList(courseList, "CourseId", "Name");
      return View(thisStudent);
    }

    [HttpPost]
    public ActionResult AddCourse(Student student, int CourseId)
    {
      if (CourseId != 0)
      {
        _db.CourseStudent.Add(new CourseStudent() { StudentId = student.StudentId, CourseId = CourseId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
      return View(thisStudent);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
      _db.Students.Remove(thisStudent);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult RemoveCourse(int joinId)
    {
      var joinEntry = _db.CourseStudent.FirstOrDefault(entry => entry.CourseStudentId == joinId);
      _db.CourseStudent.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult EditCourse(int joinId)
    {
      CourseStudent thisCourseStudent = _db.CourseStudent.FirstOrDefault(courseStudent => courseStudent.CourseStudentId == joinId);

      Course thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == thisCourseStudent.CourseId);
      ViewBag.CourseName = thisCourse.Name;
      SelectListItem item1 = new SelectListItem();
      item1.Text = "True";
      item1.Value = "true";
      SelectListItem item2 = new SelectListItem();
      item2.Text = "False";
      item2.Value = "false";
      ViewBag.IsComplete = new List<SelectListItem>() { item1, item2 };

      return View(thisCourseStudent);
    }

    [HttpPost]
    public ActionResult EditCourse(int joinId, bool IsComplete)
    {
      var thisCourseStudent = _db.CourseStudent.FirstOrDefault(entries => entries.CourseStudentId == joinId);

      thisCourseStudent.IsComplete = IsComplete;
      _db.Entry(thisCourseStudent).State = EntityState.Modified;
      _db.SaveChanges();

      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
      ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "Name");
      return View(thisStudent);
    }

    [HttpPost]
    public ActionResult Edit(Student student, int DepartmentId)
    {
      student.DepartmentId = DepartmentId;
      _db.Entry(student).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }

}