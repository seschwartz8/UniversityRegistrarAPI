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
  public class CoursesController : Controller
  {
    private readonly UniversityRegistrarContext _context;

    public CoursesController(UniversityRegistrarContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
    {
      return await _context.Courses.OrderBy(course => course.Name).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Course>> GetCourse(int id)
    {
      var course = await _context.Courses.FindAsync(id);

      if (course == null)
      {
        return NotFound();
      }

      // List<Student> students = thisCourse.Students
      //   .Select(student => student.Student)
      //   .OrderBy(student => student.Name)
      //   .ToList();

      // ViewBag.Students = students;

      return course;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCourse(int id, Course course)
    {
      course.CourseId = id;

      _context.Entry(course).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CourseExists(id))
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

    [HttpPost]
    public async Task<ActionResult<Course>> PostCourse(Course course)
    {
      _context.Courses.Add(course);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetCourse", new { id = course.CourseId }, course);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Course>> DeleteCourse(int id)
    {
      var course = await _context.Courses.FindAsync(id);
      if (course == null)
      {
        return NotFound();
      }

      _context.Courses.Remove(course);
      await _context.SaveChangesAsync();

      return course;
    }

    private bool CourseExists(int id)
    {
      return _context.Courses.Any(e => e.CourseId == id);
    }
  }
}