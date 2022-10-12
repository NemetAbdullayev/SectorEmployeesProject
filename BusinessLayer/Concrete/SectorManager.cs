using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using EntityLayer.DTOs.SectorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SectorManager : ISectorServices
    {


        private readonly IGenericRepository<Sector> _sectorRepository;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _databaseContext;
        public SectorManager(IGenericRepository<Sector> sectorRepository, IMapper mapper, DatabaseContext databaseContext)
        {
            _sectorRepository = sectorRepository;
            _mapper = mapper;
            _databaseContext = databaseContext;
        }

        public async Task<SectorToListDTO> Add(SectorToAddOrUpdateDTO sectorToAddOrUpdateDTO)
        {
            Sector sector = await _sectorRepository.Add(_mapper.Map<Sector>(sectorToAddOrUpdateDTO));
            return _mapper.Map<SectorToListDTO>(sector);
        }

        public async Task Delete(int id)
        {
            await _sectorRepository.Delete(id);
        }

        public async Task<List<SectorToListDTO>> Get()
        {
            List<Sector> sectors = await _sectorRepository.Get();
            return _mapper.Map<List<SectorToListDTO>>(sectors);
        }

        public async Task<SectorToListDTO> Get(int id)
        {
            Sector sector = await _sectorRepository.Get(id);
            return _mapper.Map<SectorToListDTO>(sector);
        }

        public async Task<SectorToListDTO> Update(SectorToAddOrUpdateDTO sectorToAddOrUpdateDTO)
        {
            Sector sector = await _sectorRepository.Update(_mapper.Map<Sector>(sectorToAddOrUpdateDTO));
            return _mapper.Map<SectorToListDTO>(sector);


        }
    }
}
