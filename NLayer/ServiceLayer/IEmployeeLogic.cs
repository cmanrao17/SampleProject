using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IEmployeeLogic
    {
        List<Employee> GetAllEmloyees();
        Employee GetEmployeeByID(int id);
        Employee DeleteEmployeeById(int id);
        Employee CreateEmployee(Employee employee);
        EmployeeDTO UpdateEmployee(Employee employee);
        List<Department> GetAllDepartment();
    }
}
