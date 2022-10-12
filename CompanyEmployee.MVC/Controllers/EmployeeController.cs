using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using EntityLayer.DTOs.SectorDTOs;
using EntityLayer.DTOs.EmployeeDTOs;
using EntityLayer.DTOs.DepartmentDTOs;
using ExamProject.ValidationRules;
using FluentValidation.Results;
using AutoMapper;
using BusinessLayer.Abstract;

namespace CompanyEmployee.MVC.Controllers
{
   
    public class EmployeeController : Controller
    {
        public readonly IEmployeeService _employeeService;
        public readonly ISectorServices _sectorServices;
        public IMapper _mapper;


        public EmployeeController(IEmployeeService employeeService, ISectorServices sectorServices, IMapper mapper) 
           
        {
            _employeeService = employeeService;
            _sectorServices = sectorServices;
            _mapper = mapper;   
            

        }
        public async Task<IActionResult> Index()
        {
            var employees =await _employeeService.Get();
            List<SectorToListDTO> sectors = await _sectorServices.Get();
           


                                            
            List<SelectListItem> selectListItems = (from i in sectors 
                                                    select new SelectListItem
                                                    {

                                                        Text = i.SectorName,
                                                        Value = i.SectorId.ToString()

                                                    }


                                                ).ToList();
            ViewBag.dgr = selectListItems;
           
         
            
            return View(employees);
        }
        public async Task<IActionResult> CreateEmployee(int? id)
        {
            List<EmployeeToListDTO> employees = await _employeeService.Get();
            List<SectorToListDTO> sectors = await _sectorServices.Get();
       
            var data = employees.FirstOrDefault(m => m.EmpId == Convert.ToInt32(id));
            List<SelectListItem> selectListItems = (from i in sectors
                                                    select new SelectListItem
                                                    {

                                                        Text = i.SectorName,
                                                        Value = i.SectorId.ToString()

                                                    }


                                                  ).ToList();
            ViewBag.dgr = selectListItems;
           
            
            return View(_mapper.Map<EmployeeToAddOrUpdateDTO>(data));
        }
        public async Task< IActionResult> AddEmployee(EmployeeToAddOrUpdateDTO employeeToAddOrUpdateDTO)
        {
           EmployeeValidatior validationRules = new EmployeeValidatior();
            ValidationResult results = validationRules.Validate(employeeToAddOrUpdateDTO);

            if (results.IsValid)
            {

                if (employeeToAddOrUpdateDTO.EmpId == null)
                {
                    await _employeeService.Add(employeeToAddOrUpdateDTO);
                }
                else
                {
                    await _employeeService.Update(employeeToAddOrUpdateDTO);
                }



                return RedirectToAction("Index");
            }

            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }


            return View("CreateEmployee", employeeToAddOrUpdateDTO);
        }
        public async Task< IActionResult> Delete(int id)
        {
           
          await _employeeService.Delete(id);
          
            return RedirectToAction("Index");
        }
    }
}
