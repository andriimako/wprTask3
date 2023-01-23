using GakkoWebApp.Models;
using GakkoWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GakkoWebApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        //1. GET /students
        //       /students/index
        [HttpGet]
        public IActionResult Index(string query)
        {
            //...List of students from database
            var list = _studentService.GetStudents(query);
            
            

            return View(list);
            
            //sort by last name
            
            
        }

        //2. GET /students/create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student newStudent)
        {
            _studentService.InsertStudent(newStudent);
            return RedirectToAction("Index");
        }
    }
}
