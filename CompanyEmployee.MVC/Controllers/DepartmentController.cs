using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.DTOs.DepartmentDTOs;
using ExamProject.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CompanyEmployee.MVC.Controllers
{
  
    public class DepartmentController : Controller
    {
        public readonly IDepartmentService _departmentService;
        public IMapper _mapper;


        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {

            _departmentService = departmentService;
            _mapper = mapper;


        }

        public async Task<IActionResult> Index()
        {
           
            List<DepartmentToListDTO> departments = await _departmentService.Get();
            return View(departments);
        }
        public async Task<IActionResult> CreateDepartment(int? id)
        {

            List<DepartmentToListDTO> departments = await _departmentService.Get();
            var data = departments.FirstOrDefault(m => m.DepartmentId == Convert.ToInt32(id));
            return View(_mapper.Map<DepartmentToAddOrUpdateDTO>(data));
        }
        public async Task<IActionResult> AddDepartment(DepartmentToAddOrUpdateDTO departmentToAddOrUpdateDTO)
        {
            DepartmentValidatior validationRules = new DepartmentValidatior();
            ValidationResult results = validationRules.Validate(departmentToAddOrUpdateDTO);
           
            if (results.IsValid)
            {
                if (departmentToAddOrUpdateDTO.DepartmentId == null)
                {
                    await _departmentService.Add(departmentToAddOrUpdateDTO);
                }
                else
                {

                    await _departmentService.Update(departmentToAddOrUpdateDTO);

                }

                return RedirectToAction("Index");
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }


            return View("CreateDepartment", departmentToAddOrUpdateDTO);
        }
            public async Task< IActionResult> Delete(int id )
        {
          
            await  _departmentService.Delete(Convert.ToInt32(id));
        
            return RedirectToAction("Index");
        }
    }
}
