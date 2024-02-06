using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
       
        public string DepartmentName { get; set; }
        public string DepartmentType { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<Sector> Sectors { get; set; }
    }
}
