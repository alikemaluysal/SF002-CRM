using Company.Crm.Application.Dtos.Address;
using Company.Crm.Application.Dtos.UserAddress;

namespace Company.Crm.Application.Services.Abstracts;

public interface IUserAddressService
{
    List<AddressDetailDto> GetAll();
    AddressDetailDto? GetById(int id);
    bool Insert(AddressCreateOrUpdateDto dto);
    bool Update(AddressCreateOrUpdateDto dto);
    bool Delete(AddressDetailDto dto);
    bool DeleteById(int id);
    AddressCreateOrUpdateDto? GetForEditById(int id);
    List<AddressDetailDto> GetPaged(int page = 1);
}