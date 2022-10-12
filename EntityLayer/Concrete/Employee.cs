using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Employee
    {[Key]
        public int EmpId { get; set; }
       
        public string EmpName { get; set; }
       
        public string Surname { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "decimal(18,4)")]
         public decimal Salary { get; set; }
        public virtual Sector Sector { get; set; }
        public int SectorId { get; set; }
       
    }
}
