using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs.DepartmentDTOs;
using EntityLayer.DTOs.EmployeeDTOs;
using EntityLayer.DTOs.SectorDTOs;
using ExamProject.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployee.MVC.Controllers
{
  
    public class SectorController : Controller
    {

       
        public readonly ISectorServices _sectorServices;
        public readonly IDepartmentService _departmentService;
        public IMapper _mapper;


        public SectorController( ISectorServices sectorServices, IMapper mapper,
            IDepartmentService departmentService)
        {
          
            _sectorServices = sectorServices;
            _departmentService = departmentService;
            _mapper = mapper;


        }
        public async Task<IActionResult> Index()
        {

            List<SectorToListDTO> sectors = await _sectorServices.Get();
          
          
            List<DepartmentToListDTO> departments = await _departmentService.Get();
            List<SelectListItem> selectListItems1 = (from i in departments
                                                     select new SelectListItem
                                                     {

                                                         Text = i.DepartmentName,
                                                         Value = i.DepartmentId.ToString()

                                                     }


                                     ).ToList();
//            foreach (var sector in sectors)
//            {
//if(sector.Department.IsDeleted==true)
//                {
//                    sector.IsDeleted = true;
//                }
//            }
            ViewBag.dgr1 = selectListItems1;


            return View(sectors);
        }
        public async Task<IActionResult> CreateSector(int? id)
        {
            List<SectorToListDTO> sectors = await _sectorServices.Get();

            var sector = sectors.FirstOrDefault(m => m.SectorId == Convert.ToInt32(id));
            List<DepartmentToListDTO> departments = await _departmentService.Get();
            List<SelectListItem> selectListItems1 = (from i in departments
                                                     select new SelectListItem
                                                     {

                                                         Text = i.DepartmentName,
                                                         Value = i.DepartmentId.ToString()

                                                     }


                                                ).ToList();
            ViewBag.dgr1 = selectListItems1;




            return View(_mapper.Map<SectorToAddOrUpdateDTO> ( sector));
        }

        public async Task<IActionResult> AddSector(SectorToAddOrUpdateDTO sectorToAddOrUpdateDTO)
        {


            SectorValidatior validationRules = new SectorValidatior();
            ValidationResult results = validationRules.Validate(sectorToAddOrUpdateDTO);

            if (results.IsValid)
            {
            

                if (sectorToAddOrUpdateDTO.SectorId == null)
                {


                    await _sectorServices.Add(sectorToAddOrUpdateDTO);
                }

                else
                {
                    await _sectorServices.Update(sectorToAddOrUpdateDTO);
                }

                return RedirectToAction("Index");
            }
            else { 

            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, "vfshfgdfg");
            }


            return View("CreateSector", sectorToAddOrUpdateDTO);
            }
          
        }
            public async Task<IActionResult> Delete(int id)
        {
            await _sectorServices.Delete(Convert.ToInt32(id));
            return RedirectToAction("Index");
        }

       
    }
}
