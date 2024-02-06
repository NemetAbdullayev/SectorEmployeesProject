using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using EntityLayer.DTOs.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class EmployeeManager : IEmployeeService
    {


        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeManager(IGenericRepository<Employee> employeeRepository, IMapper mapper, DatabaseContext databaseContext)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeToListDTO> Add(EmployeeToAddOrUpdateDTO employeeToAddOrUpdateDTO)
        {
            Employee employee =await _employeeRepository.Add(_mapper.Map<Employee>(employeeToAddOrUpdateDTO));
            return _mapper.Map<EmployeeToListDTO>(employee);
        }

        public async Task<EmployeeToListDTO> Update(EmployeeToAddOrUpdateDTO employeeToAddOrUpdateDTO)
        {
            Employee employee = await _employeeRepository.Update(_mapper.Map<Employee>(employeeToAddOrUpdateDTO));
            return _mapper.Map<EmployeeToListDTO>(employee);
          
        }

        public async Task<List<EmployeeToListDTO>> Get()
        {
            List<Employee> employees =await _employeeRepository.Get();
            return _mapper.Map<List<EmployeeToListDTO>>(employees);
        }

        public async Task<EmployeeToListDTO> Get(int id)
        {
            Employee employee =await _employeeRepository.Get(id);
            return _mapper.Map<EmployeeToListDTO>(employee);
        }

        public async Task Delete(int id)
        {
           await _employeeRepository.Delete(id);
        }
    }
}


