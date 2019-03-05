using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class DepartmentLogic:IDepartmentLogic
    {
        EmployeeDbContext context = new EmployeeDbContext();

        public Department CreateDepartment(Department department)
        {
            var adddep = context.Department.Add(department);
            context.SaveChanges();
            if(adddep!=null)
            {

            }
            return adddep;
        }

        public Department DeleteByID(int id)
        {
            var depdel = context.Department.Find(id);
            if(depdel==null)
            {
                return depdel;
            }
            context.Department.Remove(depdel);
            context.SaveChanges();
            return depdel;

        }

        public List<Department> GetAllDepartment()
        {
            var deptList = context.Department.ToList();
            return deptList;
        }

        public Department GetDepartmentByID(int id)
        {
            var dept = context.Department.Where(x => x.DeptID == id).SingleOrDefault();
            return dept;

        }

        public DepartmentDTO UpdateDepartment(Department department)
        {
            var dept = new DepartmentDTO();
            try
            {
                Department departmentToUpdate = context.Department.SingleOrDefault(x => x.DeptID == department.DeptID);
            departmentToUpdate.DeptID = department.DeptID;
            departmentToUpdate.DeptName = department.DeptName;
            context.SaveChanges();
               dept.department = department;
                dept.validation = new Validation()
                {
                    isValid = true,
                    message = "Success"
                };
                return dept;
            }
            catch (Exception ex)
            {
                dept.department = department;
                dept.validation = new Validation()
                {
                    isValid = false,
                    message = ex.Message
                };
                return dept;
            }
            
        }
    }
}
