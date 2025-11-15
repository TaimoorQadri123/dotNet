using DataBaseFirstApproach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DataBaseFirstApproach.Controllers
{
    public class EmployeeController1 : Controller
    {
        private readonly EmployeeDbContext _context;

        public EmployeeController1(EmployeeDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
           var emp = await _context.Employees.ToListAsync();
            return View(emp);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Employee emp)
        {
            await _context.Employees.AddAsync(emp);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var emp =  await _context.Employees.FirstOrDefaultAsync(x => x.EmpId == id );
            return View(emp);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee emp)
        {
              _context.Employees.Update(emp);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(x => x.EmpId == id);
            return View(emp);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Employee emp)
        {
            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
