using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace ServiceLayer
{
    public class EmployeeLogic : IEmployeeLogic
    {
        EmployeeDbContext employeecontext = new EmployeeDbContext();
        public List<Employee> GetAllEmloyees()
        {
         
            var empList = employeecontext.Employee.ToList();
            return empList;
        }

        public Employee GetEmployeeByID(int id)
        {
            var employee = employeecontext.Employee.Where(x => x.EID==id).SingleOrDefault();
            return employee;
        }

        public Employee DeleteEmployeeById(int id)
        {
            var demployee = employeecontext.Employee.Find(id );
            if(demployee==null)
            {
                return demployee;
            }
            demployee = employeecontext.Employee.Remove(demployee);
            employeecontext.SaveChanges();
            return demployee;
        }

        public Employee CreateEmployee(Employee employee)
        {
          
            var addemployee = employeecontext.Employee.Add(employee) ;
            employeecontext.SaveChanges();
            if(addemployee!=null)
            {
            }
            return addemployee;
        }
        public EmployeeDTO UpdateEmployee(Employee employee)
        {
            var emp = new EmployeeDTO();
            try { 
                Employee employeeToUpdate = employeecontext.Employee.SingleOrDefault(x => x.EID == employee.EID);
                employeeToUpdate.Ename = employee.Ename;
                employeeToUpdate.Salary = employee.Salary;
                employeeToUpdate.DeptID = employee.DeptID;
                employeecontext.SaveChanges();
                emp.employee = employee;
                emp.validation = new Validation()
                {
                    isValid = true,
                    message = "Success"
                };
                return emp;
            }
            catch(Exception ex)
            {
                emp.employee = employee;
                emp.validation = new Validation()
                {
                    isValid = false,
                    message = ex.Message
                };
                return emp;
            }
        }
        public List<Department> GetAllDepartment()
        {
            var deptList = employeecontext.Department.ToList();
            return deptList;
        }
    }
}
