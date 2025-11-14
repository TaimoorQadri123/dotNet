using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstApplication.Models;

namespace ModelHandling.Controllers
{
    public class HomeController : Controller
    {


        //public IActionResult StudentsInfo()
        //{
        //    var std = new List<Students>()
        //    {
        //        new Students
        //        {
                   
        //            Name = "amna",
        //            Age = 10,
        //        },
        //        new Students
        //        {
             
        //            Name = "saad",
        //            Age = 20,
        //        },
        //        new Students
        //        {
         
        //            Name = "hammad",
        //            Age = 20,
        //        },

        //    };

        //    return View(std);
        //}

        //[HttpGet]
        //public IActionResult AddStudents()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult AddStudents(Students std)
        //{
        //    if (ModelState.IsValid) { 
            
        //    ViewBag.Message = $"Students {std.Name} added successfully";
        //            }
        //    ModelState.Clear();
        //    return View();
        //}




        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }


    }
}