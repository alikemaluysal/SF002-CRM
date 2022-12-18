using Company.Crm.Application.Dtos.UserPhone;
using Company.Crm.Domain.Entities;

namespace Company.Crm.Application.Services.Abstracts;

public interface IUserPhoneService
{
    public List<UserPhoneDto> GetPaged(int page = 1);
    public List<UserPhone> GetAll();
    public UserPhone? GetById(int id);
    public bool Insert(CreateOrUpdateUserPhoneDto dto);
    public bool Update(CreateOrUpdateUserPhoneDto dto);
    public bool Delete(UserPhoneDto dto);
    public bool DeleteById(int id);
    public CreateOrUpdateUserPhoneDto? GetForEditById(int id);
    //object GetPaged(int page);
}