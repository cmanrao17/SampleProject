using DAL.Entities;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class DepartmentController : Controller
    {
  
        private readonly IDepartmentLogic _idepartmentlogic;

        public DepartmentController(IDepartmentLogic idepartmentlogic)
        {
            _idepartmentlogic = idepartmentlogic;
        }
   
        public ActionResult Index()
        {

            var dep = _idepartmentlogic.GetAllDepartment();
            return View(dep);
        }

        public ActionResult Details(int id)
        {

            var dept = _idepartmentlogic.GetDepartmentByID(id);
            return View(dept);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _idepartmentlogic.CreateDepartment(department);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var demp = _idepartmentlogic.GetDepartmentByID(id);
            if (demp == null)
            {
                return HttpNotFound();
            }
            return View(demp);
           
        }
       
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            var dep = _idepartmentlogic.DeleteByID(id);
            if (dep == null)
            {
                return HttpNotFound();
            }
          
            ViewBag.Message = "Your record " + dep.DeptName+ " has been deleted";
            return View("delete_confirm");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.DeptName = new SelectList(_idepartmentlogic.GetAllDepartment(), "DeptID", "DeptName");
            var employee = _idepartmentlogic.GetDepartmentByID(id);
            return View(employee);
        }

        [HandleError]
        [HttpPost]
        public ActionResult Edit(Department department)
        {
            var dept = new DepartmentDTO();
            if (ModelState.IsValid)
            {
                department.DeptName =(Request.Form["DeptName"]);
                dept = _idepartmentlogic.UpdateDepartment(department);
                if (!dept.validation.isValid)
                {
                    ViewBag.Message = dept.validation.message;
                    return View("~/Employee/Error");
                }
                else
                {
                    ViewBag.Message = dept.validation.message;
                    return RedirectToAction("index");
                }

            }


            return RedirectToAction("index");
        }

    }
}