using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ModelHandling.Models;

namespace ModelHandling.Controllers
{
    public class HomeController : Controller
    {

        //public readonly Students _std;

        //public HomeController(Students std)
        //{
        //    _std = std;
        //}   

        //public IActionResult StudentInfo()
        //{
        //    var std = new List<Students>()
        //    {
        //        new Students
        //        {
        //            Name = "Test",
        //            Age = 10,
        //        },
        //        new Students
        //        {
        //            Name = "Saad",
        //            Age = 20,
        //        },
        //        new Students
        //        {
        //            Name = "Daim",
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
        //    if (ModelState.IsValid)
        //    {
        //        ViewBag.Message = $"Student {std.Name} addedd Succefully";
        //    }
        //    ModelState.Clear();
        //    return View();
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

      
    }
}
