using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityRegistrar.Models;

namespace UniversityRegistrar.Controllers
{
  public class CoursesController : Controller
  {
    private readonly UniversityRegistrarContext _db;

    public CoursesController(UniversityRegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Course> userCourses = _db.Courses.OrderBy(course => course.Name).ToList();
      return View(userCourses);
    }

    public ActionResult Create()
    {
      ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Course course)
    {
      _db.Courses.Add(course);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Course thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == id);
      return View(thisCourse);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCourse = _db.Courses.FirstOrDefault(courses => courses.CourseId == id);
      _db.Courses.Remove(thisCourse);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Course thisCourse = _db.Courses
        .Include(course => course.Students)
        .ThenInclude(join => join.Student)
        .FirstOrDefault(course => course.CourseId == id);

      List<Student> students = thisCourse.Students
        .Select(student => student.Student)
        .OrderBy(student => student.Name)
        .ToList();

      ViewBag.Students = students;
      return View(thisCourse);
    }

    public ActionResult AddStudent(int id)
    {
      var thisCourse = _db.Courses.FirstOrDefault(courses => courses.CourseId == id);
      var studentList = _db.Students
        .Select(n => n)
        .ToList();
      ViewBag.StudentId = new SelectList(studentList, "StudentId", "Name");
      return View(thisCourse);
    }

    [HttpPost]
    public ActionResult AddStudent(Course course, int StudentId)
    {
      if (StudentId != 0)
      {
        _db.CourseStudent.Add(new CourseStudent() { CourseId = course.CourseId, StudentId = StudentId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}