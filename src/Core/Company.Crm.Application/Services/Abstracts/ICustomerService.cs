using Company.Crm.Application.Dtos;

namespace Company.Crm.Application.Services.Abstracts;

public interface ICustomerService
{
    public List<CustomerDto> GetAll();
    public CustomerDto? GetById(int id);
    public bool Insert(CreateOrUpdateCustomerDto dto);
    public bool Update(CreateOrUpdateCustomerDto dto);
    public bool Delete(CustomerDto dto);
    public bool DeleteById(int id);
    public List<CustomerDto> GetAllByRegionId(int regionId);
}