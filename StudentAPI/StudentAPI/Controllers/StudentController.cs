using Microsoft.AspNetCore.Mvc;
using StudentAPI.Domain;
using StudentAPI.Services;
using System;
using System.Collections.Generic;

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpGet]
        public List<Student> Get()
        {
            return _studentService.GetAll();
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            try
            {
                var studentSaved =_studentService.Add(student);
                return new JsonResult(studentSaved);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
    }
}
