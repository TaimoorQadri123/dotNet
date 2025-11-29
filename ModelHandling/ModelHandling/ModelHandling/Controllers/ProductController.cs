using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelHandling.Data;
using ModelHandling.Models;
using System.Threading.Tasks;

namespace ModelHandling.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env ;
        public  ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {

            var products = _context.Products.Include(x => x.Category).ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            ViewBag.Categories = new SelectList(_context.Category, "Id", "CatName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Products products,IFormFile file)
        {
            ViewBag.Categories = new SelectList(_context.Category, "Id", "CatName");

            string filestore = Path.Combine(_env.WebRootPath,"Uploads");
            if (!Directory.Exists(filestore))
            {
                Directory.CreateDirectory(filestore);
            }
            if(file != null && file.Length > 0)
            {
                string filename = Path.GetFileName(file.FileName);
                string filepath = Path.Combine(filestore,filename);
                using(var stream = new FileStream(filepath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);

                }
                products.ImageUrl = $@"/Uploads/{filename}";
                
            }

          

            if (ModelState.IsValid)
            {
                _context.Products.Add(products);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(products);
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
          var product = _context.Products.FirstOrDefault(x => x.Id == id);

            ViewBag.Categories = new SelectList(_context.Category, "Id", "CatName", product.CategoryId);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Products product)
        {

            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                 _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(int id) 
        { 
         var del = _context.Products.FirstOrDefault(x => x.Id == id);
            return View(del);
        }
        [HttpPost]

        public IActionResult delete(Products product) 
        {
          _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

       



    }
}
