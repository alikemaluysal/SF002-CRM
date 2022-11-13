using Company.Crm.Application.Dtos;

namespace Company.Crm.Application.Services.Abstracts;

public interface ICustomerService
{
    List<CustomerDto> GetAll();
    CustomerDto? GetById(int id);
    bool Insert(CreateOrUpdateCustomerDto dto);
    bool Update(CreateOrUpdateCustomerDto dto);
    bool Delete(CustomerDto dto);
    bool DeleteById(int id);
    List<CustomerDto> GetAllByRegionId(int regionId);
    List<CustomerDto> GetPaged(int page = 1);
}