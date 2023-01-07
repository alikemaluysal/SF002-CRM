using Company.Crm.Application.Dtos;
using Company.Framework.Dtos;

namespace Company.Crm.Application.Services.Abstracts;

public interface ICustomerService
{
    ServiceResponse<List<CustomerDto>> GetAll();
    ServiceResponse<CustomerDto?> GetById(int id);
    ServiceResponse<CreateOrUpdateCustomerDto?> GetForEditById(int id);
    ServiceResponse<bool> Insert(CreateOrUpdateCustomerDto dto);
    ServiceResponse<bool> Update(CreateOrUpdateCustomerDto dto);
    ServiceResponse<bool> Delete(CustomerDto dto);
    ServiceResponse<bool> DeleteById(int id);
    ServiceResponse<List<CustomerDto>> GetAllByRegionId(int regionId);
    ServicePagedResponse<List<CustomerDto>> GetPaged(PaginationRequest req);
}