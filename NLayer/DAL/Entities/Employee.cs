using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Employee")]
   public  class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EID { get; set; }
        //[Required]
        public string Ename { get; set; }
        public int  Salary { get; set; }

        public int DeptID { get; set; }
        ////linking for adding foreign key
        [ForeignKey("DeptID")]
        public virtual Department Department { get; set; }
       // public ICollection<Department> Department { get; set; }
    }
}
