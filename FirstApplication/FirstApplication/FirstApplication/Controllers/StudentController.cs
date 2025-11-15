using FirstApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using FirstApplication.Data;


namespace FirstApplication.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var std = _context.Students.ToList();
            //var students = _context.Students.ToList();
            return View(std);
            
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Students std)
        {
            if (ModelState.IsValid)
            {
                await _context.Students.AddAsync(std);
                await _context.SaveChangesAsync();
                ViewBag.Message = $"Student {std.Name} added successfully";
            }
            return View(std);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id )
        {
            var std = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            return View(std);
            
        }
        [HttpPost]
        public async Task<IActionResult> Update(Students std)
        {
            if (ModelState.IsValid) 
            { 
              _context.Students.Update(std);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var del = await _context.Students.FindAsync(id);
            _context.Students.Remove(del);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
