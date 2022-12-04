using Company.Crm.Application.Dtos.Address;
using Company.Crm.Application.Dtos.UserAddress;

namespace Company.Crm.Application.Services.Abstracts;

public interface IUserAddressService
{
    public List<AddressDetailDto> GetAll();
    public AddressDetailDto? GetById(int id);
    public bool Insert(AddressCreateOrUpdateDto dto);
    public bool Update(AddressCreateOrUpdateDto dto);
    public bool Delete(AddressDetailDto dto);
    public bool DeleteById(int id);
    AddressCreateOrUpdateDto? GetForEditById(int id);
    List<AddressDetailDto> GetPaged(int page = 1);
}