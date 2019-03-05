using DAL;
using DAL.Entities;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeLogic _iemployeelogic;

        public EmployeeController(IEmployeeLogic iemployeelogic)
        {
            _iemployeelogic = iemployeelogic;
        }
        
        public ActionResult Index()
        {
            var emp = _iemployeelogic.GetAllEmloyees();
            return View(emp);


        }

        public ActionResult Details(int id)
        {
            var employee = _iemployeelogic.GetEmployeeByID(id);
            return View(employee);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var demp = _iemployeelogic.GetEmployeeByID(id);
            if (demp == null)
            {
                return HttpNotFound();
            }
            return View(demp);

        }

        [HttpPost, ActionName("Delete")]

        public ActionResult Delete_Post(int id)
        {
            var demp = _iemployeelogic.DeleteEmployeeById(id);
            if (demp == null)
            {
                return HttpNotFound();
            }
            ViewBag.Message = "Your record " + demp.Ename + " has been deleted";
            return View("Delete_Confirmed");
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.DeptName = new SelectList(_iemployeelogic.GetAllDepartment(), "DeptID", "DeptName");
            return View();
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        [HandleError]
        public ActionResult Create_Post(Employee employee)
        {

            if (ModelState.IsValid)
            {
                employee.DeptID = Convert.ToInt32(Request.Form["DeptName"]);
                _iemployeelogic.CreateEmployee(employee);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.DeptName = new SelectList(_iemployeelogic.GetAllDepartment(), "DeptID", "DeptName");
            var employee = _iemployeelogic.GetEmployeeByID(id);
            return View(employee);
        }

       [HandleError]
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            var emp = new EmployeeDTO();
            if (ModelState.IsValid)
            {
                employee.DeptID = Convert.ToInt32(Request.Form["DeptName"]);
                emp = _iemployeelogic.UpdateEmployee(employee);
                if(!emp.validation.isValid)
                {
                    ViewBag.Message = emp.validation.message;
                    return View("Error");
                }
                else
                {
                    ViewBag.Message = emp.validation.message;
                    return RedirectToAction("index");
                }

            }
           

            return RedirectToAction("index");
        }

    }
}

    