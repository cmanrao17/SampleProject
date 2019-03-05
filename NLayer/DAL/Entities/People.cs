using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [System.ComponentModel.DataAnnotations.Schema.Table("People")]
    public class People
    {
        [Key]
        public int PersonId { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
