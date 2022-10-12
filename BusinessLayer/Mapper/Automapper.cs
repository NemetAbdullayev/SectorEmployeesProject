using AutoMapper;
using EntityLayer.Concrete;
using EntityLayer.DTOs.DepartmentDTOs;
using EntityLayer.DTOs.EmployeeDTOs;
using EntityLayer.DTOs.SectorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapper
{
    public class Automapper : Profile
    {
        public Automapper()
        {


            CreateMap<EmployeeToAddOrUpdateDTO, Employee>();
            CreateMap<EmployeeToListDTO, EmployeeToAddOrUpdateDTO>();
            CreateMap<Employee, EmployeeToListDTO>();
            CreateMap<SectorToAddOrUpdateDTO, Sector>();
            CreateMap<SectorToListDTO, SectorToAddOrUpdateDTO>();
            CreateMap<Sector, SectorToListDTO>();
            CreateMap<DepartmentToAddOrUpdateDTO, Department>();
            CreateMap<DepartmentToListDTO, DepartmentToAddOrUpdateDTO>();
            CreateMap<Department, DepartmentToListDTO>();
       




        }

    }
}