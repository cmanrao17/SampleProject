using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
   public  interface IDepartmentLogic
    {
        List<Department> GetAllDepartment();
        Department GetDepartmentByID(int id);
        Department CreateDepartment(Department department);
        Department DeleteByID(int id);
        DepartmentDTO UpdateDepartment(Department department);
    }
}
