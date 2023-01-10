using Company.Crm.Application.Dtos.Address;
using Company.Crm.Application.Dtos.UserAddress;
using Company.Crm.Application.Dtos.UserEmail;
using Company.Crm.Domain.Entities;

namespace Company.Crm.Application.Services.Abstracts;

public interface IUserEmailService
{
    public List<UserEmail> GetAll();
    public UserEmail? GetById(int id);
    bool Insert(UserEmail entity);
    bool Update(UserEmail entity);
    bool Delete(UserEmail entity);
    bool DeleteById(int id);
    CreateOrUpdateUserEmailDto? GetForEditById(int id);
    List<UserEmail> GetPaged(int page = 1);
}