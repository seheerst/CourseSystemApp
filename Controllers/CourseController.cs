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
 
   [HttpGet]
   public async Task<IActionResult> Index()
   {
      var courses = await _context.Courses!.ToListAsync();
      return View(courses);
   } 
   [HttpGet]
   public IActionResult Create()
   {
      return View();
   }

   [HttpPost]
   public async Task<IActionResult> Create(Course course)
   {
      _context.Courses!.Add(course);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index");
   }

   [HttpGet]

   public async Task<IActionResult> Edit(int id)
   {
      if (id == null)
      {
         return NotFound();
      }

      var course = await _context.Courses.FindAsync(id);

      if (course == null)
      {
         return NotFound();
      }

      return View(course);
   }

   [HttpPost]

   public async Task<IActionResult> Edit(int id, Course course)
   {
      if (id != course.CourseId)
      {
         return NotFound();
      }

      if (ModelState.IsValid)
      {
         try
         {
            _context.Update(course);
            await _context.SaveChangesAsync();
         }
         catch (DbUpdateConcurrencyException)
         {
            if (!_context.Courses.Any(s=> s.CourseId == course.CourseId))
            {
               return NotFound();
            }
            else
            {
               throw;
            }
         }

         return RedirectToAction("Index");
      }

      return View(course);
   }
   
    
   [HttpGet]
   public async Task<IActionResult> Delete(int id)
   {
      if (id==null)
      {
         return NotFound();
      }

      var course = await _context.Courses.FindAsync(id);
      if (course == null)
      {
         return NotFound();
      }

      return View(course);
   }

   [HttpPost]

   public async Task<IActionResult> Delete([FromForm]int? id)
   {
        
      var course = await _context.Courses.FindAsync(id);
      if (course==null)
      {
         return NotFound();
      }
      _context.Courses.Remove(course);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index");
   }
   
}