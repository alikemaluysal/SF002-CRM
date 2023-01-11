using Company.Crm.Application.Dtos.UserEmail;
using Company.Crm.Domain.Entities;

namespace Company.Crm.Application.Services.Abstracts;

public interface IUserEmailService
{
    public List<UserEmailDto> GetAll();
    public UserEmailDto? GetById(int id);
    bool Insert(UserEmail entity);
    bool Update(UserEmail entity);
    bool Delete(UserEmail entity);
    bool DeleteById(int id);
    CreateOrUpdateUserEmailDto? GetForEditById(int id);
    List<UserEmail> GetPaged(int page = 1);
}