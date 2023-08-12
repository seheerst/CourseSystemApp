using System.Linq;
using System.Threading.Tasks;
using CourseSystemApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseSystemApp.Controllers;

public class StudentController : Controller

{
    private readonly DataContext _context;

    public StudentController(DataContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()

    {
        var students = await _context.Students.ToListAsync();
        return View(students);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Student student)
    {
        _context.Students.Add(student);
       await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    
    
}