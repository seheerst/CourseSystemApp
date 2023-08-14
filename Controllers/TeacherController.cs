using CourseSystemApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CourseSystemApp.Controllers;

public class TeacherController:Controller
{
    private DataContext _context;
    public TeacherController(DataContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var teachers = await _context.Teachers.ToListAsync();
        return View(teachers);
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }
    
    [HttpPost]
    
    public async Task<IActionResult> Create(Teacher teacher)
    {
         _context.Teachers.Add(teacher);
         _context.SaveChangesAsync();
         return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var teacher = await _context.Teachers.FindAsync(id);

        if (teacher == null)
        {
            return NotFound();
        }

        return View(teacher);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id , Teacher teacher)
    {
        if (id != teacher.TeacherId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(teacher);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Teachers.Any(s=> s.TeacherId == teacher.TeacherId))
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

        return View(teacher);

    }


    [HttpGet]

    public async Task<IActionResult> Delete(int id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var teacher = await _context.Teachers.FindAsync(id);
        if (teacher == null)
        {
            return NotFound();
        }

        return View(teacher);
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromForm] int? id)
    {
        var teacher = await _context.Teachers.FindAsync(id);
        if (teacher == null)
        {
            return NotFound();
        }

        _context.Teachers.Remove(teacher);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}