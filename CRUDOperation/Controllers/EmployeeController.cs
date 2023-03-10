using CRUDOperation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CRUDOperation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration configuration;
        EmployeeCrud db;
        public EmployeeController(IConfiguration configuration)
        {
            this.configuration = configuration;
            db = new EmployeeCrud(this.configuration);
        }
        public IActionResult EmployeeList()
        {
            var list = db.List();
            return View(list);
        }
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee emp) 
        {
            try
            {
                int result=db.AddEmployee(emp);
                if(result == 1) 
                {
                    return RedirectToAction(nameof(EmployeeList));
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
        public IActionResult EmployeeDetails(int id) 
        {
            var emp=db.GetEmployeeById(id);
            return View(emp);
        }
        public IActionResult EdtEmployee(int id)
        {
            var emp = db.GetEmployeeById(id);
            return View(emp);
        }
        [HttpPost]
        public IActionResult EditEmployee(Employee emp)
        {
            try
            {
                int result=db.UpdateEmployee(emp);
                if(result==1)
                {
                    return RedirectToAction(nameof(EmployeeList));
                }
                else
                {
                    return View();
                }
            }
            catch(Exception ex)
            { }
            return View();
        }
        public IActionResult DeleteEmployee(int id)
        {
            var emp= db.GetEmployeeById(id);
            return View(emp);
        }
        [HttpPost]
        [ActionName("DeleteEmployee")]
        public IActionResult Delete(int id)
        {
            try
            {
                int result=db.DeleteEmployee(id);
                if(result==1)
                {
                    return RedirectToAction(nameof(EmployeeList));
                }
                else
                {
                    return View();
                }
            }
            catch(Exception ex)
            { }
            return View();
        }
    }
}
