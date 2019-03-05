using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class DepartmentDTO
    {
        public Department department { get; set; }
        public Validation validation { get;set; }

    }
}
