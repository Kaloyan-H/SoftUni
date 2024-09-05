using _02.ASP.NET_Core_Introduction.Models;
using Microsoft.AspNetCore.Mvc;

namespace _02.ASP.NET_Core_Introduction.Controllers
{
    public class IntroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetNumber(int number)
        {
            ViewBag.Title = "GetNumber";

            return View("Number", number);
        }

        public IActionResult GetStudentData()
        {
            ViewBag.Title = "GetStudentData";

            var student = new Student
            {
                Id = 1,
                Name = "John Doe",
                Email = "john@doe.com"
            };

            return View("StudentData", student);
        }

        public IActionResult EditStudent(Student model)
        {
            if (!ModelState.IsValid)
            {
                return View("StudentData", model);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
