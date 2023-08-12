using CourseSystemApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseSystemApp.Controllers;

public class CourseController:Controller
{
   private readonly DataContext _context;
   
   public CourseController(DataContext context)
   {
      _context = context;
   }
 
   
   public async Task<IActionResult> Index()
   {
      var courses = await _context.Courses.ToListAsync();
      return View(courses);
   } 
   
   public IActionResult Create()
   {
      return View();
   }

   [HttpPost]
   public async Task<IActionResult> Create(Course course)
   {
      _context.Courses.Add(course);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index");
   }
   
}