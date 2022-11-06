using AutoMapper;
using Company.Crm.Application.Dtos;
using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;

namespace Company.Crm.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public List<EmployeeDto> GetAll()
        {
            var entityList = _employeeRepository.GetAll();
            var dtoList = _mapper.Map<List<EmployeeDto>>(entityList);
            return dtoList;
        }

        public EmployeeDto? GetById(int id)
        {
            var entity = _employeeRepository.GetById(id);
            var dto = _mapper.Map<EmployeeDto>(entity);
            return dto;
        }

        public bool Insert(CreateOrUpdateEmployeeDto dto)
        {
            var entity = _mapper.Map<Employee>(dto);
            return _employeeRepository.Insert(entity);
        }

        public bool Update(CreateOrUpdateEmployeeDto dto)
        {
            var entity = _mapper.Map<Employee>(dto);
            return _employeeRepository.Update(entity);
        }

        public bool Delete(EmployeeDto dto)
        {
            var entity = _mapper.Map<Employee>(dto);
            return _employeeRepository.Delete(entity);
        }

        public bool DeleteById(int id)
        {
            return _employeeRepository.DeleteById(id);
        }

        public List<EmployeeDto> GetAllByRegionId(int regionId)
        {
            var entityList = _employeeRepository.GetAllByRegionId(regionId);
            var dtoList = _mapper.Map<List<EmployeeDto>>(entityList);
            return dtoList;
        }
    }
}