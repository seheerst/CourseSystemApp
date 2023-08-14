using CourseSystemApp.Data;
using CourseSystemApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CourseSystemApp.Controllers;

public class CourseController : Controller
{
    private readonly DataContext _context;

    public CourseController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var courses = await _context.Courses!.Include(c=> c.Teacher).ToListAsync();
        return View(courses);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Teachers = new SelectList( await _context.Teachers.ToListAsync(), "TeacherId", "FullName" );
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create( CourseViewModel course)
    {
        if(ModelState.IsValid){ 
            _context.Courses!.Add(new Course()
            {
                CourseId = course.CourseId,
                Title = course.Title,
                Description = course.Description,
                TeacherId = course.TeacherId
            });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        ViewBag.Teachers = new SelectList( await _context.Teachers.ToListAsync(), "TeacherId", "FullName" );
        return View(course);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        ViewBag.Teachers = new SelectList( await _context.Teachers.ToListAsync(), "TeacherId", "FullName" );

        if (id == null)
        {
            return NotFound();
        }

        var course = await _context
            .Courses!.Include(x => x.CourseRegistration)
            .ThenInclude(x => x.Student)
            .Select(k=> new CourseViewModel
            {
                CourseId = k.CourseId,
                Title = k.Title,
                Description = k.Description,
                TeacherId = k.TeacherId,
                CourseRegistration = k.CourseRegistration
            })
            .FirstOrDefaultAsync(x => x.CourseId == id);

        if (course == null)
        {
            return NotFound();
        }

        return View(course);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id , CourseViewModel course)
    {
        if (id != course.CourseId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(new Course()
                {
                    CourseId = course.CourseId,
                    Title = course.Title,
                    Description = course.Description,
                    TeacherId = course.TeacherId
                });
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
    public async Task<IActionResult> Delete([FromForm] int? id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null)
        {
            return NotFound();
        }

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}