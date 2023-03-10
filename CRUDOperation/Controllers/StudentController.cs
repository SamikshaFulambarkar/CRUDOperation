using CRUDOperation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CRUDOperation.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration configuration;
        StudentDAL db;
        public StudentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            db = new StudentDAL(this.configuration);
        }
        public IActionResult StudentList()
        {
            var list = db.List();
            return View(list);
        }
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Student st)
        {
            try
            {
                int result = db.AddStudent(st);
                if (result == 1)
                {
                    return RedirectToAction(nameof(StudentList));
                }
                else
                {
                    ViewBag.Message = "Something went wrong";
                }
            }
            catch (Exception ex)
            { }
            return View();
        }
        public IActionResult StudentDetails(int id)
        {
            var st = db.GetStudentById(id);
            return View(st);
        }
        public IActionResult EditStudent(int id)
        {
            var st = db.GetStudentById(id);
            return View(st);
        }
        [HttpPost]
        public IActionResult EditStudent(Student st)
        {
            try
            {
                int result = db.UpdateStudent(st);
                if (result == 1)
                {
                    return RedirectToAction(nameof(StudentList));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            { }
            return View();
        }
        public IActionResult DeleteStudent(int id)
        {
            var st = db.GetStudentById(id);
            return View(st);
        }
        [HttpPost]
        [ActionName("DeleteStudent")]
        public IActionResult Delete(int id)
        {
            try
            {
                int result = db.DeleteStudent(id);
                if (result == 1)
                {
                    return RedirectToAction(nameof(StudentList));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            { }
            return View();
        }
    }
}
