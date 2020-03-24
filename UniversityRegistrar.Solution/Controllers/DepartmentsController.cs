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
  public class DepartmentsController : Controller
  {
    private readonly UniversityRegistrarContext _db;
    // private readonly UserManager<ApplicationUser> _userManager;

    public DepartmentsController(UniversityRegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Departments.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    public ActionResult Details(int id)
    {
      Department thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);

      List<Course> courses = _db.Courses.Where(course => course.DepartmentId == id).OrderBy(course => course.Name).ToList();

      thisDepartment.Courses = courses;
      return View(thisDepartment);
    }

    [HttpPost]
    public ActionResult Create(Department department)
    {
      _db.Departments.Add(department);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult GetStudents(int id)
    {
      Department thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);

      List<Course> departmentCourses = _db.Courses.Where(course => course.DepartmentId == id).ToList();
      thisDepartment.Courses = departmentCourses;

      IEnumerable<CourseCourseStudent> list = (IEnumerable<CourseCourseStudent>) from departmentCourse in departmentCourses
      join cs in _db.CourseStudent on departmentCourse.CourseId equals cs.CourseId
      join s in _db.Students on cs.StudentId equals s.StudentId
      select new CourseCourseStudent { CourseName = departmentCourse.Name, Number = departmentCourse.Number, IsComplete = cs.IsComplete, StudentName = s.Name };
      return View(list);
    }
  }
}