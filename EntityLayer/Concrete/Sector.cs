using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Sector
    {
        [Key]
        public int SectorId { get; set; }
    
        public string SectorName { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<Employee>Employees { get; set; }
        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
