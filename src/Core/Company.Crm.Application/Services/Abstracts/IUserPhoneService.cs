using Company.Crm.Application.Dtos.UserPhone;
using Company.Crm.Domain.Entities;

namespace Company.Crm.Application.Services.Abstracts;

public interface IUserPhoneService
{
    List<UserPhoneDto> GetPaged(int page = 1);
    List<UserPhone> GetAll();
    UserPhone? GetById(int id);
    bool Insert(CreateOrUpdateUserPhoneDto dto);
    bool Update(CreateOrUpdateUserPhoneDto dto);
    bool Delete(UserPhoneDto dto);
    bool DeleteById(int id);
    CreateOrUpdateUserPhoneDto? GetForEditById(int id);
}