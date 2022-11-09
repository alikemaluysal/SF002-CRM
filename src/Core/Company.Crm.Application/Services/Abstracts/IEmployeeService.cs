using Company.Crm.Application.Dtos;

namespace Company.Crm.Application.Services.Abstracts;

public interface IEmployeeService
{
    public List<EmployeeDto> GetAll();
    public EmployeeDto? GetById(int id);
    public bool Insert(CreateOrUpdateEmployeeDto dto);
    public bool Update(CreateOrUpdateEmployeeDto dto);
    public bool Delete(EmployeeDto dto);
    public bool DeleteById(int id);
    public List<EmployeeDto> GetAllByRegionId(int regionId);
}