using Company.Crm.Application.Dtos;

namespace Company.Crm.Application.Services.Abstracts;

public interface IEmployeeService
{
    List<EmployeeDto> GetAll();
    EmployeeDto? GetById(int id);
    bool Insert(CreateOrUpdateEmployeeDto dto);
    bool Update(CreateOrUpdateEmployeeDto dto);
    bool Delete(EmployeeDto dto);
    bool DeleteById(int id);
    List<EmployeeDto> GetAllByRegionId(int regionId);
}