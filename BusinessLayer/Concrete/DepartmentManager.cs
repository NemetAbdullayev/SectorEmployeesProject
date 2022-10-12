using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using EntityLayer.DTOs.DepartmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DepartmentManager : IDepartmentService
    {


        private readonly IGenericRepository<Department> _departmentRepository;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _databaseContext;
        public DepartmentManager(IGenericRepository<Department> departmentRepository, IMapper mapper, DatabaseContext databaseContext)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _databaseContext = databaseContext;
        }
        public async Task<DepartmentToListDTO> Add(DepartmentToAddOrUpdateDTO departmentToAddOrUpdateDTO)
        {
            Department department =await _departmentRepository.Add(_mapper.Map<Department>(departmentToAddOrUpdateDTO));
            return _mapper.Map<DepartmentToListDTO>(department);
        }

        public async Task Delete(int id)
        {
          await  _departmentRepository.Delete(id);
        }

        public async Task<DepartmentToListDTO> Get(int id)
        {
            Department department =await _departmentRepository.Get(id);
            return _mapper.Map<DepartmentToListDTO>(department);
        }

        public async Task<List<DepartmentToListDTO>> Get()
        {
            List<Department> departments =await _departmentRepository.Get();
            return _mapper.Map<List<DepartmentToListDTO>>(departments);
        }

        public async Task<DepartmentToListDTO> Update(DepartmentToAddOrUpdateDTO departmentToAddOrUpdateDTO)
        {
            Department department =await _departmentRepository.Update(_mapper.Map<Department>(departmentToAddOrUpdateDTO));
            return _mapper.Map<DepartmentToListDTO>(department);
        }
    }
}
