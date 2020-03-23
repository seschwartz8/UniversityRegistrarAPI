using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UniversityRegistrar.Models;

using System.Threading.Tasks;

namespace UniversityRegistrar.Controllers
{
  public class CoursesController : Controller
  {
    private readonly UniversityRegistrarContext _db;

    public CoursesController(UniversityRegistrarContext db)
    {
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userCourses = _db.Courses;
      return View(userCourses);
    }

    public ActionResult Create()
    {
      ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "Name");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Course course)
    {
      var currentUser = await _userManager.FindByIdAsync(userId);
      course.User = currentUser;
      _db.Courses.Add(course);
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
      if (StudentId != 0) {
        _db.StudentCourse.Add(new StudentCourse() { CourseId = course.CourseId, StudentId = StudentId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
