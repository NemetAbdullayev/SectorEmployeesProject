using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.SectorDTOs
{
    public class SectorToAddOrUpdateDTO
    {
        public int? SectorId { get; set; }

        public string SectorName { get; set; }
        public bool IsDeleted { get; set; }

        public int DepartmentId { get; set; }
    }
}
