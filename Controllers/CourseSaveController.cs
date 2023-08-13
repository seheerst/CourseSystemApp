using CourseSystemApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CourseSystemApp.Controllers;

public class CourseSaveController : Controller
{
    private readonly DataContext _context;

    public CourseSaveController(DataContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }
    
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Students =  new SelectList(await _context.Students.ToListAsync(),"StudentId","FullName");
        ViewBag.Courses = new SelectList(await _context.Courses!.ToListAsync(), "CourseId", "Title");
        
        
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CourseSave savedCourse)
    {
        savedCourse.SaveDate = DateTime.Now;
        _context.CourseSaves.Add(savedCourse);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}